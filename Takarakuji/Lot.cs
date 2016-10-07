using System.Collections.Generic;

namespace Takarakuji
{
    public class Lot<T>
    {
        private List<T> xs = new List<T>();
        private Xorshift random = new Xorshift();

        public void Add(T x, int count = 1)
        {
            for (var i = 0; i < count; i++)
            {
                xs.Add(x);
            }
        }

        public void Remove(T x)
        {
            xs.RemoveAll(_x => EqualityComparer<T>.Default.Equals(x, _x));
        }

        public int Total()
        {
            return xs.Count;
        }

        public T Draw(bool removeIt = true)
        {
            var idx = random.Range(0, (uint)xs.Count);
            var x = xs[(int)idx];
            if (removeIt)
            {
                xs.RemoveAt((int)idx);
            }
            return x;
        }
    }

    public class Xorshift
    {
        private uint x = 123456789;
        private uint y = 362436069;
        private uint z = 521288629;
        private uint w = 88675123;

        public void Seed(uint x, uint y, uint z, uint w)
        {
            this.x = x;
            this.y = y;
            this.z = z;
            this.w = w;
        }

        public uint Next()
        {
            uint t = x ^ (x << 11);
            x = y;
            y = z;
            z = w;
            w = (w ^ (w >> 19)) ^ (t ^ (t >> 8));
            return w;
        }

        public uint Range(uint min, uint max)
        {
            return min + Next() % (max - min);
        }
    }
}