using System;
using System.Buffers;
using System.Text;

namespace Omnius.Core.Serialization.Extensions
{
    public static class BytesToUtf8StringConverterExtension
    {
        private static readonly Lazy<UTF8Encoding> _utf8Encoding = new Lazy<UTF8Encoding>(() => new UTF8Encoding(false));

        public static bool TryEncode(this IBytesToUtf8StringConverter converter, ReadOnlySpan<byte> span, out string text, bool includePrefix = false)
        {
            if (!converter.TryEncode(span, out var utf8string, includePrefix)) throw new FormatException(nameof(span));

            text = _utf8Encoding.Value.GetString(utf8string);

            return true;
        }

        public static bool TryEncode(this IBytesToUtf8StringConverter converter, ReadOnlySequence<byte> sequence, out string text, bool includePrefix = false)
        {
            if (!converter.TryEncode(sequence, out var utf8string, includePrefix)) throw new FormatException(nameof(sequence));

            text = _utf8Encoding.Value.GetString(utf8string);

            return true;
        }

        public static bool TryDecode(this IBytesToUtf8StringConverter converter, string text, IBufferWriter<byte> bufferWriter)
        {
            using (var recyclableMemory = BytesPool.Shared.Memory.Rent(_utf8Encoding.Value.GetMaxByteCount(text.Length)))
            {
                var length = _utf8Encoding.Value.GetBytes(text, recyclableMemory.Memory.Span);

                if (!converter.TryDecode(recyclableMemory.Memory.Span.Slice(0, length), bufferWriter)) throw new FormatException(nameof(text));
            }

            return true;
        }

        public static byte[] BytesToUtf8String(this IBytesToUtf8StringConverter converter, ReadOnlySpan<byte> span)
        {
            converter.TryEncode(span, out var text);
            return text;
        }

        public static byte[] BytesToUtf8String(this IBytesToUtf8StringConverter converter, ReadOnlySequence<byte> sequence)
        {
            converter.TryEncode(sequence, out var text);
            return text;
        }

        public static string BytesToString(this IBytesToUtf8StringConverter converter, ReadOnlySpan<byte> span)
        {
            converter.TryEncode(span, out string text);
            return text;
        }

        public static string BytesToString(this IBytesToUtf8StringConverter converter, ReadOnlySequence<byte> sequence)
        {
            converter.TryEncode(sequence, out string text);
            return text;
        }

        public static byte[] StringToBytes(this IBytesToUtf8StringConverter converter, string text)
        {
            using (var hub = new BytesHub())
            {
                converter.TryDecode(text, hub.Writer);

                var result = new byte[hub.Writer.WrittenBytes];
                hub.Reader.GetSequence().CopyTo(result);

                return result;
            }
        }

        public static byte[] Utf8StringToBytes(this IBytesToUtf8StringConverter converter, ReadOnlySpan<byte> text)
        {
            using (var hub = new BytesHub())
            {
                converter.TryDecode(text, hub.Writer);

                var result = new byte[hub.Writer.WrittenBytes];
                hub.Reader.GetSequence().CopyTo(result);

                return result;
            }
        }
    }
}
