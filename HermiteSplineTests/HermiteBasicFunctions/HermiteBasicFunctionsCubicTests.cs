using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace HermiteSpline.Tests {
    [TestClass()]
    public class HermiteBasicFunctionsCubicTests {
        [TestMethod()]
        public void ValueTest() {
            Assert.AreEqual((1, 0, 0, 0), HermiteBasicFunctions.Cubic.Value(0));
            Assert.AreEqual((0, 0, 1, 0), HermiteBasicFunctions.Cubic.Value(1));
            Assert.AreEqual(0.5, HermiteBasicFunctions.Cubic.Value(0.5).hy0);
            Assert.AreEqual(0.5, HermiteBasicFunctions.Cubic.Value(0.5).hy1);
        }

        [TestMethod()]
        public void GradTest() {
            Assert.AreEqual((0, 1, 0, 0), HermiteBasicFunctions.Cubic.Grad(0));
            Assert.AreEqual((0, 0, 0, 1), HermiteBasicFunctions.Cubic.Grad(1));
        }
    }
}