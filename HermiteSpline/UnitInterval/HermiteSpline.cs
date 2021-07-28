using System;
using System.Collections.Generic;
using System.Linq;

namespace HermiteSpline.UnitInterval {
    public abstract class HermiteSpline {
        public IReadOnlyList<double> Values { private set; get; }

        public int Length => Values.Count;

        public HermiteSpline(IEnumerable<double> vs) {
            if (vs.Count() <= 0) {
                throw new ArgumentException("Array contains no elements.", nameof(vs));
            }
            if (vs.Any((v) => !double.IsFinite(v))) {
                throw new ArgumentException("Array contains invalid element.", nameof(vs));
            }

            this.Values = vs.ToArray();
        }

        public abstract double Value(double x);

        public IEnumerable<double> Value(IEnumerable<double> xs) {
            foreach (double x in xs) {
                yield return Value(x);
            }
        }

        protected int SegmentIndex(double x) {
            if (x < 0) {
                return -1;
            }
            if (x >= Length) {
                return Length - 1;
            }

            int index = (int)Math.Floor(x);

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
