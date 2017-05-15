using System;

namespace My2C2P.Org.BouncyCastle.Crypto.Modes.Gcm
{
	public interface IGcmMultiplier
	{
		void Init(byte[] H);
		void MultiplyH(byte[] x);
	}
}
