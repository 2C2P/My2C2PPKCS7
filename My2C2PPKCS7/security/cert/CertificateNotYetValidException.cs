using System;

namespace My2C2P.Org.BouncyCastle.Security.Certificates
{
#if !(NETCF_1_0 || NETCF_2_0 || SILVERLIGHT || PORTABLE)
    [Serializable]
#endif
    public class CertificateNotYetValidException : CertificateException
	{
		public CertificateNotYetValidException() : base() { }
		public CertificateNotYetValidException(string message) : base(message) { }
		public CertificateNotYetValidException(string message, Exception exception) : base(message, exception) { }
	}
}
