using System;
using System.Collections.Generic;
using System.Linq;

namespace HermiteSpline.UnitInterval {
    public class SepticHermiteSpline : QuinticHermiteSpline {

        public IReadOnlyList<double> ThirdGrads { protected set; get; }

        protected SepticHermiteSpline(IEnumerable<double> vs)
            : base(vs) {

            this.ThirdGrads = CheckArray(ComputeThirdGrad(Values, Grads, SecondGrads));
        }

        protected SepticHermiteSpline(IEnumerable<double> vs, IEnumerable<double> gs)
            : base(vs, gs) {

            this.ThirdGrads = CheckArray(ComputeThirdGrad(Values, Grads, SecondGrads));
        }

        protected SepticHermiteSpline(IEnumerable<double> vs, IEnumerable<double> gs, IEnumerable<double> ggs)
            : base(vs, gs, ggs) {

            this.ThirdGrads = CheckArray(ComputeThirdGrad(Values, Grads, SecondGrads));
        }

        public SepticHermiteSpline(IEnumerable<double> vs, IEnumerable<double> gs, IEnumerable<double> ggs, IEnumerable<double> gggs)
            : base(vs, gs, ggs) {

            this.ThirdGrads = CheckArray(gggs).ToArray();
        }

        protected virtual double[] ComputeThirdGrad(IReadOnlyList<double> vs, IReadOnlyList<double> gs, IReadOnlyList<double> ggs) {
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

            double v0 = Values[index], g0 = Grads[index], gg0 = SecondGrads[index], ggg0 = ThirdGrads[index];
            double v1 = Values[index + 1], g1 = Grads[index + 1], gg1 = SecondGrads[index + 1], ggg1 = ThirdGrads[index + 1];

            (double hy0, double hg0, double hgg0, double hggg0, double hy1, double hg1, double hgg1, double hggg1)
                = HermiteBasicFunctions.Septic.Value(x - index);

            double y = (hy0 * v0 + hy1 * v1) + (hg0 * g0 + hg1 * g1) + (hgg0 * gg0 + hgg1 * gg1) + (hggg0 * ggg0 + hggg1 * ggg1);

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

            double v0 = Values[index], g0 = Grads[index], gg0 = SecondGrads[index], ggg0 = ThirdGrads[index];
            double v1 = Values[index + 1], g1 = Grads[index + 1], gg1 = SecondGrads[index + 1], ggg1 = ThirdGrads[index + 1];

            (double hy0, double hg0, double hgg0, double hggg0, double hy1, double hg1, double hgg1, double hggg1)
                = HermiteBasicFunctions.Septic.Grad(x - index);

            double y = (hy0 * v0 + hy1 * v1) + (hg0 * g0 + hg1 * g1) + (hgg0 * gg0 + hgg1 * gg1) + (hggg0 * ggg0 + hggg1 * ggg1);

            return y;
        }

        public override double SecondGrad(double x) {
            int index = SegmentIndex(x);

            if (index < 0 || index >= Length - 1) {
                return 0;
            }

            double v0 = Values[index], g0 = Grads[index], gg0 = SecondGrads[index], ggg0 = ThirdGrads[index];
            double v1 = Values[index + 1], g1 = Grads[index + 1], gg1 = SecondGrads[index + 1], ggg1 = ThirdGrads[index + 1];

            (double hy0, double hg0, double hgg0, double hggg0, double hy1, double hg1, double hgg1, double hggg1)
                = HermiteBasicFunctions.Septic.SecondGrad(x - index);

            double y = (hy0 * v0 + hy1 * v1) + (hg0 * g0 + hg1 * g1) + (hgg0 * gg0 + hgg1 * gg1) + (hggg0 * ggg0 + hggg1 * ggg1);

            return y;
        }

        public virtual double ThirdGrad(double x) {
            int index = SegmentIndex(x);

            if (index < 0 || index >= Length - 1) {
                return 0;
            }

            double v0 = Values[index], g0 = Grads[index], gg0 = SecondGrads[index], ggg0 = ThirdGrads[index];
            double v1 = Values[index + 1], g1 = Grads[index + 1], gg1 = SecondGrads[index + 1], ggg1 = ThirdGrads[index + 1];

            (double hy0, double hg0, double hgg0, double hggg0, double hy1, double hg1, double hgg1, double hggg1)
                = HermiteBasicFunctions.Septic.ThirdGrad(x - index);

            double y = (hy0 * v0 + hy1 * v1) + (hg0 * g0 + hg1 * g1) + (hgg0 * gg0 + hgg1 * gg1) + (hggg0 * ggg0 + hggg1 * ggg1);

            return y;
        }

        public IEnumerable<double> ThirdGrad(IEnumerable<double> xs) {
            foreach (double x in xs) {
                yield return ThirdGrad(x);
            }
        }
    }
}
