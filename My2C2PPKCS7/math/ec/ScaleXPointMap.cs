using System;

namespace My2C2P.Org.BouncyCastle.Math.EC
{
    public class ScaleXPointMap
        : ECPointMap
    {
        protected readonly ECFieldElement scale;

        public ScaleXPointMap(ECFieldElement scale)
        {
            this.scale = scale;
        }

        public virtual ECPoint Map(ECPoint p)
        {
            return p.ScaleX(scale);
        }
    }
}
