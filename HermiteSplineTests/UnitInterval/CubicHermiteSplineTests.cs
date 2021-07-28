using HermiteSpline.Tests;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PNGGraphPlot;
using System.Drawing;
using System.Linq;

namespace HermiteSpline.UnitInterval.Tests {
    [TestClass()]
    public class CubicHermiteSplineTests {
        [TestMethod()]
        public void CubicHermiteSplineTest() {
            (double[] xs, double[] ys, double[] ps) = TestCases.Akima;
            double[] gs = Enumerable.Repeat(10d, xs.Length).ToArray();

            CubicHermiteSpline spline = new(ys, gs);

            {
                PNGGraphPloter pg = new(800, 400, 10, "Times New Roman", 10, 2);

                pg.DrawXLabel(Color.Black, "x");
                pg.DrawYLabel(Color.Black, "y");
                pg.DrawXScale(Color.Black, -1, 12, 2);
                pg.DrawYScale(Color.Black, 0, 100, 10);

                pg.DrawPoints(Color.Red, xs, ys, 8);

                pg.DrawPolyline(Color.Black, ps, spline.Value(ps).ToArray());

                pg.Save(Workspace.OutDir + "plot_unit_cubic_value.png");
            }

            {
                PNGGraphPloter pg = new(800, 400, 10, "Times New Roman", 10, 2);

                pg.DrawXLabel(Color.Black, "x");
                pg.DrawYLabel(Color.Black, "y");
                pg.DrawXScale(Color.Black, -1, 12, 2);
                pg.DrawYScale(Color.Black, -100, 100, 10);

                pg.DrawPoints(Color.Red, xs, gs, 8);

                pg.DrawPolyline(Color.Black, ps, spline.Grad(ps).ToArray());

                pg.Save(Workspace.OutDir + "plot_unit_cubic_grad.png");
            }
        }
    }
}