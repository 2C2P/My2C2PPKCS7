using System;

namespace My2C2P.Org.BouncyCastle.Asn1
{
	public class BerApplicationSpecific
		: DerApplicationSpecific
	{
		public BerApplicationSpecific(
			int					tagNo,
			Asn1EncodableVector	vec)
			: base(tagNo, vec)
		{
		}
	}
}
