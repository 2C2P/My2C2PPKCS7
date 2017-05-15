using System;

using My2C2P.Org.BouncyCastle.Asn1;
using My2C2P.Org.BouncyCastle.Asn1.Ocsp;
using My2C2P.Org.BouncyCastle.Asn1.X509;
using My2C2P.Org.BouncyCastle.Crypto;
using My2C2P.Org.BouncyCastle.Security;
using My2C2P.Org.BouncyCastle.X509;

namespace My2C2P.Org.BouncyCastle.Ocsp
{
	/**
	 * Carrier for a ResponderID.
	 */
	public class RespID
	{
		internal readonly ResponderID id;

		public RespID(
			ResponderID id)
		{
			this.id = id;
		}

		public RespID(
			X509Name name)
		{
	        this.id = new ResponderID(name);
		}

		public RespID(
			AsymmetricKeyParameter publicKey)
		{
			try
			{
				SubjectPublicKeyInfo info = SubjectPublicKeyInfoFactory.CreateSubjectPublicKeyInfo(publicKey);

				byte[] keyHash = DigestUtilities.CalculateDigest("SHA1", info.PublicKeyData.GetBytes());

				this.id = new ResponderID(new DerOctetString(keyHash));
			}
			catch (Exception e)
			{
				throw new OcspException("problem creating ID: " + e, e);
			}
		}

		public ResponderID ToAsn1Object()
		{
			return id;
		}

		public override bool Equals(
			object obj)
		{
			if (obj == this)
				return true;

			RespID other = obj as RespID;

			if (other == null)
				return false;

			return id.Equals(other.id);
		}

		public override int GetHashCode()
		{
			return id.GetHashCode();
		}
	}
}
