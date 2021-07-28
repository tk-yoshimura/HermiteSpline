using HermiteSpline.Tests;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PNGGraphPlot;
using System.Drawing;
using System.Linq;

namespace HermiteSpline.UnitInterval.Tests {
    [TestClass()]
    public class NonicHermiteSplineTests {
        [TestMethod()]
        public void NonicHermiteSplineTest() {
            (double[] xs, double[] ys, double[] ps) = TestCases.Akima;
            double[] gs = Enumerable.Repeat(10d, xs.Length).ToArray();
            double[] ggs = Enumerable.Repeat(1d, xs.Length).ToArray();
            double[] gggs = Enumerable.Repeat(2d, xs.Length).ToArray();
            double[] ggggs = Enumerable.Repeat(3d, xs.Length).ToArray();

            NonicHermiteSpline spline = new(ys, gs, ggs, gggs, ggggs);

            {
                PNGGraphPloter pg = new(800, 400, 10, "Times New Roman", 10, 2);

                pg.DrawXLabel(Color.Black, "x");
                pg.DrawYLabel(Color.Black, "y");
                pg.DrawXScale(Color.Black, -1, 12, 2);
                pg.DrawYScale(Color.Black, 0, 100, 10);

                pg.DrawPoints(Color.Red, xs, ys, 8);

                pg.DrawPolyline(Color.Black, ps, spline.Value(ps).ToArray());

                pg.Save(Workspace.OutDir + "plot_unit_nonic_value.png");
            }

            {
                PNGGraphPloter pg = new(800, 400, 10, "Times New Roman", 10, 2);

                pg.DrawXLabel(Color.Black, "x");
                pg.DrawYLabel(Color.Black, "y");
                pg.DrawXScale(Color.Black, -1, 12, 2);
                pg.DrawYScale(Color.Black, -100, 100, 10);

                pg.DrawPoints(Color.Red, xs, gs, 8);

                pg.DrawPolyline(Color.Black, ps, spline.Grad(ps).ToArray());

                pg.Save(Workspace.OutDir + "plot_unit_nonic_grad.png");
            }

            {
                PNGGraphPloter pg = new(800, 400, 10, "Times New Roman", 10, 2);

                pg.DrawXLabel(Color.Black, "x");
                pg.DrawYLabel(Color.Black, "y");
                pg.DrawXScale(Color.Black, -1, 12, 2);
                pg.DrawYScale(Color.Black, -100, 100, 10);

                pg.DrawPoints(Color.Red, xs, ggs, 8);

                pg.DrawPolyline(Color.Black, ps, spline.SecondGrad(ps).ToArray());

                pg.Save(Workspace.OutDir + "plot_unit_nonic_secondgrad.png");
            }

            {
                PNGGraphPloter pg = new(800, 400, 10, "Times New Roman", 10, 2);

                pg.DrawXLabel(Color.Black, "x");
                pg.DrawYLabel(Color.Black, "y");
                pg.DrawXScale(Color.Black, -1, 12, 2);
                pg.DrawYScale(Color.Black, -100, 100, 10);

                pg.DrawPoints(Color.Red, xs, gggs, 8);

                pg.DrawPolyline(Color.Black, ps, spline.ThirdGrad(ps).ToArray());

                pg.Save(Workspace.OutDir + "plot_unit_nonic_thirdgrad.png");
            }

            {
                PNGGraphPloter pg = new(800, 400, 10, "Times New Roman", 10, 2);

                pg.DrawXLabel(Color.Black, "x");
                pg.DrawYLabel(Color.Black, "y");
                pg.DrawXScale(Color.Black, -1, 12, 2);
                pg.DrawYScale(Color.Black, -100, 100, 10);

                pg.DrawPoints(Color.Red, xs, ggggs, 8);

                pg.DrawPolyline(Color.Black, ps, spline.FourthGrad(ps).ToArray());

                pg.Save(Workspace.OutDir + "plot_unit_nonic_fourthgrad.png");
            }
        }
    }
}