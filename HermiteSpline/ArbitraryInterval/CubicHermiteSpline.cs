using System;
using System.Collections.Generic;
using System.Linq;

namespace HermiteSpline.ArbitraryInterval {
    public class CubicHermiteSpline : HermiteSpline {

        public IReadOnlyList<double> Grads { protected set; get; }

        protected CubicHermiteSpline(IEnumerable<double> xs, IEnumerable<double> ys)
            : base(xs, ys) {

            this.Grads = CheckArray(ComputeGrad(Xs, Ys));
        }

        public CubicHermiteSpline(IEnumerable<double> xs, IEnumerable<double> ys, IEnumerable<double> gs)
            : base(xs, ys) {

            this.Grads = CheckArray(gs).ToArray();
        }

        protected virtual double[] ComputeGrad(IReadOnlyList<double> xs, IReadOnlyList<double> ys) {
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

            double x0 = Xs[index], y0 = Ys[index], g0 = Grads[index];
            double x1 = Xs[index + 1], y1 = Ys[index + 1], g1 = Grads[index + 1];

            double dx = x1 - x0, t = (x - x0) / dx;

            (double hy0, double hg0, double hy1, double hg1)
                = HermiteBasicFunctions.Cubic.Value(t);

            double y = (hy0 * y0 + hy1 * y1) + dx * (hg0 * g0 + hg1 * g1);

            return y;
        }

        public virtual double Grad(double x) {
            int index = SegmentIndex(x);

            if (index < 0) {
                return Grads[0];
            }
            if (index >= Length - 1) {
                return Grads[^1];
            }

            double x0 = Xs[index], y0 = Ys[index], g0 = Grads[index];
            double x1 = Xs[index + 1], y1 = Ys[index + 1], g1 = Grads[index + 1];

            double dx = x1 - x0, t = (x - x0) / dx;

            (double hy0, double hg0, double hy1, double hg1)
                = HermiteBasicFunctions.Cubic.Grad(t);

            double y = (hy0 * y0 + hy1 * y1) / dx + (hg0 * g0 + hg1 * g1);

            return y;
        }

        public IEnumerable<double> Grad(IEnumerable<double> xs) {
            foreach (double x in xs) {
                yield return Grad(x);
            }
        }
    }
}
