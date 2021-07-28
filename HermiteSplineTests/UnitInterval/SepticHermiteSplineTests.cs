using HermiteSpline.Tests;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PNGGraphPlot;
using System.Drawing;
using System.Linq;

namespace HermiteSpline.UnitInterval.Tests {
    [TestClass()]
    public class SepticHermiteSplineTests {
        [TestMethod()]
        public void SepticHermiteSplineTest() {
            (double[] xs, double[] ys, double[] ps) = TestCases.Akima;
            double[] gs = Enumerable.Repeat(10d, xs.Length).ToArray();
            double[] ggs = Enumerable.Repeat(1d, xs.Length).ToArray();
            double[] gggs = Enumerable.Repeat(2d, xs.Length).ToArray();

            SepticHermiteSpline spline = new(ys, gs, ggs, gggs);

            {
                PNGGraphPloter pg = new(800, 400, 10, "Times New Roman", 10, 2);

                pg.DrawXLabel(Color.Black, "x");
                pg.DrawYLabel(Color.Black, "y");
                pg.DrawXScale(Color.Black, -1, 12, 2);
                pg.DrawYScale(Color.Black, 0, 100, 10);

                pg.DrawPoints(Color.Red, xs, ys, 8);

                pg.DrawPolyline(Color.Black, ps, spline.Value(ps).ToArray());

                pg.Save(Workspace.OutDir + "plot_unit_septic_value.png");
            }

            {
                PNGGraphPloter pg = new(800, 400, 10, "Times New Roman", 10, 2);

                pg.DrawXLabel(Color.Black, "x");
                pg.DrawYLabel(Color.Black, "y");
                pg.DrawXScale(Color.Black, -1, 12, 2);
                pg.DrawYScale(Color.Black, -100, 100, 10);

                pg.DrawPoints(Color.Red, xs, gs, 8);

                pg.DrawPolyline(Color.Black, ps, spline.Grad(ps).ToArray());

                pg.Save(Workspace.OutDir + "plot_unit_septic_grad.png");
            }

            {
                PNGGraphPloter pg = new(800, 400, 10, "Times New Roman", 10, 2);

                pg.DrawXLabel(Color.Black, "x");
                pg.DrawYLabel(Color.Black, "y");
                pg.DrawXScale(Color.Black, -1, 12, 2);
                pg.DrawYScale(Color.Black, -100, 100, 10);

                pg.DrawPoints(Color.Red, xs, ggs, 8);

                pg.DrawPolyline(Color.Black, ps, spline.SecondGrad(ps).ToArray());

                pg.Save(Workspace.OutDir + "plot_unit_septic_secondgrad.png");
            }

            {
                PNGGraphPloter pg = new(800, 400, 10, "Times New Roman", 10, 2);

                pg.DrawXLabel(Color.Black, "x");
                pg.DrawYLabel(Color.Black, "y");
                pg.DrawXScale(Color.Black, -1, 12, 2);
                pg.DrawYScale(Color.Black, -100, 100, 10);

                pg.DrawPoints(Color.Red, xs, gggs, 8);

                pg.DrawPolyline(Color.Black, ps, spline.ThirdGrad(ps).ToArray());

                pg.Save(Workspace.OutDir + "plot_unit_septic_thirdgrad.png");
            }
        }
    }
}