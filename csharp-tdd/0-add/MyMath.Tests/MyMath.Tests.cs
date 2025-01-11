using MyMath;
using NUnit.Framework;

namespace MyMath.Tests
{
    [TestFixture]
    public class Tests
    {
        ///<summarry>
        ///test a normal sum
        ///</summary>
        [Test]
        public void Sum2()
        {
            Assert.That(Operations.Add(1, 5), Is.EqualTo(6));
        }

        ///<summarry>
        ///test a min Value plus max value
        ///</summary>
        [Test]
        public void SumMinAndMax()
        {
            int min = int.MinValue;
            int max = int.MaxValue;
            Assert.That(Operations.Add(min, max), Is.EqualTo(min + max));
        }
        ///<summarry>
        ///test a sum with a negative
        ///</summary>
        [Test]
        public void SumNegative()
        {
            Assert.That(Operations.Add(-15, 20), Is.EqualTo(-15 + 20));
        }
        ///<summarry>
        ///test a sum with zero
        ///</summary>
        [Test]
        public void SumZero()
        {
            Assert.That(Operations.Add(0, 0), Is.EqualTo(0));
        }
    }
}