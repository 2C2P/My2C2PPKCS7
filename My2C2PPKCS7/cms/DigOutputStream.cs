using System;

using My2C2P.Org.BouncyCastle.Crypto;
using My2C2P.Org.BouncyCastle.Utilities.IO;

namespace My2C2P.Org.BouncyCastle.Cms
{
	internal class DigOutputStream
		: BaseOutputStream
	{
		private readonly IDigest dig;

		internal DigOutputStream(IDigest dig)
		{
			this.dig = dig;
		}

		public override void WriteByte(byte b)
		{
			dig.Update(b);
		}

		public override void Write(byte[] b, int off, int len)
		{
			dig.BlockUpdate(b, off, len);
		}
	}
}
