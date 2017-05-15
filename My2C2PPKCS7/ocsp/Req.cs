using System;
using System.Collections;
using System.IO;

using My2C2P.Org.BouncyCastle.Asn1;
using My2C2P.Org.BouncyCastle.Asn1.Ocsp;
using My2C2P.Org.BouncyCastle.Asn1.X509;
using My2C2P.Org.BouncyCastle.X509;

namespace My2C2P.Org.BouncyCastle.Ocsp
{
	public class Req
		: X509ExtensionBase
	{
		private Request req;

		public Req(
			Request req)
		{
			this.req = req;
		}

		public CertificateID GetCertID()
		{
			return new CertificateID(req.ReqCert);
		}

		public X509Extensions SingleRequestExtensions
		{
			get { return req.SingleRequestExtensions; }
		}

		protected override X509Extensions GetX509Extensions()
		{
			return SingleRequestExtensions;
		}
	}
}
