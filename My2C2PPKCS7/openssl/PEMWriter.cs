using System;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Text;

using My2C2P.Org.BouncyCastle.Asn1;
using My2C2P.Org.BouncyCastle.Asn1.CryptoPro;
using My2C2P.Org.BouncyCastle.Asn1.Pkcs;
using My2C2P.Org.BouncyCastle.Asn1.X509;
using My2C2P.Org.BouncyCastle.Asn1.X9;
using My2C2P.Org.BouncyCastle.Crypto;
using My2C2P.Org.BouncyCastle.Crypto.Generators;
using My2C2P.Org.BouncyCastle.Crypto.Parameters;
using My2C2P.Org.BouncyCastle.Math;
using My2C2P.Org.BouncyCastle.Pkcs;
using My2C2P.Org.BouncyCastle.Security;
using My2C2P.Org.BouncyCastle.Security.Certificates;
using My2C2P.Org.BouncyCastle.Utilities.Encoders;
using My2C2P.Org.BouncyCastle.Utilities.IO.Pem;
using My2C2P.Org.BouncyCastle.X509;

namespace My2C2P.Org.BouncyCastle.OpenSsl
{
	/// <remarks>General purpose writer for OpenSSL PEM objects.</remarks>
	public class PemWriter
		: Org.BouncyCastle.Utilities.IO.Pem.PemWriter
	{
		/// <param name="writer">The TextWriter object to write the output to.</param>
		public PemWriter(
			TextWriter writer)
			: base(writer)
		{
		}

		public void WriteObject(
			object obj) 
		{
			try
			{
				base.WriteObject(new MiscPemGenerator(obj));
			}
			catch (PemGenerationException e)
			{
				if (e.InnerException is IOException)
					throw (IOException)e.InnerException;

				throw e;
			}
		}

		public void WriteObject(
			object			obj,
			string			algorithm,
			char[]			password,
			SecureRandom	random)
		{
			base.WriteObject(new MiscPemGenerator(obj, algorithm, password, random));
		}
	}
}
