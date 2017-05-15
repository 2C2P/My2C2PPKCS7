using System;

using My2C2P.Org.BouncyCastle.Crypto;
using My2C2P.Org.BouncyCastle.Security;

namespace My2C2P.Org.BouncyCastle.Cms
{
	internal class CounterSignatureDigestCalculator
		: IDigestCalculator
	{
		private readonly string alg;
		private readonly byte[] data;

		internal CounterSignatureDigestCalculator(
			string	alg,
			byte[]	data)
		{
			this.alg = alg;
			this.data = data;
		}

		public byte[] GetDigest()
		{
			IDigest digest = CmsSignedHelper.Instance.GetDigestInstance(alg);
			return DigestUtilities.DoFinal(digest, data);
		}
	}
}
