using System;
using System.Collections;
using System.IO;
using System.Text;

using My2C2P.Org.BouncyCastle.Asn1;
using My2C2P.Org.BouncyCastle.Asn1.X509;
using My2C2P.Org.BouncyCastle.Crypto.Agreement;
using My2C2P.Org.BouncyCastle.Crypto.Agreement.Srp;
using My2C2P.Org.BouncyCastle.Crypto.Digests;
using My2C2P.Org.BouncyCastle.Crypto.Encodings;
using My2C2P.Org.BouncyCastle.Crypto.Engines;
using My2C2P.Org.BouncyCastle.Crypto.Generators;
using My2C2P.Org.BouncyCastle.Crypto.IO;
using My2C2P.Org.BouncyCastle.Crypto.Parameters;
using My2C2P.Org.BouncyCastle.Crypto.Prng;
using My2C2P.Org.BouncyCastle.Math;
using My2C2P.Org.BouncyCastle.Security;
using My2C2P.Org.BouncyCastle.Utilities;
using My2C2P.Org.BouncyCastle.Utilities.Date;

namespace My2C2P.Org.BouncyCastle.Crypto.Tls
{
    [Obsolete("Use 'TlsClientProtocol' instead")]
    public class TlsProtocolHandler
        :   TlsClientProtocol
    {
        public TlsProtocolHandler(Stream stream, SecureRandom secureRandom)
            :   base(stream, stream, secureRandom)
        {
        }

        /// <remarks>Both streams can be the same object</remarks>
        public TlsProtocolHandler(Stream input, Stream output, SecureRandom	secureRandom)
            :   base(input, output, secureRandom)
        {
        }
    }
}
