using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reliquae.Utilities
{
    public static class MathHelper
    {
        public static int Hash(int x, int y)
        {
            int result = x;
            result *= 234234 | 1;
            result += 2233454;
            result = (result >> 16) + (result << 16);
            result ^= 234234;
            result += y;
            result *= 234234 | 1;
            result += 342342;
            result = (result >> 16) + (result << 16);
            result ^= 594893874;
            result *= 98438493 | 1;

            return result;
        }
    }
}
