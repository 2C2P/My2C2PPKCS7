using System;

using My2C2P.Org.BouncyCastle.Asn1.Cms;
using My2C2P.Org.BouncyCastle.Crypto.Parameters;
using My2C2P.Org.BouncyCastle.Security;

namespace My2C2P.Org.BouncyCastle.Cms
{
	interface RecipientInfoGenerator
	{
		/// <summary>
		/// Generate a RecipientInfo object for the given key.
		/// </summary>
		/// <param name="contentEncryptionKey">
		/// A <see cref="KeyParameter"/>
		/// </param>
		/// <param name="random">
		/// A <see cref="SecureRandom"/>
		/// </param>
		/// <returns>
		/// A <see cref="RecipientInfo"/>
		/// </returns>
		/// <exception cref="GeneralSecurityException"></exception>
		RecipientInfo Generate(KeyParameter contentEncryptionKey, SecureRandom random);
	}
}
