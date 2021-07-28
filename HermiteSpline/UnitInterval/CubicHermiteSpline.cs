using System;
using System.Collections.Generic;
using System.Linq;

namespace HermiteSpline.UnitInterval {
    public class CubicHermiteSpline : HermiteSpline {

        public IReadOnlyList<double> Grads { protected set; get; }

        protected CubicHermiteSpline(IEnumerable<double> vs)
            : base(vs) {

            this.Grads = CheckArray(ComputeGrad(Values));
        }

        public CubicHermiteSpline(IEnumerable<double> vs, IEnumerable<double> gs)
            : base(vs) {

            this.Grads = CheckArray(gs).ToArray();
        }

        protected virtual double[] ComputeGrad(IReadOnlyList<double> vs) {
            throw new NotImplementedException();
        }

        public override double Value(double x) {
            int index = SegmentIndex(x);

            if (index < 0) {
                return Values[0] + x * Grads[0];
            }
            if (index >= Length - 1) {
                return Values[^1] + (x - Length + 1) * Grads[^1];
            }

            double v0 = Values[index], g0 = Grads[index];
            double v1 = Values[index + 1], g1 = Grads[index + 1];

            (double hy0, double hg0, double hy1, double hg1)
                = HermiteBasicFunctions.Cubic.Value(x - index);

            double y = (hy0 * v0 + hy1 * v1) + (hg0 * g0 + hg1 * g1);

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

            double v0 = Values[index], g0 = Grads[index];
            double v1 = Values[index + 1], g1 = Grads[index + 1];

            (double hy0, double hg0, double hy1, double hg1)
                = HermiteBasicFunctions.Cubic.Grad(x - index);

            double y = (hy0 * v0 + hy1 * v1) + (hg0 * g0 + hg1 * g1);

            return y;
        }

        public IEnumerable<double> Grad(IEnumerable<double> xs) {
            foreach (double x in xs) {
                yield return Grad(x);
            }
        }
    }
}
