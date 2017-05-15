using System;
using System.IO;

namespace My2C2P.Org.BouncyCastle.Crypto.Tls
{
    public interface TlsCipherFactory
    {
        /// <exception cref="IOException"></exception>
        TlsCipher CreateCipher(TlsContext context, int encryptionAlgorithm, int macAlgorithm);
    }
}
