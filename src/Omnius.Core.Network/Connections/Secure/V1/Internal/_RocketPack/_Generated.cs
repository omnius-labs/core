using Omnius.Core.Cryptography;

#nullable enable

namespace Omnius.Core.Network.Connections.Secure.V1.Internal
{
    internal enum KeyExchangeAlgorithm : byte
    {
        Unknown = 0,
        EcDh_P521_Sha2_256 = 1,
    }
    internal enum KeyDerivationAlgorithm : byte
    {
        Unknown = 0,
        Pbkdf2 = 1,
    }
    internal enum HashAlgorithm : byte
    {
        Unknown = 0,
        Sha2_256 = 1,
    }
    internal enum CryptoAlgorithm : byte
    {
        Unknown = 0,
        Aes_Gcm_256 = 1,
    }
    internal enum AuthenticationType : byte
    {
        None = 0,
        Password = 1,
    }

    internal sealed partial class ProfileMessage : global::Omnius.Core.RocketPack.IRocketPackObject<global::Omnius.Core.Network.Connections.Secure.V1.Internal.ProfileMessage>
    {
        public static global::Omnius.Core.RocketPack.IRocketPackObjectFormatter<global::Omnius.Core.Network.Connections.Secure.V1.Internal.ProfileMessage> Formatter => global::Omnius.Core.RocketPack.IRocketPackObject<global::Omnius.Core.Network.Connections.Secure.V1.Internal.ProfileMessage>.Formatter;
        public static global::Omnius.Core.Network.Connections.Secure.V1.Internal.ProfileMessage Empty => global::Omnius.Core.RocketPack.IRocketPackObject<global::Omnius.Core.Network.Connections.Secure.V1.Internal.ProfileMessage>.Empty;

        static ProfileMessage()
        {
            global::Omnius.Core.RocketPack.IRocketPackObject<global::Omnius.Core.Network.Connections.Secure.V1.Internal.ProfileMessage>.Formatter = new ___CustomFormatter();
            global::Omnius.Core.RocketPack.IRocketPackObject<global::Omnius.Core.Network.Connections.Secure.V1.Internal.ProfileMessage>.Empty = new global::Omnius.Core.Network.Connections.Secure.V1.Internal.ProfileMessage(global::System.ReadOnlyMemory<byte>.Empty, (AuthenticationType)0, global::System.Array.Empty<KeyExchangeAlgorithm>(), global::System.Array.Empty<KeyDerivationAlgorithm>(), global::System.Array.Empty<CryptoAlgorithm>(), global::System.Array.Empty<HashAlgorithm>());
        }

        private readonly global::System.Lazy<int> ___hashCode;

        public static readonly int MaxSessionIdLength = 32;
        public static readonly int MaxKeyExchangeAlgorithmsCount = 32;
        public static readonly int MaxKeyDerivationAlgorithmsCount = 32;
        public static readonly int MaxCryptoAlgorithmsCount = 32;
        public static readonly int MaxHashAlgorithmsCount = 32;

