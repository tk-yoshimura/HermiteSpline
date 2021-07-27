using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace HermiteSpline.Tests {
    [TestClass()]
    public class HermiteBasicFunctionsQuinticTests {
        [TestMethod()]
        public void ValueTest() {
            Assert.AreEqual((1, 0, 0, 0, 0, 0), HermiteBasicFunctions.Quintic.Value(0));
            Assert.AreEqual((0, 0, 0, 1, 0, 0), HermiteBasicFunctions.Quintic.Value(1));
            Assert.AreEqual(0.5, HermiteBasicFunctions.Quintic.Value(0.5).hy0);
            Assert.AreEqual(0.5, HermiteBasicFunctions.Quintic.Value(0.5).hy1);
        }

        [TestMethod()]
        public void GradTest() {
            Assert.AreEqual((0, 1, 0, 0, 0, 0), HermiteBasicFunctions.Quintic.Grad(0));
            Assert.AreEqual((0, 0, 0, 0, 1, 0), HermiteBasicFunctions.Quintic.Grad(1));
        }

        [TestMethod()]
        public void SecondGradTest() {
            Assert.AreEqual((0, 0, 1, 0, 0, 0), HermiteBasicFunctions.Quintic.SecondGrad(0));
            Assert.AreEqual((0, 0, 0, 0, 0, 1), HermiteBasicFunctions.Quintic.SecondGrad(1));
        }
    }
}