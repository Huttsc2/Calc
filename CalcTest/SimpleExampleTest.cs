using Calc;

namespace CalcTest
{
    [TestClass]
    public class SimpleExampleTest
    {
        
        [TestMethod]
        public void FirstNumner()
        {
            SimpleExample exampleString =  new SimpleExample("-3.2+5.3");
            Assert.AreEqual(exampleString.x, -3.2);
        }

        [TestMethod]
        public void SecondNumner()
        {
            SimpleExample exampleString = new SimpleExample("-3.2+5.3");
            Assert.AreEqual(exampleString.y, 5.3);
        }

        [TestMethod]
        public void SecondNumnerBrackets()
        {
            SimpleExample exampleString = new SimpleExample("-3.2+(-5.3)");
            Assert.AreEqual(exampleString.y, -5.3);
        }

        [TestMethod]
        public void AnswerAddition()
        {
            SimpleExample exampleString = new SimpleExample("-3.2+(-5.3)");
            Assert.AreEqual(exampleString.answer, "-8,5");
        }

        [TestMethod]
        public void AnswerSubtraction()
        {
            SimpleExample exampleString = new SimpleExample("-3.2-(-5.3)");
            Assert.AreEqual(exampleString.answer, "2,1");
        }

        [TestMethod]
        public void AnswerMultiplicationt()
        {
            SimpleExample exampleString = new SimpleExample("-3.2*(-5.3)");
            Assert.AreEqual(exampleString.answer, "16,96");
        }

        [TestMethod]
        public void AnswerDivision()
        {
            SimpleExample exampleString = new SimpleExample("-5.2/(-1.3)");
            Assert.AreEqual(exampleString.answer, "4");
        }
        [TestMethod]
        public void Addition()
        {
            SimpleExample exampleString = new SimpleExample("-3.2+(-5.3)");
            Assert.IsTrue(exampleString.isPlus);
            Assert.IsFalse(exampleString.isMinus);
            Assert.IsFalse(exampleString.isDivision);
            Assert.IsFalse(exampleString.isMultiplication);
        }

        [TestMethod]
        public void Subtraction()
        {
            SimpleExample exampleString = new SimpleExample("3.2-5.3");
            Assert.IsFalse(exampleString.isPlus);
            Assert.IsTrue(exampleString.isMinus);
            Assert.IsFalse(exampleString.isDivision);
            Assert.IsFalse(exampleString.isMultiplication);
        }

        [TestMethod]
        public void Multiplicationt()
        {
            SimpleExample exampleString = new SimpleExample("3.2*5.3");
            Assert.IsFalse(exampleString.isPlus);
            Assert.IsFalse(exampleString.isMinus);
            Assert.IsFalse(exampleString.isDivision);
            Assert.IsTrue(exampleString.isMultiplication);
        }

        [TestMethod]
        public void Division()
        {
            SimpleExample exampleString = new SimpleExample("3.2/5.3");
            Assert.IsFalse(exampleString.isPlus);
            Assert.IsFalse(exampleString.isMinus);
            Assert.IsTrue(exampleString.isDivision);
            Assert.IsFalse(exampleString.isMultiplication);
        }
    }
}