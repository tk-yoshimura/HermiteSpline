using System;
using System.Collections.Generic;
using System.Linq;

namespace HermiteSpline.UnitInterval {
    public class NonicHermiteSpline : SepticHermiteSpline {

        public IReadOnlyList<double> FourthGrads { protected set; get; }

        protected NonicHermiteSpline(IEnumerable<double> vs)
            : base(vs) {

            this.FourthGrads = CheckArray(ComputeFourthGrad(Values, Grads, SecondGrads, ThirdGrads));
        }

        protected NonicHermiteSpline(IEnumerable<double> vs, IEnumerable<double> gs)
            : base(vs, gs) {

            this.FourthGrads = CheckArray(ComputeFourthGrad(Values, Grads, SecondGrads, ThirdGrads));
        }

        protected NonicHermiteSpline(IEnumerable<double> vs, IEnumerable<double> gs, IEnumerable<double> ggs)
            : base(vs, gs, ggs) {

            this.FourthGrads = CheckArray(ComputeFourthGrad(Values, Grads, SecondGrads, ThirdGrads));
        }

        protected NonicHermiteSpline(IEnumerable<double> vs, IEnumerable<double> gs, IEnumerable<double> ggs, IEnumerable<double> gggs)
            : base(vs, gs, ggs, gggs) {

            this.FourthGrads = CheckArray(ComputeFourthGrad(Values, Grads, SecondGrads, ThirdGrads));
        }

        public NonicHermiteSpline(IEnumerable<double> vs, IEnumerable<double> gs, IEnumerable<double> ggs, IEnumerable<double> gggs, IEnumerable<double> ggggs)
            : base(vs, gs, ggs, gggs) {

            this.FourthGrads = CheckArray(ggggs).ToArray();
        }

        protected virtual double[] ComputeFourthGrad(IReadOnlyList<double> vs, IReadOnlyList<double> gs, IReadOnlyList<double> ggs, IReadOnlyList<double> gggs) {
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

            double v0 = Values[index], g0 = Grads[index], gg0 = SecondGrads[index], ggg0 = ThirdGrads[index], gggg0 = FourthGrads[index];
            double v1 = Values[index + 1], g1 = Grads[index + 1], gg1 = SecondGrads[index + 1], ggg1 = ThirdGrads[index + 1], gggg1 = FourthGrads[index + 1];

            (double hy0, double hg0, double hgg0, double hggg0, double hgggg0, double hy1, double hg1, double hgg1, double hggg1, double hgggg1)
                = HermiteBasicFunctions.Nonic.Value(x - index);

            double y = (hy0 * v0 + hy1 * v1) + (hg0 * g0 + hg1 * g1) + (hgg0 * gg0 + hgg1 * gg1) + (hggg0 * ggg0 + hggg1 * ggg1) + (hgggg0 * gggg0 + hgggg1 * gggg1);

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

            double v0 = Values[index], g0 = Grads[index], gg0 = SecondGrads[index], ggg0 = ThirdGrads[index], gggg0 = FourthGrads[index];
            double v1 = Values[index + 1], g1 = Grads[index + 1], gg1 = SecondGrads[index + 1], ggg1 = ThirdGrads[index + 1], gggg1 = FourthGrads[index + 1];

            (double hy0, double hg0, double hgg0, double hggg0, double hgggg0, double hy1, double hg1, double hgg1, double hggg1, double hgggg1)
                = HermiteBasicFunctions.Nonic.Grad(x - index);

            double y = (hy0 * v0 + hy1 * v1) + (hg0 * g0 + hg1 * g1) + (hgg0 * gg0 + hgg1 * gg1) + (hggg0 * ggg0 + hggg1 * ggg1) + (hgggg0 * gggg0 + hgggg1 * gggg1);

            return y;
        }

        public override double SecondGrad(double x) {
            int index = SegmentIndex(x);

            if (index < 0 || index >= Length - 1) {
                return 0;
            }

            double v0 = Values[index], g0 = Grads[index], gg0 = SecondGrads[index], ggg0 = ThirdGrads[index], gggg0 = FourthGrads[index];
            double v1 = Values[index + 1], g1 = Grads[index + 1], gg1 = SecondGrads[index + 1], ggg1 = ThirdGrads[index + 1], gggg1 = FourthGrads[index + 1];

            (double hy0, double hg0, double hgg0, double hggg0, double hgggg0, double hy1, double hg1, double hgg1, double hggg1, double hgggg1)
                = HermiteBasicFunctions.Nonic.SecondGrad(x - index);

            double y = (hy0 * v0 + hy1 * v1) + (hg0 * g0 + hg1 * g1) + (hgg0 * gg0 + hgg1 * gg1) + (hggg0 * ggg0 + hggg1 * ggg1) + (hgggg0 * gggg0 + hgggg1 * gggg1);

            return y;
        }

        public override double ThirdGrad(double x) {
            int index = SegmentIndex(x);

            if (index < 0 || index >= Length - 1) {
                return 0;
            }

            double v0 = Values[index], g0 = Grads[index], gg0 = SecondGrads[index], ggg0 = ThirdGrads[index], gggg0 = FourthGrads[index];
            double v1 = Values[index + 1], g1 = Grads[index + 1], gg1 = SecondGrads[index + 1], ggg1 = ThirdGrads[index + 1], gggg1 = FourthGrads[index + 1];

            (double hy0, double hg0, double hgg0, double hggg0, double hgggg0, double hy1, double hg1, double hgg1, double hggg1, double hgggg1)
                = HermiteBasicFunctions.Nonic.ThirdGrad(x - index);

            double y = (hy0 * v0 + hy1 * v1) + (hg0 * g0 + hg1 * g1) + (hgg0 * gg0 + hgg1 * gg1) + (hggg0 * ggg0 + hggg1 * ggg1) + (hgggg0 * gggg0 + hgggg1 * gggg1);

            return y;
        }

        public virtual double FourthGrad(double x) {
            int index = SegmentIndex(x);

            if (index < 0 || index >= Length - 1) {
                return 0;
            }

            double v0 = Values[index], g0 = Grads[index], gg0 = SecondGrads[index], ggg0 = ThirdGrads[index], gggg0 = FourthGrads[index];
            double v1 = Values[index + 1], g1 = Grads[index + 1], gg1 = SecondGrads[index + 1], ggg1 = ThirdGrads[index + 1], gggg1 = FourthGrads[index + 1];

            (double hy0, double hg0, double hgg0, double hggg0, double hgggg0, double hy1, double hg1, double hgg1, double hggg1, double hgggg1)
                = HermiteBasicFunctions.Nonic.FourthGrad(x - index);

            double y = (hy0 * v0 + hy1 * v1) + (hg0 * g0 + hg1 * g1) + (hgg0 * gg0 + hgg1 * gg1) + (hggg0 * ggg0 + hggg1 * ggg1) + (hgggg0 * gggg0 + hgggg1 * gggg1);

            return y;
        }

        public IEnumerable<double> FourthGrad(IEnumerable<double> xs) {
            foreach (double x in xs) {
                yield return FourthGrad(x);
            }
        }
    }
}
