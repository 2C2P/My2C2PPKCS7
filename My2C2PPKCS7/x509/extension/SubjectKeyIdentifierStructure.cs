using System;

using My2C2P.Org.BouncyCastle.Asn1;
using My2C2P.Org.BouncyCastle.Asn1.X509;
using My2C2P.Org.BouncyCastle.Crypto;
using My2C2P.Org.BouncyCastle.Security.Certificates;

namespace My2C2P.Org.BouncyCastle.X509.Extension
{
	/**
	 * A high level subject key identifier.
	 */
	public class SubjectKeyIdentifierStructure
		: SubjectKeyIdentifier
	{
		/**
		 * Constructor which will take the byte[] returned from getExtensionValue()
		 *
		 * @param encodedValue a DER octet encoded string with the extension structure in it.
		 * @throws IOException on parsing errors.
		 */
		public SubjectKeyIdentifierStructure(
			Asn1OctetString encodedValue)
			: base((Asn1OctetString) X509ExtensionUtilities.FromExtensionValue(encodedValue))
		{
		}

		private static Asn1OctetString FromPublicKey(
			AsymmetricKeyParameter pubKey)
		{
			try
			{
				SubjectPublicKeyInfo info = SubjectPublicKeyInfoFactory.CreateSubjectPublicKeyInfo(pubKey);

				return (Asn1OctetString) new SubjectKeyIdentifier(info).ToAsn1Object();
			}
			catch (Exception e)
			{
				throw new CertificateParsingException("Exception extracting certificate details: " + e.ToString());
			}
		}

		public SubjectKeyIdentifierStructure(
			AsymmetricKeyParameter pubKey)
			: base(FromPublicKey(pubKey))
		{
		}
	}
}
