using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace HermiteSpline.Tests {
    [TestClass()]
    public class HermiteBasicFunctionsSepticTests {
        [TestMethod()]
        public void ValueTest() {
            Assert.AreEqual((1, 0, 0, 0, 0, 0, 0, 0), HermiteBasicFunctions.Septic.Value(0));
            Assert.AreEqual((0, 0, 0, 0, 1, 0, 0, 0), HermiteBasicFunctions.Septic.Value(1));
            Assert.AreEqual(0.5, HermiteBasicFunctions.Septic.Value(0.5).hy0);
            Assert.AreEqual(0.5, HermiteBasicFunctions.Septic.Value(0.5).hy1);
        }

        [TestMethod()]
        public void GradTest() {
            Assert.AreEqual((0, 1, 0, 0, 0, 0, 0, 0), HermiteBasicFunctions.Septic.Grad(0));
            Assert.AreEqual((0, 0, 0, 0, 0, 1, 0, 0), HermiteBasicFunctions.Septic.Grad(1));
        }

        [TestMethod()]
        public void SecondGradTest() {
            Assert.AreEqual((0, 0, 1, 0, 0, 0, 0, 0), HermiteBasicFunctions.Septic.SecondGrad(0));
            Assert.AreEqual((0, 0, 0, 0, 0, 0, 1, 0), HermiteBasicFunctions.Septic.SecondGrad(1));
        }

        [TestMethod()]
        public void ThirdGradTest() {
            Assert.AreEqual((0, 0, 0, 1, 0, 0, 0, 0), HermiteBasicFunctions.Septic.ThirdGrad(0));
            Assert.AreEqual((0, 0, 0, 0, 0, 0, 0, 1), HermiteBasicFunctions.Septic.ThirdGrad(1));
        }
    }
}