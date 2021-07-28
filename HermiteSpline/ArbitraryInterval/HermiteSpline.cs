using System;
using System.Collections.Generic;
using System.Linq;

namespace HermiteSpline.ArbitraryInterval {
    public abstract class HermiteSpline {
        public IReadOnlyList<double> Xs { private set; get; }

        public IReadOnlyList<double> Ys { private set; get; }

        public int Length => Xs.Count;

        public HermiteSpline(IEnumerable<double> xs, IEnumerable<double> ys) {
            if (xs.Count() != ys.Count()) {
                throw new ArgumentException("Array lengths don't match.", $"{nameof(xs)}, {nameof(ys)}");
            }
            if (xs.Count() <= 0) {
                throw new ArgumentException("Array contains no elements.", $"{nameof(xs)}, {nameof(ys)}");
            }
            if (xs.Any((x) => !double.IsFinite(x))) {
                throw new ArgumentException("Array contains invalid element.", nameof(xs));
            }
            if (ys.Any((y) => !double.IsFinite(y))) {
                throw new ArgumentException("Array contains invalid element.", nameof(ys));
            }

            double[] xs_arr = xs.ToArray(), ys_arr = ys.ToArray();

            for (int i = 1; i < xs_arr.Length; i++) {
                if (!(xs_arr[i - 1] < xs_arr[i])) {
                    throw new ArgumentException("X-coordinate order is invalid", nameof(xs));
                }
            }

            this.Xs = xs_arr;
            this.Ys = ys_arr;
        }

        public abstract double Value(double x);

        public IEnumerable<double> Value(IEnumerable<double> xs) {
            foreach (double x in xs) {
                yield return Value(x);
            }
        }

        protected int SegmentIndex(double x) {
            if (Xs[0] >= x) {
                return -1;
            }
            if (Xs[^1] <= x) {
                return Length - 1;
            }

            int index = 0;

            for (int h = Math.Max(1, Length / 2); h >= 1; h /= 2) {
                for (int i = index; i < Length - h; i += h) {
                    if (Xs[i + h] > x) {
                        index = i;
                        break;
                    }
                }
            }

            return index;
        }

        protected IEnumerable<double> CheckArray(IEnumerable<double> arr) {
            if (arr.Count() != Length) {
                throw new ArgumentException("Array length don't match.");
            }
            if (arr.Any((v) => !double.IsFinite(v))) {
                throw new ArgumentException("Array contains invalid element.", nameof(arr));
            }

            return arr;
        }

        protected double[] CheckArray(double[] arr) {
            if (arr.Length != Length) {
                throw new ArgumentException("Array length don't match.");
            }
            if (arr.Any((v) => !double.IsFinite(v))) {
                throw new ArgumentException("Array contains invalid element.", nameof(arr));
            }

            return arr;
        }
    }
}