        public ProfileMessage(global::System.ReadOnlyMemory<byte> sessionId, AuthenticationType authenticationType, KeyExchangeAlgorithm[] keyExchangeAlgorithms, KeyDerivationAlgorithm[] keyDerivationAlgorithms, CryptoAlgorithm[] cryptoAlgorithms, HashAlgorithm[] hashAlgorithms)
        {
            if (sessionId.Length > 32) throw new global::System.ArgumentOutOfRangeException("sessionId");
            if (keyExchangeAlgorithms is null) throw new global::System.ArgumentNullException("keyExchangeAlgorithms");
            if (keyExchangeAlgorithms.Length > 32) throw new global::System.ArgumentOutOfRangeException("keyExchangeAlgorithms");
            if (keyDerivationAlgorithms is null) throw new global::System.ArgumentNullException("keyDerivationAlgorithms");
            if (keyDerivationAlgorithms.Length > 32) throw new global::System.ArgumentOutOfRangeException("keyDerivationAlgorithms");
            if (cryptoAlgorithms is null) throw new global::System.ArgumentNullException("cryptoAlgorithms");
            if (cryptoAlgorithms.Length > 32) throw new global::System.ArgumentOutOfRangeException("cryptoAlgorithms");
            if (hashAlgorithms is null) throw new global::System.ArgumentNullException("hashAlgorithms");
            if (hashAlgorithms.Length > 32) throw new global::System.ArgumentOutOfRangeException("hashAlgorithms");

            this.SessionId = sessionId;
            this.AuthenticationType = authenticationType;
            this.KeyExchangeAlgorithms = new global::Omnius.Core.Collections.ReadOnlyListSlim<KeyExchangeAlgorithm>(keyExchangeAlgorithms);
            this.KeyDerivationAlgorithms = new global::Omnius.Core.Collections.ReadOnlyListSlim<KeyDerivationAlgorithm>(keyDerivationAlgorithms);
            this.CryptoAlgorithms = new global::Omnius.Core.Collections.ReadOnlyListSlim<CryptoAlgorithm>(cryptoAlgorithms);
            this.HashAlgorithms = new global::Omnius.Core.Collections.ReadOnlyListSlim<HashAlgorithm>(hashAlgorithms);

            ___hashCode = new global::System.Lazy<int>(() =>
            {
                var ___h = new global::System.HashCode();
                if (!sessionId.IsEmpty) ___h.Add(global::Omnius.Core.Helpers.ObjectHelper.GetHashCode(sessionId.Span));
                if (authenticationType != default) ___h.Add(authenticationType.GetHashCode());
                foreach (var n in keyExchangeAlgorithms)
                {
                    if (n != default) ___h.Add(n.GetHashCode());
                }
                foreach (var n in keyDerivationAlgorithms)
                {
                    if (n != default) ___h.Add(n.GetHashCode());
                }
                foreach (var n in cryptoAlgorithms)
                {
                    if (n != default) ___h.Add(n.GetHashCode());
                }
                foreach (var n in hashAlgorithms)
                {
                    if (n != default) ___h.Add(n.GetHashCode());
                }
                return ___h.ToHashCode();
            });
        }

        public global::System.ReadOnlyMemory<byte> SessionId { get; }
        public AuthenticationType AuthenticationType { get; }
        public global::Omnius.Core.Collections.ReadOnlyListSlim<KeyExchangeAlgorithm> KeyExchangeAlgorithms { get; }
        public global::Omnius.Core.Collections.ReadOnlyListSlim<KeyDerivationAlgorithm> KeyDerivationAlgorithms { get; }
        public global::Omnius.Core.Collections.ReadOnlyListSlim<CryptoAlgorithm> CryptoAlgorithms { get; }
        public global::Omnius.Core.Collections.ReadOnlyListSlim<HashAlgorithm> HashAlgorithms { get; }

        public static global::Omnius.Core.Network.Connections.Secure.V1.Internal.ProfileMessage Import(global::System.Buffers.ReadOnlySequence<byte> sequence, global::Omnius.Core.IBytesPool bytesPool)
        {
            var reader = new global::Omnius.Core.RocketPack.RocketPackObjectReader(sequence, bytesPool);
            return Formatter.Deserialize(ref reader, 0);
        }
        public void Export(global::System.Buffers.IBufferWriter<byte> bufferWriter, global::Omnius.Core.IBytesPool bytesPool)
        {
            var writer = new global::Omnius.Core.RocketPack.RocketPackObjectWriter(bufferWriter, bytesPool);
            Formatter.Serialize(ref writer, this, 0);
        }

