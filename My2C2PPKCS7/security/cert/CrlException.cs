using System;

namespace My2C2P.Org.BouncyCastle.Security.Certificates
{
#if !(NETCF_1_0 || NETCF_2_0 || SILVERLIGHT || PORTABLE)
    [Serializable]
#endif
    public class CrlException : GeneralSecurityException
	{
		public CrlException() : base() { }
		public CrlException(string msg) : base(msg) {}
		public CrlException(string msg, Exception e) : base(msg, e) {}
	}
}
