using System.Linq;

namespace HermiteSpline.Tests {
    static class TestCases {
        public static (double[] xs, double[] ys, double[] ps) RPN14 => (
            new double[] { 7.99, 8.09, 8.19, 8.7, 9.2, 10, 12, 15, 20 },
            new double[] { 0, 2.76429e-5, 4.37498e-2, 1.69183e-1, 4.69428e-1, 9.43740e-1, 9.98636e-1, 9.99919e-1, 9.99994e-1 },
            (new double[2001]).Select((_, i) => (i + 500) * 0.01).ToArray()
        );

        public static (double[] xs, double[] ys) Titanium => (
            new double[] { 595, 635, 695, 795, 855, 875, 915, 935, 985, 1035, 1075 },
            new double[] { 0.644, 0.652, 0.644, 0.694, 0.907, 1.336, 2.169, 1.598, 0.916, 0.607, 0.603, 0.608 }
        );

        public static (double[] xs, double[] ys, double[] ps) Akima => (
            new double[] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 },
            new double[] { 12, 15, 15, 10, 10, 10, 10.5, 15, 50, 60, 85 },
            (new double[1401]).Select((_, i) => (i - 100) * 0.01).ToArray()
        );
    }
}
