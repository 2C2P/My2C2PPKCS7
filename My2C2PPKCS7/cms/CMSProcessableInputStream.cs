using System;
using System.IO;

using My2C2P.Org.BouncyCastle.Utilities;
using My2C2P.Org.BouncyCastle.Utilities.IO;

namespace My2C2P.Org.BouncyCastle.Cms
{
	public class CmsProcessableInputStream
		: CmsProcessable, CmsReadable
	{
		private readonly Stream input;

        private bool used = false;

        public CmsProcessableInputStream(Stream input)
		{
			this.input = input;
		}

        public virtual Stream GetInputStream()
		{
			CheckSingleUsage();

            return input;
		}

        public virtual void Write(Stream output)
		{
			CheckSingleUsage();

			Streams.PipeAll(input, output);
            Platform.Dispose(input);
		}

        [Obsolete]
		public virtual object GetContent()
		{
			return GetInputStream();
		}

        protected virtual void CheckSingleUsage()
		{
			lock (this)
			{
				if (used)
					throw new InvalidOperationException("CmsProcessableInputStream can only be used once");

                used = true;
			}
		}
	}
}
