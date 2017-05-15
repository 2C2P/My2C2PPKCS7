using System;
using System.IO;

namespace My2C2P.Org.BouncyCastle.Crypto.Tls
{
	public interface TlsCompression
	{
		Stream Compress(Stream output);

		Stream Decompress(Stream output);
	}
}
