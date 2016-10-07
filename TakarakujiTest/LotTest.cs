using System;
using NUnit.Framework;
using Takarakuji;

namespace TakarakujiTest
{
    [TestFixture]
    public class XorshiftTest
    {
        [Test()]
        [TestCase((uint)1, (uint)2)]
        [TestCase((uint)1, (uint)500)]
        [TestCase((uint)200, (uint)202)]
        [TestCase((uint)2800, (uint)3000)]
        public void TestEval(uint min, uint max)
        {
            var random = new Xorshift();
            for (var i = 0; i <= 100; i++)
            {
                Assert.GreaterOrEqual(random.Range(min, max), min);
                Assert.Less(random.Range(min, max), max);
            }
        }
    }
}

