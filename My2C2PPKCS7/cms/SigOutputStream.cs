using System;

using My2C2P.Org.BouncyCastle.Crypto;
using My2C2P.Org.BouncyCastle.Utilities.IO;
using My2C2P.Org.BouncyCastle.Security;

namespace My2C2P.Org.BouncyCastle.Cms
{
	internal class SigOutputStream
		: BaseOutputStream
	{
		private readonly ISigner sig;

		internal SigOutputStream(ISigner sig)
		{
			this.sig = sig;
		}

		public override void WriteByte(byte b)
		{
			try
			{
				sig.Update(b);
			}
			catch (SignatureException e)
			{
				throw new CmsStreamException("signature problem: " + e);
			}
		}

		public override void Write(byte[] b, int off, int len)
		{
			try
			{
				sig.BlockUpdate(b, off, len);
			}
			catch (SignatureException e)
			{
				throw new CmsStreamException("signature problem: " + e);
			}
		}
	}
}