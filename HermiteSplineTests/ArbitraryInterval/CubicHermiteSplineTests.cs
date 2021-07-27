using HermiteSpline.Tests;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PNGGraphPlot;
using System.Drawing;
using System.Linq;

namespace HermiteSpline.ArbitraryInterval.Tests {
    [TestClass()]
    public class CubicHermiteSplineTests {
        [TestMethod()]
        public void CubicHermiteSplineTest() {
            (double[] xs, double[] ys, double[] ps) = TestCases.RPN14;
            double[] gs = Enumerable.Repeat(1.0, xs.Length).ToArray();

            CubicHermiteSpline spline = new(xs, ys, gs);

            {
                PNGGraphPloter pg = new(800, 400, 10, "Times New Roman", 10, 2);

                pg.DrawXLabel(Color.Black, "x");
                pg.DrawYLabel(Color.Black, "y");
                pg.DrawXScale(Color.Black, 5, 25, 5);
                pg.DrawYScale(Color.Black, -0.1m, 2.1m, 0.1m);

                pg.DrawPoints(Color.Red, xs, ys, 8);

                pg.DrawPolyline(Color.Black, ps, spline.Value(ps).ToArray());

                pg.Save(Workspace.OutDir + "plot_cubic_value.png");
            }

            {
                PNGGraphPloter pg = new(800, 400, 10, "Times New Roman", 10, 2);

                pg.DrawXLabel(Color.Black, "x");
                pg.DrawYLabel(Color.Black, "y");
                pg.DrawXScale(Color.Black, 5, 25, 5);
                pg.DrawYScale(Color.Black, -2.1m, 4.1m, 0.5m);

                pg.DrawPoints(Color.Red, xs, gs, 8);

                pg.DrawPolyline(Color.Black, ps, spline.Grad(ps).ToArray());

                pg.Save(Workspace.OutDir + "plot_cubic_grad.png");
            }
        }
    }
}