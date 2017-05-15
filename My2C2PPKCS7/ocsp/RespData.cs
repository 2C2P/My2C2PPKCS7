using System;
using System.Collections;

using My2C2P.Org.BouncyCastle.Asn1;
using My2C2P.Org.BouncyCastle.Asn1.Ocsp;
using My2C2P.Org.BouncyCastle.Asn1.X509;
using My2C2P.Org.BouncyCastle.X509;

namespace My2C2P.Org.BouncyCastle.Ocsp
{
	public class RespData
		: X509ExtensionBase
	{
		internal readonly ResponseData data;

		public RespData(
			ResponseData data)
		{
			this.data = data;
		}

		public int Version
		{
			get { return data.Version.Value.IntValue + 1; }
		}

		public RespID GetResponderId()
		{
			return new RespID(data.ResponderID);
		}

		public DateTime ProducedAt
		{
			get { return data.ProducedAt.ToDateTime(); }
		}

		public SingleResp[] GetResponses()
		{
			Asn1Sequence s = data.Responses;
			SingleResp[] rs = new SingleResp[s.Count];

			for (int i = 0; i != rs.Length; i++)
			{
				rs[i] = new SingleResp(SingleResponse.GetInstance(s[i]));
			}

			return rs;
		}

		public X509Extensions ResponseExtensions
		{
			get { return data.ResponseExtensions; }
		}

		protected override X509Extensions GetX509Extensions()
		{
			return ResponseExtensions;
		}
	}
}
