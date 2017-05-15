using System;
using System.IO;

namespace My2C2P.Org.BouncyCastle.Crypto.Tls
{
    public abstract class AbstractTlsSignerCredentials
        : AbstractTlsCredentials, TlsSignerCredentials
    {
        /// <exception cref="IOException"></exception>
        public abstract byte[] GenerateCertificateSignature(byte[] hash);

        public virtual SignatureAndHashAlgorithm SignatureAndHashAlgorithm
        {
            get
            {
                throw new InvalidOperationException("TlsSignerCredentials implementation does not support (D)TLS 1.2+");
            }
        }
    }
}
