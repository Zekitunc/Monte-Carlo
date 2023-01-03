using System;
using System.Collections.Generic;
using System.Text;

namespace Monte_Carlo
{
    class Randomnumber
    {
            private const long m = 4294967296; // aka 2^32
            private const long a = 1664525;
            private const long c = 1013904223;
            private long _last;

            public Randomnumber()
            {
                _last = DateTime.Now.Ticks % m;
            }

            public Randomnumber(long seed)
            {
                _last = seed;
            }

            public long Next()
            {
                _last = ((a * _last) + c) % m;

                return _last;
            }

            public long Next(long minvalue, long maxvalue)
            {
                return minvalue + Next() % (maxvalue - minvalue);
            }
    }
}
