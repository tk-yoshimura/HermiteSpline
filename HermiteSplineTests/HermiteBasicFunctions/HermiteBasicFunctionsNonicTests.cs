using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace HermiteSpline.Tests {
    [TestClass()]
    public class HermiteBasicFunctionsNonicTests {
        [TestMethod()]
        public void ValueTest() {
            Assert.AreEqual((1, 0, 0, 0, 0, 0, 0, 0, 0, 0), HermiteBasicFunctions.Nonic.Value(0));
            Assert.AreEqual((0, 0, 0, 0, 0, 1, 0, 0, 0, 0), HermiteBasicFunctions.Nonic.Value(1));
            Assert.AreEqual(0.5, HermiteBasicFunctions.Nonic.Value(0.5).hy0);
            Assert.AreEqual(0.5, HermiteBasicFunctions.Nonic.Value(0.5).hy1);
        }

        [TestMethod()]
        public void GradTest() {
            Assert.AreEqual((0, 1, 0, 0, 0, 0, 0, 0, 0, 0), HermiteBasicFunctions.Nonic.Grad(0));
            Assert.AreEqual((0, 0, 0, 0, 0, 0, 1, 0, 0, 0), HermiteBasicFunctions.Nonic.Grad(1));
        }

        [TestMethod()]
        public void SecondGradTest() {
            Assert.AreEqual((0, 0, 1, 0, 0, 0, 0, 0, 0, 0), HermiteBasicFunctions.Nonic.SecondGrad(0));
            Assert.AreEqual((0, 0, 0, 0, 0, 0, 0, 1, 0, 0), HermiteBasicFunctions.Nonic.SecondGrad(1));
        }

        [TestMethod()]
        public void ThirdGradTest() {
            Assert.AreEqual((0, 0, 0, 1, 0, 0, 0, 0, 0, 0), HermiteBasicFunctions.Nonic.ThirdGrad(0));
            Assert.AreEqual((0, 0, 0, 0, 0, 0, 0, 0, 1, 0), HermiteBasicFunctions.Nonic.ThirdGrad(1));
        }

        [TestMethod()]
        public void FourthGradTest() {
            Assert.AreEqual((0, 0, 0, 0, 1, 0, 0, 0, 0, 0), HermiteBasicFunctions.Nonic.FourthGrad(0));
            Assert.AreEqual((0, 0, 0, 0, 0, 0, 0, 0, 0, 1), HermiteBasicFunctions.Nonic.FourthGrad(1));
        }
    }
}