using System;

namespace My2C2P.Org.BouncyCastle.Crypto.Tls
{
    public interface TlsSession
    {
        SessionParameters ExportSessionParameters();

        byte[] SessionID { get; }

        void Invalidate();

        bool IsResumable { get; }
    }
}