        public static bool operator ==(global::Omnius.Core.Network.Connections.Secure.V1.Internal.ProfileMessage? left, global::Omnius.Core.Network.Connections.Secure.V1.Internal.ProfileMessage? right)
        {
            return (right is null) ? (left is null) : right.Equals(left);
        }
        public static bool operator !=(global::Omnius.Core.Network.Connections.Secure.V1.Internal.ProfileMessage? left, global::Omnius.Core.Network.Connections.Secure.V1.Internal.ProfileMessage? right)
        {
            return !(left == right);
        }
        public override bool Equals(object? other)
        {
            if (!(other is global::Omnius.Core.Network.Connections.Secure.V1.Internal.ProfileMessage)) return false;
            return this.Equals((global::Omnius.Core.Network.Connections.Secure.V1.Internal.ProfileMessage)other);
        }
        public bool Equals(global::Omnius.Core.Network.Connections.Secure.V1.Internal.ProfileMessage? target)
        {
            if (target is null) return false;
            if (object.ReferenceEquals(this, target)) return true;
            if (!global::Omnius.Core.BytesOperations.Equals(this.SessionId.Span, target.SessionId.Span)) return false;
            if (this.AuthenticationType != target.AuthenticationType) return false;
            if (!global::Omnius.Core.Helpers.CollectionHelper.Equals(this.KeyExchangeAlgorithms, target.KeyExchangeAlgorithms)) return false;
            if (!global::Omnius.Core.Helpers.CollectionHelper.Equals(this.KeyDerivationAlgorithms, target.KeyDerivationAlgorithms)) return false;
            if (!global::Omnius.Core.Helpers.CollectionHelper.Equals(this.CryptoAlgorithms, target.CryptoAlgorithms)) return false;
            if (!global::Omnius.Core.Helpers.CollectionHelper.Equals(this.HashAlgorithms, target.HashAlgorithms)) return false;

            return true;
        }
        public override int GetHashCode() => ___hashCode.Value;

        private sealed class ___CustomFormatter : global::Omnius.Core.RocketPack.IRocketPackObjectFormatter<global::Omnius.Core.Network.Connections.Secure.V1.Internal.ProfileMessage>
        {
            public void Serialize(ref global::Omnius.Core.RocketPack.RocketPackObjectWriter w, in global::Omnius.Core.Network.Connections.Secure.V1.Internal.ProfileMessage value, in int rank)
            {
                if (rank > 256) throw new global::System.FormatException();

                if (!value.SessionId.IsEmpty)
                {
                    w.Write((uint)1);
                    w.Write(value.SessionId.Span);
                }
                if (value.AuthenticationType != (AuthenticationType)0)
                {
                    w.Write((uint)2);
                    w.Write((ulong)value.AuthenticationType);
                }
                if (value.KeyExchangeAlgorithms.Count != 0)
                {
                    w.Write((uint)3);
                    w.Write((uint)value.KeyExchangeAlgorithms.Count);
                    foreach (var n in value.KeyExchangeAlgorithms)
                    {
                        w.Write((ulong)n);
                    }
                }
                if (value.KeyDerivationAlgorithms.Count != 0)
                {
                    w.Write((uint)4);
                    w.Write((uint)value.KeyDerivationAlgorithms.Count);
                    foreach (var n in value.KeyDerivationAlgorithms)
                    {
                        w.Write((ulong)n);
                    }
                }
                if (value.CryptoAlgorithms.Count != 0)
                {
                    w.Write((uint)5);
                    w.Write((uint)value.CryptoAlgorithms.Count);
                    foreach (var n in value.CryptoAlgorithms)
                    {
                        w.Write((ulong)n);
                    }
                }
                if (value.HashAlgorithms.Count != 0)
                {
                    w.Write((uint)6);
                    w.Write((uint)value.HashAlgorithms.Count);
                    foreach (var n in value.HashAlgorithms)
                    {
                        w.Write((ulong)n);
                    }
                }
                w.Write((uint)0);
            }

