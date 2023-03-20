using Calc;

namespace CalcTest
{
    [TestClass]
    public class ReplaceMethodTest
    {
        [TestMethod]
        public void FirstPriorityMultiplication()
        {
            ReplaceMethod replaceMethod = new ReplaceMethod("5+1*3");
            Assert.IsTrue(replaceMethod.isFirstPriority);
        }

        [TestMethod]
        public void FirstPriorityDivision()
        {
            ReplaceMethod replaceMethod = new ReplaceMethod("5+1/3");
            Assert.IsTrue(replaceMethod.isFirstPriority);
        }

        [TestMethod]
        public void SecondPriority()
        {
            ReplaceMethod replaceMethod = new ReplaceMethod("5+1-3");
            Assert.IsFalse(replaceMethod.isFirstPriority);
        }

        [TestMethod]
        public void ShortFirstPriority()
        {
            ReplaceMethod replaceMethod = new ReplaceMethod("5-11*(-12.1)+11*(-12.1)");
            string expected = "11*(-12,1)";
            Assert.AreEqual(expected, replaceMethod.shortExample);
        }

        [TestMethod]
        public void ShortFirstPriorityMinus()
        {
            ReplaceMethod replaceMethod = new ReplaceMethod("-1.1*(-12.1)+11*(-12.1)");
            string expected = "-1,1*(-12,1)";
            Assert.AreEqual(expected, replaceMethod.shortExample);
        }

        [TestMethod]
        public void ShortSecondPriorityMinus()
        {
            ReplaceMethod replaceMethod = new ReplaceMethod("-1.1+(-12.1)+11-(-12.1)");
            string expected = "-1,1+(-12,1)";
            Assert.AreEqual(expected, replaceMethod.shortExample);
        }

        [TestMethod]
        public void ShortSecondPriorityt()
        {
            ReplaceMethod replaceMethod = new ReplaceMethod("11+12.1+11-(-12.1)");
            string expected = "11+12,1";
            Assert.AreEqual(expected, replaceMethod.shortExample);
        }

        [TestMethod]
        public void Replace()
        {
            ReplaceMethod replaceMethod = new ReplaceMethod("-1.1+12.1*(-2)-(-12.1)");
            string expected = "-1,1+(-24,2)-(-12,1)";
            Assert.AreEqual(expected, replaceMethod.newFullExample);
        }

        [TestMethod]
        public void DecidedNegativ()
        {
            ReplaceMethod replaceMethod = new ReplaceMethod("11+(-12.1)+11-(-12.1)");
            string expected = "(-1,1)";
            Assert.AreEqual(expected, replaceMethod.decidedShortExample);
        }

        [TestMethod]
        public void DecidedPositiv()
        {
            ReplaceMethod replaceMethod = new ReplaceMethod("11+12.1+11-(-12.1)");
            string expected = "23,1";
            Assert.AreEqual(expected, replaceMethod.decidedShortExample);
        }

        [TestMethod]
        public void NegativeNumber()
        {
            ReplaceMethod replaceMethod = new ReplaceMethod("1-5");
            Assert.IsTrue(replaceMethod.isNegative);
        }

        [TestMethod]
        public void PositiveNumber()
        {
            ReplaceMethod replaceMethod = new ReplaceMethod("1+5");
            Assert.IsFalse(replaceMethod.isNegative);
        }
    }
}
