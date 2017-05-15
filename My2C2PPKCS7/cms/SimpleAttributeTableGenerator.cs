using System;
using System.Collections;

using My2C2P.Org.BouncyCastle.Asn1.Cms;

namespace My2C2P.Org.BouncyCastle.Cms
{
	/**
	 * Basic generator that just returns a preconstructed attribute table
	 */
	public class SimpleAttributeTableGenerator
		: CmsAttributeTableGenerator
	{
		private readonly AttributeTable attributes;

		public SimpleAttributeTableGenerator(
			AttributeTable attributes)
		{
			this.attributes = attributes;
		}

		public virtual AttributeTable GetAttributes(
			IDictionary parameters)
		{
			return attributes;
		}
	}
}
