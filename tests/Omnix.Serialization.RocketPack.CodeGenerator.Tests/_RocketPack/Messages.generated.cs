﻿using Omnix.Base;
using Omnix.Base.Helpers;
using Omnix.Serialization;
using Omnix.Serialization.RocketPack;
using System;
using System.Buffers;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Omnix.Serialization.RocketPack.CodeGenerator.Tests
{
    public enum Enum1 : sbyte
    {
        Yes = 0,
        No = 1,
    }

    public enum Enum2 : short
    {
        Yes = 0,
        No = 1,
    }

    public enum Enum3 : int
    {
        Yes = 0,
        No = 1,
    }

    public enum Enum4 : long
    {
        Yes = 0,
        No = 1,
    }

    public enum Enum5 : byte
    {
        Yes = 0,
        No = 1,
    }

    public enum Enum6 : ushort
    {
        Yes = 0,
        No = 1,
    }

    public enum Enum7 : uint
    {
        Yes = 0,
        No = 1,
    }

    public enum Enum8 : ulong
    {
        Yes = 0,
        No = 1,
    }

    public sealed partial class HelloMessage : RocketPackMessageBase<HelloMessage>, IDisposable
    {
        static HelloMessage()
        {
            HelloMessage.Formatter = new CustomFormatter();
        }

        public static readonly int MaxX19Length = 128;
        public static readonly int MaxX21Length = 256;
        public static readonly int MaxX22Length = 256;
        public static readonly int MaxX23Count = 16;
        public static readonly int MaxX24Count = 32;

        public HelloMessage(bool x0, sbyte x1, short x2, int x3, long x4, byte x5, ushort x6, uint x7, ulong x8, Enum1 x9, Enum2 x10, Enum3 x11, Enum4 x12, Enum5 x13, Enum6 x14, Enum7 x15, Enum8 x16, float x17, double x18, string x19, Timestamp x20, ReadOnlyMemory<byte> x21, IMemoryOwner<byte> x22, IList<string> x23, IDictionary<byte, string> x24)
        {
            if (x19 is null) throw new ArgumentNullException("x19");
            if (x19.Length > 128) throw new ArgumentOutOfRangeException("x19");
            if (x21.Length > 256) throw new ArgumentOutOfRangeException("x21");
            if (x22 is null) throw new ArgumentNullException("x22");
            if (x22.Memory.Length > 256) throw new ArgumentOutOfRangeException("x22");
            if (x23 is null) throw new ArgumentNullException("x23");
            if (x23.Count > 16) throw new ArgumentOutOfRangeException("x23");
            foreach (var n in x23)
            {
                if (n is null) throw new ArgumentNullException("n");
                if (n.Length > 128) throw new ArgumentOutOfRangeException("n");
            }
            if (x24 is null) throw new ArgumentNullException("x24");
            if (x24.Count > 32) throw new ArgumentOutOfRangeException("x24");
            foreach (var n in x24)
            {
                if (n.Value is null) throw new ArgumentNullException("n.Value");
                if (n.Value.Length > 128) throw new ArgumentOutOfRangeException("n.Value");
            }

            this.X0 = x0;
            this.X1 = x1;
            this.X2 = x2;
            this.X3 = x3;
            this.X4 = x4;
            this.X5 = x5;
            this.X6 = x6;
            this.X7 = x7;
            this.X8 = x8;
            this.X9 = x9;
            this.X10 = x10;
            this.X11 = x11;
            this.X12 = x12;
            this.X13 = x13;
            this.X14 = x14;
            this.X15 = x15;
            this.X16 = x16;
            this.X17 = x17;
            this.X18 = x18;
            this.X19 = x19;
            this.X20 = x20;
            this.X21 = x21;
            _x22 = x22;
            this.X23 = new ReadOnlyCollection<string>(x23);
            this.X24 = new ReadOnlyDictionary<byte, string>(x24);

            {
                var hashCode = new HashCode();
                if (this.X0 != default) hashCode.Add(this.X0.GetHashCode());
                if (this.X1 != default) hashCode.Add(this.X1.GetHashCode());
                if (this.X2 != default) hashCode.Add(this.X2.GetHashCode());
                if (this.X3 != default) hashCode.Add(this.X3.GetHashCode());
                if (this.X4 != default) hashCode.Add(this.X4.GetHashCode());
                if (this.X5 != default) hashCode.Add(this.X5.GetHashCode());
                if (this.X6 != default) hashCode.Add(this.X6.GetHashCode());
                if (this.X7 != default) hashCode.Add(this.X7.GetHashCode());
                if (this.X8 != default) hashCode.Add(this.X8.GetHashCode());
                if (this.X9 != default) hashCode.Add(this.X9.GetHashCode());
                if (this.X10 != default) hashCode.Add(this.X10.GetHashCode());
                if (this.X11 != default) hashCode.Add(this.X11.GetHashCode());
                if (this.X12 != default) hashCode.Add(this.X12.GetHashCode());
                if (this.X13 != default) hashCode.Add(this.X13.GetHashCode());
                if (this.X14 != default) hashCode.Add(this.X14.GetHashCode());
                if (this.X15 != default) hashCode.Add(this.X15.GetHashCode());
                if (this.X16 != default) hashCode.Add(this.X16.GetHashCode());
                if (this.X17 != default) hashCode.Add(this.X17.GetHashCode());
                if (this.X18 != default) hashCode.Add(this.X18.GetHashCode());
                if (this.X19 != default) hashCode.Add(this.X19.GetHashCode());
                if (this.X20 != default) hashCode.Add(this.X20.GetHashCode());
                if (!this.X21.IsEmpty) hashCode.Add(ObjectHelper.GetHashCode(this.X21.Span));
                if (!this.X22.IsEmpty) hashCode.Add(ObjectHelper.GetHashCode(this.X22.Span));
                foreach (var n in this.X23)
                {
                    if (n != default) hashCode.Add(n.GetHashCode());
                }
                foreach (var n in this.X24)
                {
                    if (n.Key != default) hashCode.Add(n.Key.GetHashCode());
                    if (n.Value != default) hashCode.Add(n.Value.GetHashCode());
                }
                _hashCode = hashCode.ToHashCode();
            }
        }

        public bool X0 { get; }
        public sbyte X1 { get; }
        public short X2 { get; }
        public int X3 { get; }
        public long X4 { get; }
        public byte X5 { get; }
        public ushort X6 { get; }
        public uint X7 { get; }
        public ulong X8 { get; }
        public Enum1 X9 { get; }
        public Enum2 X10 { get; }
        public Enum3 X11 { get; }
        public Enum4 X12 { get; }
        public Enum5 X13 { get; }
        public Enum6 X14 { get; }
        public Enum7 X15 { get; }
        public Enum8 X16 { get; }
        public float X17 { get; }
        public double X18 { get; }
        public string X19 { get; }
        public Timestamp X20 { get; }
        public ReadOnlyMemory<byte> X21 { get; }
        private readonly IMemoryOwner<byte> _x22;
        public ReadOnlyMemory<byte> X22 => _x22.Memory;
        public IReadOnlyList<string> X23 { get; }
        public IReadOnlyDictionary<byte, string> X24 { get; }

        public override bool Equals(HelloMessage target)
        {
            if ((object)target == null) return false;
            if (Object.ReferenceEquals(this, target)) return true;
            if (this.X0 != target.X0) return false;
            if (this.X1 != target.X1) return false;
            if (this.X2 != target.X2) return false;
            if (this.X3 != target.X3) return false;
            if (this.X4 != target.X4) return false;
            if (this.X5 != target.X5) return false;
            if (this.X6 != target.X6) return false;
            if (this.X7 != target.X7) return false;
            if (this.X8 != target.X8) return false;
            if (this.X9 != target.X9) return false;
            if (this.X10 != target.X10) return false;
            if (this.X11 != target.X11) return false;
            if (this.X12 != target.X12) return false;
            if (this.X13 != target.X13) return false;
            if (this.X14 != target.X14) return false;
            if (this.X15 != target.X15) return false;
            if (this.X16 != target.X16) return false;
            if (this.X17 != target.X17) return false;
            if (this.X19 != target.X19) return false;
            if (this.X20 != target.X20) return false;
            if (!BytesOperations.SequenceEqual(this.X21.Span, target.X21.Span)) return false;
            if (!BytesOperations.SequenceEqual(this.X22.Span, target.X22.Span)) return false;
            if ((this.X23 is null) != (target.X23 is null)) return false;
            if (!(this.X23 is null) && !(target.X23 is null) && !CollectionHelper.Equals(this.X23, target.X23)) return false;
            if ((this.X24 is null) != (target.X24 is null)) return false;
            if (!(this.X24 is null) && !(target.X24 is null) && !CollectionHelper.Equals(this.X24, target.X24)) return false;

            return true;
        }

        private readonly int _hashCode;
        public override int GetHashCode() => _hashCode;

        public void Dispose()
        {
            _x22?.Dispose();
        }

        private sealed class CustomFormatter : IRocketPackFormatter<HelloMessage>
        {
            public void Serialize(RocketPackWriter w, HelloMessage value, int rank)
            {
                if (rank > 256) throw new FormatException();

                // X0
                if (value.X0 != default)
                {
                    w.Write((ulong)0);
                    w.Write(value.X0);
                }
                // X1
                if (value.X1 != default)
                {
                    w.Write((ulong)1);
                    w.Write((long)value.X1);
                }
                // X2
                if (value.X2 != default)
                {
                    w.Write((ulong)2);
                    w.Write((long)value.X2);
                }
                // X3
                if (value.X3 != default)
                {
                    w.Write((ulong)3);
                    w.Write((long)value.X3);
                }
                // X4
                if (value.X4 != default)
                {
                    w.Write((ulong)4);
                    w.Write((long)value.X4);
                }
                // X5
                if (value.X5 != default)
                {
                    w.Write((ulong)5);
                    w.Write((ulong)value.X5);
                }
                // X6
                if (value.X6 != default)
                {
                    w.Write((ulong)6);
                    w.Write((ulong)value.X6);
                }
                // X7
                if (value.X7 != default)
                {
                    w.Write((ulong)7);
                    w.Write((ulong)value.X7);
                }
                // X8
                if (value.X8 != default)
                {
                    w.Write((ulong)8);
                    w.Write((ulong)value.X8);
                }
                // X9
                if (value.X9 != default)
                {
                    w.Write((ulong)9);
                    w.Write((long)value.X9);
                }
                // X10
                if (value.X10 != default)
                {
                    w.Write((ulong)10);
                    w.Write((long)value.X10);
                }
                // X11
                if (value.X11 != default)
                {
                    w.Write((ulong)11);
                    w.Write((long)value.X11);
                }
                // X12
                if (value.X12 != default)
                {
                    w.Write((ulong)12);
                    w.Write((long)value.X12);
                }
                // X13
                if (value.X13 != default)
                {
                    w.Write((ulong)13);
                    w.Write((ulong)value.X13);
                }
                // X14
                if (value.X14 != default)
                {
                    w.Write((ulong)14);
                    w.Write((ulong)value.X14);
                }
                // X15
                if (value.X15 != default)
                {
                    w.Write((ulong)15);
                    w.Write((ulong)value.X15);
                }
                // X16
                if (value.X16 != default)
                {
                    w.Write((ulong)16);
                    w.Write((ulong)value.X16);
                }
                // X17
                if (value.X17 != default)
                {
                    w.Write((ulong)17);
                    w.Write(value.X17);
                }
                // X18
                if (value.X18 != default)
                {
                    w.Write((ulong)18);
                    w.Write(value.X18);
                }
                // X19
                if (value.X19 != default)
                {
                    w.Write((ulong)19);
                    w.Write(value.X19);
                }
                // X20
                if (value.X20 != default)
                {
                    w.Write((ulong)20);
                    w.Write(value.X20);
                }
                // X21
                if (!value.X21.IsEmpty)
                {
                    w.Write((ulong)21);
                    w.Write(value.X21.Span);
                }
                // X22
                if (!value.X22.IsEmpty)
                {
                    w.Write((ulong)22);
                    w.Write(value.X22.Span);
                }
                // X23
                if (value.X23.Count != 0)
                {
                    w.Write((ulong)23);
                    w.Write((ulong)value.X23.Count);
                    foreach (var n in value.X23)
                    {
                        w.Write(n);
                    }
                }
                // X24
                if (value.X24.Count != 0)
                {
                    w.Write((ulong)24);
                    w.Write((ulong)value.X24.Count);
                    foreach (var n in value.X24)
                    {
                        w.Write((ulong)n.Key);
                        w.Write(n.Value);
                    }
                }
            }

            public HelloMessage Deserialize(RocketPackReader r, int rank)
            {
                if (rank > 256) throw new FormatException();

                bool p_x0 = default;
                sbyte p_x1 = default;
                short p_x2 = default;
                int p_x3 = default;
                long p_x4 = default;
                byte p_x5 = default;
                ushort p_x6 = default;
                uint p_x7 = default;
                ulong p_x8 = default;
                Enum1 p_x9 = default;
                Enum2 p_x10 = default;
                Enum3 p_x11 = default;
                Enum4 p_x12 = default;
                Enum5 p_x13 = default;
                Enum6 p_x14 = default;
                Enum7 p_x15 = default;
                Enum8 p_x16 = default;
                float p_x17 = default;
                double p_x18 = default;
                string p_x19 = default;
                Timestamp p_x20 = default;
                ReadOnlyMemory<byte> p_x21 = default;
                IMemoryOwner<byte> p_x22 = default;
                IList<string> p_x23 = default;
                IDictionary<byte, string> p_x24 = default;

                while (r.Available > 0)
                {
                    int id = (int)r.GetUInt64();
                    switch (id)
                    {
                        case 0: // X0
                            {
                                p_x0 = r.GetBoolean();
                                break;
                            }
                        case 1: // X1
                            {
                                p_x1 = (sbyte)r.GetInt64();
                                break;
                            }
                        case 2: // X2
                            {
                                p_x2 = (short)r.GetInt64();
                                break;
                            }
                        case 3: // X3
                            {
                                p_x3 = (int)r.GetInt64();
                                break;
                            }
                        case 4: // X4
                            {
                                p_x4 = (long)r.GetInt64();
                                break;
                            }
                        case 5: // X5
                            {
                                p_x5 = (byte)r.GetUInt64();
                                break;
                            }
                        case 6: // X6
                            {
                                p_x6 = (ushort)r.GetUInt64();
                                break;
                            }
                        case 7: // X7
                            {
                                p_x7 = (uint)r.GetUInt64();
                                break;
                            }
                        case 8: // X8
                            {
                                p_x8 = (ulong)r.GetUInt64();
                                break;
                            }
                        case 9: // X9
                            {
                                p_x9 = (Enum1)r.GetInt64();
                                break;
                            }
                        case 10: // X10
                            {
                                p_x10 = (Enum2)r.GetInt64();
                                break;
                            }
                        case 11: // X11
                            {
                                p_x11 = (Enum3)r.GetInt64();
                                break;
                            }
                        case 12: // X12
                            {
                                p_x12 = (Enum4)r.GetInt64();
                                break;
                            }
                        case 13: // X13
                            {
                                p_x13 = (Enum5)r.GetUInt64();
                                break;
                            }
                        case 14: // X14
                            {
                                p_x14 = (Enum6)r.GetUInt64();
                                break;
                            }
                        case 15: // X15
                            {
                                p_x15 = (Enum7)r.GetUInt64();
                                break;
                            }
                        case 16: // X16
                            {
                                p_x16 = (Enum8)r.GetUInt64();
                                break;
                            }
                        case 17: // X17
                            {
                                p_x17 = r.GetFloat32();
                                break;
                            }
                        case 18: // X18
                            {
                                p_x18 = r.GetFloat64();
                                break;
                            }
                        case 19: // X19
                            {
                                p_x19 = r.GetString(128);
                                break;
                            }
                        case 20: // X20
                            {
                                p_x20 = r.GetTimestamp();
                                break;
                            }
                        case 21: // X21
                            {
                                p_x21 = r.GetMemory(256);
                                break;
                            }
                        case 22: // X22
                            {
                                p_x22 = r.GetRecyclableMemory(256);
                                break;
                            }
                        case 23: // X23
                            {
                                var length = (int)r.GetUInt64();
                                p_x23 = new string[length];
                                for (int i = 0; i < p_x23.Count; i++)
                                {
                                    p_x23[i] = r.GetString(128);
                                }
                                break;
                            }
                        case 24: // X24
                            {
                                var length = (int)r.GetUInt64();
                                p_x24 = new Dictionary<byte, string>();
                                byte t_key = default;
                                string t_value = default;
                                for (int i = 0; i < length; i++)
                                {
                                    t_key = (byte)r.GetUInt64();
                                    t_value = r.GetString(128);
                                    p_x24[t_key] = t_value;
                                }
                                break;
                            }
                    }
                }

                return new HelloMessage(p_x0, p_x1, p_x2, p_x3, p_x4, p_x5, p_x6, p_x7, p_x8, p_x9, p_x10, p_x11, p_x12, p_x13, p_x14, p_x15, p_x16, p_x17, p_x18, p_x19, p_x20, p_x21, p_x22, p_x23, p_x24);
            }
        }
    }

    public readonly struct SmallHelloMessage
    {
        public static IRocketPackFormatter<SmallHelloMessage> Formatter { get; }

        static SmallHelloMessage()
        {
            SmallHelloMessage.Formatter = new CustomFormatter();
        }

        public static readonly int MaxX19Length = 128;
        public static readonly int MaxX21Length = 256;
        public static readonly int MaxX22Length = 256;
        public static readonly int MaxX23Count = 16;
        public static readonly int MaxX24Count = 32;

        public SmallHelloMessage(bool x0, sbyte x1, short x2, int x3, long x4, byte x5, ushort x6, uint x7, ulong x8, Enum1 x9, Enum2 x10, Enum3 x11, Enum4 x12, Enum5 x13, Enum6 x14, Enum7 x15, Enum8 x16, float x17, double x18, string x19, Timestamp x20, ReadOnlyMemory<byte> x21, ReadOnlyMemory<byte> x22, IList<string> x23, IDictionary<byte, string> x24)
        {
            if (x19 is null) throw new ArgumentNullException("x19");
            if (x19.Length > 128) throw new ArgumentOutOfRangeException("x19");
            if (x21.Length > 256) throw new ArgumentOutOfRangeException("x21");
            if (x22.Length > 256) throw new ArgumentOutOfRangeException("x22");
            if (x23 is null) throw new ArgumentNullException("x23");
            if (x23.Count > 16) throw new ArgumentOutOfRangeException("x23");
            foreach (var n in x23)
            {
                if (n is null) throw new ArgumentNullException("n");
                if (n.Length > 128) throw new ArgumentOutOfRangeException("n");
            }
            if (x24 is null) throw new ArgumentNullException("x24");
            if (x24.Count > 32) throw new ArgumentOutOfRangeException("x24");
            foreach (var n in x24)
            {
                if (n.Value is null) throw new ArgumentNullException("n.Value");
                if (n.Value.Length > 128) throw new ArgumentOutOfRangeException("n.Value");
            }

            this.X0 = x0;
            this.X1 = x1;
            this.X2 = x2;
            this.X3 = x3;
            this.X4 = x4;
            this.X5 = x5;
            this.X6 = x6;
            this.X7 = x7;
            this.X8 = x8;
            this.X9 = x9;
            this.X10 = x10;
            this.X11 = x11;
            this.X12 = x12;
            this.X13 = x13;
            this.X14 = x14;
            this.X15 = x15;
            this.X16 = x16;
            this.X17 = x17;
            this.X18 = x18;
            this.X19 = x19;
            this.X20 = x20;
            this.X21 = x21;
            this.X22 = x22;
            this.X23 = new ReadOnlyCollection<string>(x23);
            this.X24 = new ReadOnlyDictionary<byte, string>(x24);

            {
                var hashCode = new HashCode();
                if (this.X0 != default) hashCode.Add(this.X0.GetHashCode());
                if (this.X1 != default) hashCode.Add(this.X1.GetHashCode());
                if (this.X2 != default) hashCode.Add(this.X2.GetHashCode());
                if (this.X3 != default) hashCode.Add(this.X3.GetHashCode());
                if (this.X4 != default) hashCode.Add(this.X4.GetHashCode());
                if (this.X5 != default) hashCode.Add(this.X5.GetHashCode());
                if (this.X6 != default) hashCode.Add(this.X6.GetHashCode());
                if (this.X7 != default) hashCode.Add(this.X7.GetHashCode());
                if (this.X8 != default) hashCode.Add(this.X8.GetHashCode());
                if (this.X9 != default) hashCode.Add(this.X9.GetHashCode());
                if (this.X10 != default) hashCode.Add(this.X10.GetHashCode());
                if (this.X11 != default) hashCode.Add(this.X11.GetHashCode());
                if (this.X12 != default) hashCode.Add(this.X12.GetHashCode());
                if (this.X13 != default) hashCode.Add(this.X13.GetHashCode());
                if (this.X14 != default) hashCode.Add(this.X14.GetHashCode());
                if (this.X15 != default) hashCode.Add(this.X15.GetHashCode());
                if (this.X16 != default) hashCode.Add(this.X16.GetHashCode());
                if (this.X17 != default) hashCode.Add(this.X17.GetHashCode());
                if (this.X18 != default) hashCode.Add(this.X18.GetHashCode());
                if (this.X19 != default) hashCode.Add(this.X19.GetHashCode());
                if (this.X20 != default) hashCode.Add(this.X20.GetHashCode());
                if (!this.X21.IsEmpty) hashCode.Add(ObjectHelper.GetHashCode(this.X21.Span));
                if (!this.X22.IsEmpty) hashCode.Add(ObjectHelper.GetHashCode(this.X22.Span));
                foreach (var n in this.X23)
                {
                    if (n != default) hashCode.Add(n.GetHashCode());
                }
                foreach (var n in this.X24)
                {
                    if (n.Key != default) hashCode.Add(n.Key.GetHashCode());
                    if (n.Value != default) hashCode.Add(n.Value.GetHashCode());
                }
                _hashCode = hashCode.ToHashCode();
            }
        }

        public static SmallHelloMessage Import(ReadOnlySequence<byte> sequence, BufferPool bufferPool)
        {
            return Formatter.Deserialize(new RocketPackReader(sequence, bufferPool), 0);
        }

        public void Export(IBufferWriter<byte> bufferWriter, BufferPool bufferPool)
        {
            Formatter.Serialize(new RocketPackWriter(bufferWriter, bufferPool), (SmallHelloMessage)this, 0);
        }

        public bool X0 { get; }
        public sbyte X1 { get; }
        public short X2 { get; }
        public int X3 { get; }
        public long X4 { get; }
        public byte X5 { get; }
        public ushort X6 { get; }
        public uint X7 { get; }
        public ulong X8 { get; }
        public Enum1 X9 { get; }
        public Enum2 X10 { get; }
        public Enum3 X11 { get; }
        public Enum4 X12 { get; }
        public Enum5 X13 { get; }
        public Enum6 X14 { get; }
        public Enum7 X15 { get; }
        public Enum8 X16 { get; }
        public float X17 { get; }
        public double X18 { get; }
        public string X19 { get; }
        public Timestamp X20 { get; }
        public ReadOnlyMemory<byte> X21 { get; }
        public ReadOnlyMemory<byte> X22 { get; }
        public IReadOnlyList<string> X23 { get; }
        public IReadOnlyDictionary<byte, string> X24 { get; }

        public static bool operator ==(SmallHelloMessage x, SmallHelloMessage y) => x.Equals(y);
        public static bool operator !=(SmallHelloMessage x, SmallHelloMessage y) => !x.Equals(y);

        public override bool Equals(object other)
        {
            if (!(other is SmallHelloMessage)) return false;
            return this.Equals((SmallHelloMessage)other);
        }

        public bool Equals(SmallHelloMessage target)
        {
            if (this.X0 != target.X0) return false;
            if (this.X1 != target.X1) return false;
            if (this.X2 != target.X2) return false;
            if (this.X3 != target.X3) return false;
            if (this.X4 != target.X4) return false;
            if (this.X5 != target.X5) return false;
            if (this.X6 != target.X6) return false;
            if (this.X7 != target.X7) return false;
            if (this.X8 != target.X8) return false;
            if (this.X9 != target.X9) return false;
            if (this.X10 != target.X10) return false;
            if (this.X11 != target.X11) return false;
            if (this.X12 != target.X12) return false;
            if (this.X13 != target.X13) return false;
            if (this.X14 != target.X14) return false;
            if (this.X15 != target.X15) return false;
            if (this.X16 != target.X16) return false;
            if (this.X17 != target.X17) return false;
            if (this.X19 != target.X19) return false;
            if (this.X20 != target.X20) return false;
            if (!BytesOperations.SequenceEqual(this.X21.Span, target.X21.Span)) return false;
            if (!BytesOperations.SequenceEqual(this.X22.Span, target.X22.Span)) return false;
            if ((this.X23 is null) != (target.X23 is null)) return false;
            if (!(this.X23 is null) && !(target.X23 is null) && !CollectionHelper.Equals(this.X23, target.X23)) return false;
            if ((this.X24 is null) != (target.X24 is null)) return false;
            if (!(this.X24 is null) && !(target.X24 is null) && !CollectionHelper.Equals(this.X24, target.X24)) return false;

            return true;
        }

        private readonly int _hashCode;
        public override int GetHashCode() => _hashCode;

        private sealed class CustomFormatter : IRocketPackFormatter<SmallHelloMessage>
        {
            public void Serialize(RocketPackWriter w, SmallHelloMessage value, int rank)
            {
                if (rank > 256) throw new FormatException();

                // X0
                if (value.X0 != default)
                {
                    w.Write(value.X0);
                }
                // X1
                if (value.X1 != default)
                {
                    w.Write((long)value.X1);
                }
                // X2
                if (value.X2 != default)
                {
                    w.Write((long)value.X2);
                }
                // X3
                if (value.X3 != default)
                {
                    w.Write((long)value.X3);
                }
                // X4
                if (value.X4 != default)
                {
                    w.Write((long)value.X4);
                }
                // X5
                if (value.X5 != default)
                {
                    w.Write((ulong)value.X5);
                }
                // X6
                if (value.X6 != default)
                {
                    w.Write((ulong)value.X6);
                }
                // X7
                if (value.X7 != default)
                {
                    w.Write((ulong)value.X7);
                }
                // X8
                if (value.X8 != default)
                {
                    w.Write((ulong)value.X8);
                }
                // X9
                if (value.X9 != default)
                {
                    w.Write((long)value.X9);
                }
                // X10
                if (value.X10 != default)
                {
                    w.Write((long)value.X10);
                }
                // X11
                if (value.X11 != default)
                {
                    w.Write((long)value.X11);
                }
                // X12
                if (value.X12 != default)
                {
                    w.Write((long)value.X12);
                }
                // X13
                if (value.X13 != default)
                {
                    w.Write((ulong)value.X13);
                }
                // X14
                if (value.X14 != default)
                {
                    w.Write((ulong)value.X14);
                }
                // X15
                if (value.X15 != default)
                {
                    w.Write((ulong)value.X15);
                }
                // X16
                if (value.X16 != default)
                {
                    w.Write((ulong)value.X16);
                }
                // X17
                if (value.X17 != default)
                {
                    w.Write(value.X17);
                }
                // X18
                if (value.X18 != default)
                {
                    w.Write(value.X18);
                }
                // X19
                if (value.X19 != default)
                {
                    w.Write(value.X19);
                }
                // X20
                if (value.X20 != default)
                {
                    w.Write(value.X20);
                }
                // X21
                if (!value.X21.IsEmpty)
                {
                    w.Write(value.X21.Span);
                }
                // X22
                if (!value.X22.IsEmpty)
                {
                    w.Write(value.X22.Span);
                }
                // X23
                if (value.X23.Count != 0)
                {
                    w.Write((ulong)value.X23.Count);
                    foreach (var n in value.X23)
                    {
                        w.Write(n);
                    }
                }
                // X24
                if (value.X24.Count != 0)
                {
                    w.Write((ulong)value.X24.Count);
                    foreach (var n in value.X24)
                    {
                        w.Write((ulong)n.Key);
                        w.Write(n.Value);
                    }
                }
            }

            public SmallHelloMessage Deserialize(RocketPackReader r, int rank)
            {
                if (rank > 256) throw new FormatException();

                bool p_x0 = default;
                sbyte p_x1 = default;
                short p_x2 = default;
                int p_x3 = default;
                long p_x4 = default;
                byte p_x5 = default;
                ushort p_x6 = default;
                uint p_x7 = default;
                ulong p_x8 = default;
                Enum1 p_x9 = default;
                Enum2 p_x10 = default;
                Enum3 p_x11 = default;
                Enum4 p_x12 = default;
                Enum5 p_x13 = default;
                Enum6 p_x14 = default;
                Enum7 p_x15 = default;
                Enum8 p_x16 = default;
                float p_x17 = default;
                double p_x18 = default;
                string p_x19 = default;
                Timestamp p_x20 = default;
                ReadOnlyMemory<byte> p_x21 = default;
                ReadOnlyMemory<byte> p_x22 = default;
                IList<string> p_x23 = default;
                IDictionary<byte, string> p_x24 = default;

                // X0
                {
                    p_x0 = r.GetBoolean();
                }
                // X1
                {
                    p_x1 = (sbyte)r.GetInt64();
                }
                // X2
                {
                    p_x2 = (short)r.GetInt64();
                }
                // X3
                {
                    p_x3 = (int)r.GetInt64();
                }
                // X4
                {
                    p_x4 = (long)r.GetInt64();
                }
                // X5
                {
                    p_x5 = (byte)r.GetUInt64();
                }
                // X6
                {
                    p_x6 = (ushort)r.GetUInt64();
                }
                // X7
                {
                    p_x7 = (uint)r.GetUInt64();
                }
                // X8
                {
                    p_x8 = (ulong)r.GetUInt64();
                }
                // X9
                {
                    p_x9 = (Enum1)r.GetInt64();
                }
                // X10
                {
                    p_x10 = (Enum2)r.GetInt64();
                }
                // X11
                {
                    p_x11 = (Enum3)r.GetInt64();
                }
                // X12
                {
                    p_x12 = (Enum4)r.GetInt64();
                }
                // X13
                {
                    p_x13 = (Enum5)r.GetUInt64();
                }
                // X14
                {
                    p_x14 = (Enum6)r.GetUInt64();
                }
                // X15
                {
                    p_x15 = (Enum7)r.GetUInt64();
                }
                // X16
                {
                    p_x16 = (Enum8)r.GetUInt64();
                }
                // X17
                {
                    p_x17 = r.GetFloat32();
                }
                // X18
                {
                    p_x18 = r.GetFloat64();
                }
                // X19
                {
                    p_x19 = r.GetString(128);
                }
                // X20
                {
                    p_x20 = r.GetTimestamp();
                }
                // X21
                {
                    p_x21 = r.GetMemory(256);
                }
                // X22
                {
                    p_x22 = r.GetMemory(256);
                }
                // X23
                {
                    var length = (int)r.GetUInt64();
                    p_x23 = new string[length];
                    for (int i = 0; i < p_x23.Count; i++)
                    {
                        p_x23[i] = r.GetString(128);
                    }
                }
                // X24
                {
                    var length = (int)r.GetUInt64();
                    p_x24 = new Dictionary<byte, string>();
                    byte t_key = default;
                    string t_value = default;
                    for (int i = 0; i < length; i++)
                    {
                        t_key = (byte)r.GetUInt64();
                        t_value = r.GetString(128);
                        p_x24[t_key] = t_value;
                    }
                }

                return new SmallHelloMessage(p_x0, p_x1, p_x2, p_x3, p_x4, p_x5, p_x6, p_x7, p_x8, p_x9, p_x10, p_x11, p_x12, p_x13, p_x14, p_x15, p_x16, p_x17, p_x18, p_x19, p_x20, p_x21, p_x22, p_x23, p_x24);
            }
        }
    }

}
