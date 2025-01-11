using MyMath;
using NUnit.Framework;

namespace MyMath.Tests{

    /// <summary>
    /// Tests class
    /// </summary>
    [TestFixture]
    public class Tests
    {
        /// <summary>
        /// Test sum of two positive numbers
        /// </summary>
        [Test]
        public void Sum2()
        {
            Assert.That(Operations.Add(4, 7), Is.EqualTo(11));
        }

        /// <summary>
        /// test the sum of a min and max value
        /// </summary>
        [Test]
        public void SumMinMax()
        {
            int min = int.MinValue;
            int max = int.MaxValue;
            Assert.That(Operations.Add(min, max), Is.EqualTo(min + max));
        }

        /// <summary>
        /// test the sum of a negative number 
        /// </summary>
        [Test]
        public void SumNegative()
        {
            Assert.That(Operations.Add(10, -3), Is.EqualTo(7));
        }

        /// <summary>
        /// test the sum of zeros
        /// </summary>
        [Test]
        public void SumZero()
        {
            Assert.That(Operations.Add(0, 0), Is.EqualTo(0));
        }
    }
}
