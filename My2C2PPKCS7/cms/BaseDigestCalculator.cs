using System;

using My2C2P.Org.BouncyCastle.Utilities;

namespace My2C2P.Org.BouncyCastle.Cms
{
	internal class BaseDigestCalculator
		: IDigestCalculator
	{
		private readonly byte[] digest;

		internal BaseDigestCalculator(
			byte[] digest)
		{
			this.digest = digest;
		}

		public byte[] GetDigest()
		{
			return Arrays.Clone(digest);
		}
	}
}
