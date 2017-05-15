using System;

namespace My2C2P.Org.BouncyCastle.Crypto.Tls
{
	public interface TlsCredentials
	{
		Certificate Certificate { get; }
	}
}
