using NUnit.Framework.Constraints;
using System.Numerics;

namespace ComplexStruct.UnitTests
{
    [TestFixture]
    public class ComplexTests
    {
        [Test]
        public void ConstructorTest()
        {
            var complex = new Complex(1, 2);

            Assert.That(complex.Re, Is.EqualTo(1));
            Assert.That(complex.Im, Is.EqualTo(2));

        }
        [TestCase(1, 2, "1 + 2i")]
        public void ToStringtest(double re, double im, string result)
        {
            var complex = new Complex(re, im);

            Assert.That(complex.ToString(), Is.EqualTo(result));
        }
        [TestCase(1,2, 2.236)]
        public void AbsTest(double re, double im, double result)
        {
            var complex = new Complex(re,im);

            Assert.That(complex.Abs, Is.EqualTo(result));           
        }
        [TestCase(1, 2, 1, 2, "3 + 3i", "-1 - i")]
        public void ComplexTest(double re1, double re2, double im1, double im2, string resultSum, string resultDes)
        {
            var cn1 = new Complex(re1, im1);
            var cn2 = new Complex(re2, im2);


            Assert.That($"{cn1 + cn2}", Is.EqualTo(resultSum));
            Assert.That($"{cn1 - cn2}", Is.EqualTo(resultDes));
        }
    }

}