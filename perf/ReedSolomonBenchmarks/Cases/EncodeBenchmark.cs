using System;
using System.Buffers;
using System.Linq;
using BenchmarkDotNet.Attributes;
using Omnix.Algorithms.Correction;
using Omnix.Base;
using ReedSolomonBenchmarks.Internal;

namespace ReedSolomonBenchmarks.Cases
{
    [Config(typeof(BenchmarkConfig))]
    public class EncodeBenchmark
    {
        private static readonly int[] _indexes = new int[128];
        private static readonly Memory<byte>[] _sources = new Memory<byte>[128];
        private static readonly Memory<byte>[] _repairs = new Memory<byte>[128];
        private const int PacketLength = 1024 * 1024;

        static EncodeBenchmark()
        {
            var random = new Random();

            for (int i = 0; i < _sources.Length; i++)
            {
                _indexes[i] = i + 128;
                _sources[i] = new byte[PacketLength];
                random.NextBytes(_sources[i].Span);
            }

            for (int i = 0; i < _repairs.Length; i++)
            {
                _repairs[i] = new byte[PacketLength];
            }
        }

        [Benchmark(Baseline = true)]
        public object Managed_Test()
        {
            var r = new ReedSolomon8(128, 256, BufferPool.Shared)
            {
                UseSimd = false
            };
            r.Encode(_sources.Select(n => (ReadOnlyMemory<byte>)n).ToArray(), _indexes, _repairs, PacketLength).Wait();
            return _repairs;
        }

        [Benchmark]
        public object Avx2_Test()
        {
            var r = new ReedSolomon8(128, 256, BufferPool.Shared)
            {
                UseSimd = true
            };
            r.Encode(_sources.Select(n => (ReadOnlyMemory<byte>)n).ToArray(), _indexes, _repairs, PacketLength).Wait();
            return _repairs;
        }

        [Benchmark]
        public object Avx2_Concurrency_4_Test()
        {
            var r = new ReedSolomon8(128, 256, BufferPool.Shared)
            {
                UseSimd = true
            };
            r.Encode(_sources.Select(n => (ReadOnlyMemory<byte>)n).ToArray(), _indexes, _repairs, PacketLength, 4).Wait();
            return _repairs;
        }
    }
}
