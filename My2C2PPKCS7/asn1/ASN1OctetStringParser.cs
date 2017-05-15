using System.IO;

namespace My2C2P.Org.BouncyCastle.Asn1
{
	public interface Asn1OctetStringParser
		: IAsn1Convertible
	{
		Stream GetOctetStream();
	}
}
