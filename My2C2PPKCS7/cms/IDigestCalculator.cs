using System;

namespace My2C2P.Org.BouncyCastle.Cms
{
	internal interface IDigestCalculator
	{
		byte[] GetDigest();
	}
}
