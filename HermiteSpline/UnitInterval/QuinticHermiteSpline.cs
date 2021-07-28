using System;
using System.Collections.Generic;
using System.Linq;

namespace HermiteSpline.UnitInterval {
    public class QuinticHermiteSpline : CubicHermiteSpline {

        public IReadOnlyList<double> SecondGrads { protected set; get; }

        protected QuinticHermiteSpline(IEnumerable<double> vs)
            : base(vs) {

            this.SecondGrads = CheckArray(ComputeSecondGrad(Values, Grads));
        }

        protected QuinticHermiteSpline(IEnumerable<double> vs, IEnumerable<double> gs)
            : base(vs, gs) {

            this.SecondGrads = CheckArray(ComputeSecondGrad(Values, Grads));
        }

        public QuinticHermiteSpline(IEnumerable<double> vs, IEnumerable<double> gs, IEnumerable<double> ggs)
            : base(vs, gs) {

            this.SecondGrads = CheckArray(ggs).ToArray();
        }

        protected virtual double[] ComputeSecondGrad(IReadOnlyList<double> vs, IReadOnlyList<double> gs) {
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

            double v0 = Values[index], g0 = Grads[index], gg0 = SecondGrads[index];
            double v1 = Values[index + 1], g1 = Grads[index + 1], gg1 = SecondGrads[index + 1];

            (double hy0, double hg0, double hgg0, double hy1, double hg1, double hgg1)
                = HermiteBasicFunctions.Quintic.Value(x - index);

            double y = (hy0 * v0 + hy1 * v1) + (hg0 * g0 + hg1 * g1) + (hgg0 * gg0 + hgg1 * gg1);

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

            double v0 = Values[index], g0 = Grads[index], gg0 = SecondGrads[index];
            double v1 = Values[index + 1], g1 = Grads[index + 1], gg1 = SecondGrads[index + 1];

            (double hy0, double hg0, double hgg0, double hy1, double hg1, double hgg1)
                = HermiteBasicFunctions.Quintic.Grad(x - index);

            double y = (hy0 * v0 + hy1 * v1) + (hg0 * g0 + hg1 * g1) + (hgg0 * gg0 + hgg1 * gg1);

            return y;
        }

        public virtual double SecondGrad(double x) {
            int index = SegmentIndex(x);

            if (index < 0 || index >= Length - 1) {
                return 0;
            }

            double v0 = Values[index], g0 = Grads[index], gg0 = SecondGrads[index];
            double v1 = Values[index + 1], g1 = Grads[index + 1], gg1 = SecondGrads[index + 1];

            (double hy0, double hg0, double hgg0, double hy1, double hg1, double hgg1)
                = HermiteBasicFunctions.Quintic.SecondGrad(x - index);

            double y = (hy0 * v0 + hy1 * v1) + (hg0 * g0 + hg1 * g1) + (hgg0 * gg0 + hgg1 * gg1);

            return y;
        }

        public IEnumerable<double> SecondGrad(IEnumerable<double> xs) {
            foreach (double x in xs) {
                yield return SecondGrad(x);
            }
        }
    }
}
