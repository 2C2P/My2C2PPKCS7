using System;
using System.Security.Cryptography;
using System.Security.Cryptography.Pkcs;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace My2C2PPKCS7
{
	public class PKCS7
	{
		public PKCS7()
		{
		}

		public byte[] decryptMessage(byte[] encodedEnvelopedCms, X509Certificate2 privateCert)
		{
			byte[] content;
			try
			{
                My2C2P.Org.BouncyCastle.Crypto.AsymmetricKeyParameter key = My2C2P.Org.BouncyCastle.Security.DotNetUtilities.GetKeyPair(privateCert.PrivateKey).Private;

                var x509Certificate = My2C2P.Org.BouncyCastle.Security.DotNetUtilities.FromX509Certificate(privateCert);
                content = new My2C2P.Org.BouncyCastle.Cms.CmsEnvelopedData(encodedEnvelopedCms).GetRecipientInfos().GetFirstRecipient(new My2C2P.Org.BouncyCastle.Cms.RecipientID()
                {
                    SerialNumber = x509Certificate.SerialNumber,
                    Issuer = x509Certificate.IssuerDN
                }).GetContent(key);
                
            }
			catch (Exception exception)
			{
				content = null;
			}
			return content;
		}

		public string decryptMessage(string messageEncrypted, X509Certificate2 privateCert)
		{
			string clearMessage;
			try
			{
                My2C2P.Org.BouncyCastle.Crypto.AsymmetricKeyParameter key = My2C2P.Org.BouncyCastle.Security.DotNetUtilities.GetKeyPair(privateCert.PrivateKey).Private;

                var x509Certificate = My2C2P.Org.BouncyCastle.Security.DotNetUtilities.FromX509Certificate(privateCert);
                byte[] decBytes = new My2C2P.Org.BouncyCastle.Cms.CmsEnvelopedData(messageEncrypted.FromBase64String()).GetRecipientInfos().GetFirstRecipient(new My2C2P.Org.BouncyCastle.Cms.RecipientID()
                {
                    SerialNumber = x509Certificate.SerialNumber,
                    Issuer = x509Certificate.IssuerDN
                }).GetContent(key);

                clearMessage = decBytes.GetClearString();

            }
			catch (Exception exception)
			{
                if(exception.Message.Contains("key not valid for use in specified state"))
                {
                    clearMessage = "private key required to mark as exportable";
                }
                else
                    clearMessage = exception.ToString();
			}
			return clearMessage;
		}

		public byte[] encryptMessage(byte[] msg, X509Certificate2 publicCert)
		{
			byte[] bytes;
			try
			{
				EnvelopedCms envelopedCm = new EnvelopedCms(new ContentInfo(msg));
				envelopedCm.Encrypt(new CmsRecipient(SubjectIdentifierType.IssuerAndSerialNumber, publicCert));
				bytes = envelopedCm.Encode();
			}
			catch (Exception exception)
			{
				bytes = null;
			}
			return bytes;
		}

		public string encryptMessage(string messageToBeEncrypted, X509Certificate2 publicCert)
		{
			string base64String;
			try
			{
                var envelopGenerator = new My2C2P.Org.BouncyCastle.Cms.CmsEnvelopedDataGenerator();
                var cert = new My2C2P.Org.BouncyCastle.X509.X509CertificateParser().ReadCertificate(publicCert.RawData);
                envelopGenerator.AddKeyTransRecipient(cert);
                base64String = envelopGenerator.Generate(new My2C2P.Org.BouncyCastle.Cms.CmsProcessableByteArray(messageToBeEncrypted.GetByteArray()), My2C2P.Org.BouncyCastle.Cms.CmsEnvelopedGenerator.DesEde3Cbc)
                        .GetEncoded().GetBase64String();

            }
			catch (Exception exception)
			{
				base64String = exception.ToString();
			}
			return base64String;
		}

		public byte[] ExtractEnvelopedData(byte[] signature)
		{
			if (signature == null)
			{
				throw new ArgumentNullException("signature");
			}
			SignedCms signedCm = new SignedCms();
			signedCm.Decode(signature);
			if (signedCm.Detached)
			{
				throw new InvalidOperationException("Cannot extract enveloped content from a detached signature.");
			}
			return signedCm.ContentInfo.Content;
		}

		public X509Certificate2 getPrivateCert(string cerFileLoc, string cerFilePwd)
		{
			X509Certificate2 x509Certificate2 = null;
			try
			{
				x509Certificate2 = new X509Certificate2(cerFileLoc, cerFilePwd, X509KeyStorageFlags.MachineKeySet
                    | X509KeyStorageFlags.Exportable);
			}
			catch (Exception exception)
			{
			}
			return x509Certificate2;
		}

		public X509Certificate2 getPublicCert(string cerFileLoc)
		{
			X509Certificate2 x509Certificate2 = null;
			try
			{
				x509Certificate2 = new X509Certificate2(cerFileLoc);
			}
			catch (Exception exception)
			{
			}
			return x509Certificate2;
		}

		public X509Certificate2 getPublicCertWithBase64(string base64String)
		{
			X509Certificate2 x509Certificate2 = null;
			try
			{
				x509Certificate2 = new X509Certificate2(base64String.GetByteArray());
			}
			catch (Exception exception)
			{
			}
			return x509Certificate2;
		}

		public byte[] signMessage(byte[] data, X509Certificate2 privateCert)
		{
			byte[] numArray;
			try
			{
				if (data == null)
				{
					throw new ArgumentNullException("data");
				}
				if (privateCert == null)
				{
					throw new ArgumentNullException("privateCertificate");
				}
				SignedCms signedCm = new SignedCms(new ContentInfo(data));
				signedCm.ComputeSignature(new CmsSigner(SubjectIdentifierType.IssuerAndSerialNumber, privateCert));
				numArray = signedCm.Encode();
			}
			catch (Exception exception)
			{
				numArray = null;
			}
			return numArray;
		}

		public bool verifyMessage(byte[] signature, X509Certificate2 publicCert, out byte[] decodedMessage)
		{
			bool flag;
			decodedMessage = null;
			if (signature == null)
			{
				throw new ArgumentNullException("signature");
			}
			if (publicCert == null)
			{
				throw new ArgumentNullException("publicCertificate");
			}
			SignedCms signedCm = new SignedCms();
			try
			{
				signedCm.Decode(signature);
				signedCm.CheckSignature(new X509Certificate2Collection(publicCert), false);
				decodedMessage = signedCm.ContentInfo.Content;
				flag = true;
			}
			catch (CryptographicException cryptographicException)
			{
				flag = false;
			}
			return flag;
		}
	}
}