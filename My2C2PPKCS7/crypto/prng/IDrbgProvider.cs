using System;

using My2C2P.Org.BouncyCastle.Crypto.Prng.Drbg;

namespace My2C2P.Org.BouncyCastle.Crypto.Prng
{
    internal interface IDrbgProvider
    {
        ISP80090Drbg Get(IEntropySource entropySource);
    }
}
