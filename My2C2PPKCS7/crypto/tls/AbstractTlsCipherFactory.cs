using System;
using System.IO;

namespace My2C2P.Org.BouncyCastle.Crypto.Tls
{
    public class AbstractTlsCipherFactory
        :   TlsCipherFactory
    {
        /// <exception cref="IOException"></exception>
        public virtual TlsCipher CreateCipher(TlsContext context, int encryptionAlgorithm, int macAlgorithm)
        {
            throw new TlsFatalAlert(AlertDescription.internal_error);
        }
    }
}
