using System;
using System.IO;

using My2C2P.Org.BouncyCastle.Asn1;
using My2C2P.Org.BouncyCastle.Asn1.X509;
using My2C2P.Org.BouncyCastle.Crypto;
using My2C2P.Org.BouncyCastle.Crypto.Parameters;
using My2C2P.Org.BouncyCastle.Security;
using My2C2P.Org.BouncyCastle.Utilities.Date;
using My2C2P.Org.BouncyCastle.Utilities.IO;

namespace My2C2P.Org.BouncyCastle.Cms
{
	public class CmsAuthenticatedGenerator
		: CmsEnvelopedGenerator
	{
		/**
		* base constructor
		*/
		public CmsAuthenticatedGenerator()
		{
		}

		/**
		* constructor allowing specific source of randomness
		*
		* @param rand instance of SecureRandom to use
		*/
		public CmsAuthenticatedGenerator(
			SecureRandom rand)
			: base(rand)
		{
		}
	}
}
