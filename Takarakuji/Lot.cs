using System.Collections.Generic;

namespace Takarakuji
{
    public class Lot<T>
    {
        private readonly List<T> _xs = new List<T>();
        private readonly Xorshift _random;

        public Lot(Xorshift random)
        {
            _random = random ?? Xorshift.Default;
        }
        public void Add(T x, int count = 1)
        {
            for (var i = 0; i < count; i++)
            {
                _xs.Add(x);
            }
        }

        public void Remove(T x)
        {
            _xs.RemoveAll(e => EqualityComparer<T>.Default.Equals(x, e));
        }

        public void Clear()
        {
            _xs.RemoveAll(x => true);
        }

        public int Total()
        {
            return _xs.Count;
        }

        public T Draw(bool removeIt = true)
        {
            var idx = _random.Range(0, (uint)_xs.Count);
            var x = _xs[(int)idx];
            if (removeIt)
            {
                _xs.RemoveAt((int)idx);
            }
            return x;
        }
    }

    public class Xorshift
    {
        private uint _x = 123456789;
        private uint _y = 362436069;
        private uint _z = 521288629;
        private uint _w = 88675123;

        public static Xorshift Default = new Xorshift();

        public void Seed(uint? x, uint? y, uint? z, uint w)
        {
            if (x != null) _x = x.Value;
            if (y != null) _y = y.Value;
            if (z != null) _z = z.Value;
            _w = w;
        }

        public uint Next()
        {
            var t = _x ^ (_x << 11);
            _x = _y;
            _y = _z;
            _z = _w;
            _w = (_w ^ (_w >> 19)) ^ (t ^ (t >> 8));
            return _w;
        }

        public uint Range(uint min, uint max)
        {
            return min + Next() % (max - min);
        }
    }
}
