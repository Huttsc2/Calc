using Calc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalcTest
{
    [TestClass]
    public class ExampleInBracketsTest
    {
        [TestMethod]
        public void SinglPositiveTrue()
        {
            ExampleInBrackets exampleInBrackets = new("3+(9+6)+7");
            Assert.IsTrue(exampleInBrackets.isSinglePositive);
        }
    }
}
