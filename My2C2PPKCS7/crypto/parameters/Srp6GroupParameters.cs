using System;

using My2C2P.Org.BouncyCastle.Math;

namespace My2C2P.Org.BouncyCastle.Crypto.Parameters
{
    public sealed class Srp6GroupParameters
    {
        private readonly BigInteger n, g;

        public Srp6GroupParameters(BigInteger N, BigInteger g)
        {
            this.n = N;
            this.g = g;
        }

        public BigInteger G
        {
            get { return g; }
        }

        public BigInteger N
        {
            get { return n; }
        }
    }
}