            public global::Omnius.Core.Network.Connections.Secure.V1.Internal.ProfileMessage Deserialize(ref global::Omnius.Core.RocketPack.RocketPackObjectReader r, in int rank)
            {
                if (rank > 256) throw new global::System.FormatException();

                global::System.ReadOnlyMemory<byte> p_sessionId = global::System.ReadOnlyMemory<byte>.Empty;
                AuthenticationType p_authenticationType = (AuthenticationType)0;
                KeyExchangeAlgorithm[] p_keyExchangeAlgorithms = global::System.Array.Empty<KeyExchangeAlgorithm>();
                KeyDerivationAlgorithm[] p_keyDerivationAlgorithms = global::System.Array.Empty<KeyDerivationAlgorithm>();
                CryptoAlgorithm[] p_cryptoAlgorithms = global::System.Array.Empty<CryptoAlgorithm>();
                HashAlgorithm[] p_hashAlgorithms = global::System.Array.Empty<HashAlgorithm>();

                for (;;)
                {
                    uint id = r.GetUInt32();
                    if (id == 0) break;
                    switch (id)
                    {
                        case 1:
                            {
                                p_sessionId = r.GetMemory(32);
                                break;
                            }
                        case 2:
                            {
                                p_authenticationType = (AuthenticationType)r.GetUInt64();
                                break;
                            }
                        case 3:
                            {
                                var length = r.GetUInt32();
                                p_keyExchangeAlgorithms = new KeyExchangeAlgorithm[length];
                                for (int i = 0; i < p_keyExchangeAlgorithms.Length; i++)
                                {
                                    p_keyExchangeAlgorithms[i] = (KeyExchangeAlgorithm)r.GetUInt64();
                                }
                                break;
                            }
                        case 4:
                            {
                                var length = r.GetUInt32();
                                p_keyDerivationAlgorithms = new KeyDerivationAlgorithm[length];
                                for (int i = 0; i < p_keyDerivationAlgorithms.Length; i++)
                                {
                                    p_keyDerivationAlgorithms[i] = (KeyDerivationAlgorithm)r.GetUInt64();
                                }
                                break;
                            }
                        case 5:
                            {
                                var length = r.GetUInt32();
                                p_cryptoAlgorithms = new CryptoAlgorithm[length];
                                for (int i = 0; i < p_cryptoAlgorithms.Length; i++)
                                {
                                    p_cryptoAlgorithms[i] = (CryptoAlgorithm)r.GetUInt64();
                                }
                                break;
                            }
                        case 6:
                            {
                                var length = r.GetUInt32();
                                p_hashAlgorithms = new HashAlgorithm[length];
                                for (int i = 0; i < p_hashAlgorithms.Length; i++)
                                {
                                    p_hashAlgorithms[i] = (HashAlgorithm)r.GetUInt64();
                                }
                                break;
                            }
                    }
                }

                return new global::Omnius.Core.Network.Connections.Secure.V1.Internal.ProfileMessage(p_sessionId, p_authenticationType, p_keyExchangeAlgorithms, p_keyDerivationAlgorithms, p_cryptoAlgorithms, p_hashAlgorithms);
            }
        }
    }
    internal sealed partial class VerificationMessage : global::Omnius.Core.RocketPack.IRocketPackObject<global::Omnius.Core.Network.Connections.Secure.V1.Internal.VerificationMessage>
    {
        public static global::Omnius.Core.RocketPack.IRocketPackObjectFormatter<global::Omnius.Core.Network.Connections.Secure.V1.Internal.VerificationMessage> Formatter => global::Omnius.Core.RocketPack.IRocketPackObject<global::Omnius.Core.Network.Connections.Secure.V1.Internal.VerificationMessage>.Formatter;
        public static global::Omnius.Core.Network.Connections.Secure.V1.Internal.VerificationMessage Empty => global::Omnius.Core.RocketPack.IRocketPackObject<global::Omnius.Core.Network.Connections.Secure.V1.Internal.VerificationMessage>.Empty;

        static VerificationMessage()
        {
            global::Omnius.Core.RocketPack.IRocketPackObject<global::Omnius.Core.Network.Connections.Secure.V1.Internal.VerificationMessage>.Formatter = new ___CustomFormatter();
            global::Omnius.Core.RocketPack.IRocketPackObject<global::Omnius.Core.Network.Connections.Secure.V1.Internal.VerificationMessage>.Empty = new global::Omnius.Core.Network.Connections.Secure.V1.Internal.VerificationMessage(ProfileMessage.Empty, OmniAgreementPublicKey.Empty);
        }

