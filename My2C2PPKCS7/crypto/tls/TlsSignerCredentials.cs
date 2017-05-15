using System;
using System.IO;

namespace My2C2P.Org.BouncyCastle.Crypto.Tls
{
    public interface TlsSignerCredentials
        :   TlsCredentials
    {
        /// <exception cref="IOException"></exception>
        byte[] GenerateCertificateSignature(byte[] hash);

        SignatureAndHashAlgorithm SignatureAndHashAlgorithm { get; }
    }
}
