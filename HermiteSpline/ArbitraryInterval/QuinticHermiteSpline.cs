using System;
using System.Collections.Generic;
using System.Linq;

namespace HermiteSpline.ArbitraryInterval {
    public class QuinticHermiteSpline : CubicHermiteSpline {

        public IReadOnlyList<double> SecondGrads { protected set; get; }

        protected QuinticHermiteSpline(IEnumerable<double> xs, IEnumerable<double> ys)
            : base(xs, ys) {

            this.SecondGrads = CheckArray(ComputeSecondGrad(Xs, Ys, Grads));
        }

        protected QuinticHermiteSpline(IEnumerable<double> xs, IEnumerable<double> ys, IEnumerable<double> gs)
            : base(xs, ys, gs) {

            this.SecondGrads = CheckArray(ComputeSecondGrad(Xs, Ys, Grads));
        }

        public QuinticHermiteSpline(IEnumerable<double> xs, IEnumerable<double> ys, IEnumerable<double> gs, IEnumerable<double> ggs)
            : base(xs, ys, gs) {

            this.SecondGrads = CheckArray(ggs).ToArray();
        }

        protected virtual double[] ComputeSecondGrad(IReadOnlyList<double> xs, IReadOnlyList<double> ys, IReadOnlyList<double> gs) {
            throw new NotImplementedException();
        }

        public override double Value(double x) {
            int index = SegmentIndex(x);

            if (index < 0) {
                return Ys[0] + (x - Xs[0]) * Grads[0];
            }
            if (index >= Length - 1) {
                return Ys[^1] + (x - Xs[^1]) * Grads[^1];
            }

            double x0 = Xs[index], y0 = Ys[index], g0 = Grads[index], gg0 = SecondGrads[index];
            double x1 = Xs[index + 1], y1 = Ys[index + 1], g1 = Grads[index + 1], gg1 = SecondGrads[index + 1];

            double dx = x1 - x0, t = (x - x0) / dx;

            (double hy0, double hg0, double hgg0, double hy1, double hg1, double hgg1)
                = HermiteBasicFunctions.Quintic.Value(t);

            double y = (hy0 * y0 + hy1 * y1) + dx * ((hg0 * g0 + hg1 * g1) + dx * (hgg0 * gg0 + hgg1 * gg1));

            return y;
        }

        public override double Grad(double x) {
            int index = SegmentIndex(x);

            if (index < 0) {
                return Grads[0];
            }
            if (index >= Length - 1) {
                return Grads[^1];
            }

            double x0 = Xs[index], y0 = Ys[index], g0 = Grads[index], gg0 = SecondGrads[index];
            double x1 = Xs[index + 1], y1 = Ys[index + 1], g1 = Grads[index + 1], gg1 = SecondGrads[index + 1];

            double dx = x1 - x0, t = (x - x0) / dx;

            (double hy0, double hg0, double hgg0, double hy1, double hg1, double hgg1)
                = HermiteBasicFunctions.Quintic.Grad(t);

            double y = (hy0 * y0 + hy1 * y1) / dx + (hg0 * g0 + hg1 * g1) + dx * (hgg0 * gg0 + hgg1 * gg1);

            return y;
        }

        public virtual double SecondGrad(double x) {
            int index = SegmentIndex(x);

            if (index < 0 || index >= Length - 1) {
                return 0;
            }

            double x0 = Xs[index], y0 = Ys[index], g0 = Grads[index], gg0 = SecondGrads[index];
            double x1 = Xs[index + 1], y1 = Ys[index + 1], g1 = Grads[index + 1], gg1 = SecondGrads[index + 1];

            double dx = x1 - x0, t = (x - x0) / dx;

            (double hy0, double hg0, double hgg0, double hy1, double hg1, double hgg1)
                = HermiteBasicFunctions.Quintic.SecondGrad(t);

            double y = ((hy0 * y0 + hy1 * y1) / dx + (hg0 * g0 + hg1 * g1)) / dx + (hgg0 * gg0 + hgg1 * gg1);

            return y;
        }

        public IEnumerable<double> SecondGrad(IEnumerable<double> xs) {
            foreach (double x in xs) {
                yield return SecondGrad(x);
            }
        }
    }
}