        private readonly global::System.Lazy<int> ___hashCode;

        public VerificationMessage(ProfileMessage profileMessage, OmniAgreementPublicKey agreementPublicKey)
        {
            if (profileMessage is null) throw new global::System.ArgumentNullException("profileMessage");
            if (agreementPublicKey is null) throw new global::System.ArgumentNullException("agreementPublicKey");

            this.ProfileMessage = profileMessage;
            this.AgreementPublicKey = agreementPublicKey;

            ___hashCode = new global::System.Lazy<int>(() =>
            {
                var ___h = new global::System.HashCode();
                if (profileMessage != default) ___h.Add(profileMessage.GetHashCode());
                if (agreementPublicKey != default) ___h.Add(agreementPublicKey.GetHashCode());
                return ___h.ToHashCode();
            });
        }

        public ProfileMessage ProfileMessage { get; }
        public OmniAgreementPublicKey AgreementPublicKey { get; }

        public static global::Omnius.Core.Network.Connections.Secure.V1.Internal.VerificationMessage Import(global::System.Buffers.ReadOnlySequence<byte> sequence, global::Omnius.Core.IBytesPool bytesPool)
        {
            var reader = new global::Omnius.Core.RocketPack.RocketPackObjectReader(sequence, bytesPool);
            return Formatter.Deserialize(ref reader, 0);
        }
        public void Export(global::System.Buffers.IBufferWriter<byte> bufferWriter, global::Omnius.Core.IBytesPool bytesPool)
        {
            var writer = new global::Omnius.Core.RocketPack.RocketPackObjectWriter(bufferWriter, bytesPool);
            Formatter.Serialize(ref writer, this, 0);
        }

        public static bool operator ==(global::Omnius.Core.Network.Connections.Secure.V1.Internal.VerificationMessage? left, global::Omnius.Core.Network.Connections.Secure.V1.Internal.VerificationMessage? right)
        {
            return (right is null) ? (left is null) : right.Equals(left);
        }
        public static bool operator !=(global::Omnius.Core.Network.Connections.Secure.V1.Internal.VerificationMessage? left, global::Omnius.Core.Network.Connections.Secure.V1.Internal.VerificationMessage? right)
        {
            return !(left == right);
        }
        public override bool Equals(object? other)
        {
            if (!(other is global::Omnius.Core.Network.Connections.Secure.V1.Internal.VerificationMessage)) return false;
            return this.Equals((global::Omnius.Core.Network.Connections.Secure.V1.Internal.VerificationMessage)other);
        }
        public bool Equals(global::Omnius.Core.Network.Connections.Secure.V1.Internal.VerificationMessage? target)
        {
            if (target is null) return false;
            if (object.ReferenceEquals(this, target)) return true;
            if (this.ProfileMessage != target.ProfileMessage) return false;
            if (this.AgreementPublicKey != target.AgreementPublicKey) return false;

            return true;
        }
        public override int GetHashCode() => ___hashCode.Value;

        private sealed class ___CustomFormatter : global::Omnius.Core.RocketPack.IRocketPackObjectFormatter<global::Omnius.Core.Network.Connections.Secure.V1.Internal.VerificationMessage>
        {
            public void Serialize(ref global::Omnius.Core.RocketPack.RocketPackObjectWriter w, in global::Omnius.Core.Network.Connections.Secure.V1.Internal.VerificationMessage value, in int rank)
            {
                if (rank > 256) throw new global::System.FormatException();

                if (value.ProfileMessage != ProfileMessage.Empty)
                {
                    w.Write((uint)1);
                    global::Omnius.Core.Network.Connections.Secure.V1.Internal.ProfileMessage.Formatter.Serialize(ref w, value.ProfileMessage, rank + 1);
                }
                if (value.AgreementPublicKey != OmniAgreementPublicKey.Empty)
                {
                    w.Write((uint)2);
                    global::Omnius.Core.Cryptography.OmniAgreementPublicKey.Formatter.Serialize(ref w, value.AgreementPublicKey, rank + 1);
                }
                w.Write((uint)0);
            }

