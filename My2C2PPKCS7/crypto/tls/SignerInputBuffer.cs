using System;
using System.IO;

using My2C2P.Org.BouncyCastle.Crypto;
using My2C2P.Org.BouncyCastle.Crypto.IO;
using My2C2P.Org.BouncyCastle.Utilities.IO;

namespace My2C2P.Org.BouncyCastle.Crypto.Tls
{
    internal class SignerInputBuffer
        : MemoryStream
    {
        internal void UpdateSigner(ISigner s)
        {
            WriteTo(new SigStream(s));
        }

        private class SigStream
            : BaseOutputStream
        {
            private readonly ISigner s;

            internal SigStream(ISigner s)
            {
                this.s = s;
            }

            public override void WriteByte(byte b)
            {
                s.Update(b);
            }

            public override void Write(byte[] buf, int off, int len)
            {
                s.BlockUpdate(buf, off, len);
            }
        }
    }
}
