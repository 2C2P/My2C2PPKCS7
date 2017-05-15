using System;
using System.IO;

namespace My2C2P.Org.BouncyCastle.Cms
{
	public interface CmsReadable
	{
		Stream GetInputStream();
	}
}