            public global::Omnius.Core.Network.Connections.Secure.V1.Internal.VerificationMessage Deserialize(ref global::Omnius.Core.RocketPack.RocketPackObjectReader r, in int rank)
            {
                if (rank > 256) throw new global::System.FormatException();

                ProfileMessage p_profileMessage = ProfileMessage.Empty;
                OmniAgreementPublicKey p_agreementPublicKey = OmniAgreementPublicKey.Empty;

                for (;;)
                {
                    uint id = r.GetUInt32();
                    if (id == 0) break;
                    switch (id)
                    {
                        case 1:
                            {
                                p_profileMessage = global::Omnius.Core.Network.Connections.Secure.V1.Internal.ProfileMessage.Formatter.Deserialize(ref r, rank + 1);
                                break;
                            }
                        case 2:
                            {
                                p_agreementPublicKey = global::Omnius.Core.Cryptography.OmniAgreementPublicKey.Formatter.Deserialize(ref r, rank + 1);
                                break;
                            }
                    }
                }

                return new global::Omnius.Core.Network.Connections.Secure.V1.Internal.VerificationMessage(p_profileMessage, p_agreementPublicKey);
            }
        }
    }
    internal sealed partial class AuthenticationMessage : global::Omnius.Core.RocketPack.IRocketPackObject<global::Omnius.Core.Network.Connections.Secure.V1.Internal.AuthenticationMessage>
    {
        public static global::Omnius.Core.RocketPack.IRocketPackObjectFormatter<global::Omnius.Core.Network.Connections.Secure.V1.Internal.AuthenticationMessage> Formatter => global::Omnius.Core.RocketPack.IRocketPackObject<global::Omnius.Core.Network.Connections.Secure.V1.Internal.AuthenticationMessage>.Formatter;
        public static global::Omnius.Core.Network.Connections.Secure.V1.Internal.AuthenticationMessage Empty => global::Omnius.Core.RocketPack.IRocketPackObject<global::Omnius.Core.Network.Connections.Secure.V1.Internal.AuthenticationMessage>.Empty;

        static AuthenticationMessage()
        {
            global::Omnius.Core.RocketPack.IRocketPackObject<global::Omnius.Core.Network.Connections.Secure.V1.Internal.AuthenticationMessage>.Formatter = new ___CustomFormatter();
            global::Omnius.Core.RocketPack.IRocketPackObject<global::Omnius.Core.Network.Connections.Secure.V1.Internal.AuthenticationMessage>.Empty = new global::Omnius.Core.Network.Connections.Secure.V1.Internal.AuthenticationMessage(global::System.Array.Empty<global::System.ReadOnlyMemory<byte>>());
        }

        private readonly global::System.Lazy<int> ___hashCode;

        public static readonly int MaxHashesCount = 32;

        public AuthenticationMessage(global::System.ReadOnlyMemory<byte>[] hashes)
        {
            if (hashes is null) throw new global::System.ArgumentNullException("hashes");
            if (hashes.Length > 32) throw new global::System.ArgumentOutOfRangeException("hashes");
            foreach (var n in hashes)
            {
                if (n.Length > 32) throw new global::System.ArgumentOutOfRangeException("n");
            }

            this.Hashes = new global::Omnius.Core.Collections.ReadOnlyListSlim<global::System.ReadOnlyMemory<byte>>(hashes);

            ___hashCode = new global::System.Lazy<int>(() =>
            {
                var ___h = new global::System.HashCode();
                foreach (var n in hashes)
                {
                    if (!n.IsEmpty) ___h.Add(global::Omnius.Core.Helpers.ObjectHelper.GetHashCode(n.Span));
                }
                return ___h.ToHashCode();
            });
        }

        public global::Omnius.Core.Collections.ReadOnlyListSlim<global::System.ReadOnlyMemory<byte>> Hashes { get; }

        public static global::Omnius.Core.Network.Connections.Secure.V1.Internal.AuthenticationMessage Import(global::System.Buffers.ReadOnlySequence<byte> sequence, global::Omnius.Core.IBytesPool bytesPool)
        {
            var reader = new global::Omnius.Core.RocketPack.RocketPackObjectReader(sequence, bytesPool);
            return Formatter.Deserialize(ref reader, 0);
        }
        public void Export(global::System.Buffers.IBufferWriter<byte> bufferWriter, global::Omnius.Core.IBytesPool bytesPool)
        {
            var writer = new global::Omnius.Core.RocketPack.RocketPackObjectWriter(bufferWriter, bytesPool);
            Formatter.Serialize(ref writer, this, 0);
        }

        public static bool operator ==(global::Omnius.Core.Network.Connections.Secure.V1.Internal.AuthenticationMessage? left, global::Omnius.Core.Network.Connections.Secure.V1.Internal.AuthenticationMessage? right)
        {
            return (right is null) ? (left is null) : right.Equals(left);
        }
        public static bool operator !=(global::Omnius.Core.Network.Connections.Secure.V1.Internal.AuthenticationMessage? left, global::Omnius.Core.Network.Connections.Secure.V1.Internal.AuthenticationMessage? right)
        {
            return !(left == right);
        }
        public override bool Equals(object? other)
        {
            if (!(other is global::Omnius.Core.Network.Connections.Secure.V1.Internal.AuthenticationMessage)) return false;
            return this.Equals((global::Omnius.Core.Network.Connections.Secure.V1.Internal.AuthenticationMessage)other);
        }
        public bool Equals(global::Omnius.Core.Network.Connections.Secure.V1.Internal.AuthenticationMessage? target)
        {
            if (target is null) return false;
            if (object.ReferenceEquals(this, target)) return true;
            if (!global::Omnius.Core.Helpers.CollectionHelper.Equals(this.Hashes, target.Hashes)) return false;

            return true;
        }
        public override int GetHashCode() => ___hashCode.Value;

        private sealed class ___CustomFormatter : global::Omnius.Core.RocketPack.IRocketPackObjectFormatter<global::Omnius.Core.Network.Connections.Secure.V1.Internal.AuthenticationMessage>
        {
            public void Serialize(ref global::Omnius.Core.RocketPack.RocketPackObjectWriter w, in global::Omnius.Core.Network.Connections.Secure.V1.Internal.AuthenticationMessage value, in int rank)
            {
                if (rank > 256) throw new global::System.FormatException();

                if (value.Hashes.Count != 0)
                {
                    w.Write((uint)1);
                    w.Write((uint)value.Hashes.Count);
                    foreach (var n in value.Hashes)
                    {
                        w.Write(n.Span);
                    }
                }
                w.Write((uint)0);
            }

            public global::Omnius.Core.Network.Connections.Secure.V1.Internal.AuthenticationMessage Deserialize(ref global::Omnius.Core.RocketPack.RocketPackObjectReader r, in int rank)
            {
                if (rank > 256) throw new global::System.FormatException();

                global::System.ReadOnlyMemory<byte>[] p_hashes = global::System.Array.Empty<global::System.ReadOnlyMemory<byte>>();

                for (;;)
                {
                    uint id = r.GetUInt32();
                    if (id == 0) break;
                    switch (id)
                    {
                        case 1:
                            {
                                var length = r.GetUInt32();
                                p_hashes = new global::System.ReadOnlyMemory<byte>[length];
                                for (int i = 0; i < p_hashes.Length; i++)
                                {
                                    p_hashes[i] = r.GetMemory(32);
                                }
                                break;
                            }
                    }
                }

                return new global::Omnius.Core.Network.Connections.Secure.V1.Internal.AuthenticationMessage(p_hashes);
            }
        }
    }


}