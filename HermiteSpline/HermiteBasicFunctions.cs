using System;

namespace HermiteSpline {
    public static class HermiteBasicFunctions {

        private static (double v0, double v1) Odd(double t, Func<double, double> f) {
            return (f(1 - t), f(t));
        }

        private static (double v0, double v1) Even(double t, Func<double, double> f) {
            return (f(1 - t), -f(t));
        }

        public static class Cubic {
            public static (double hy0, double hg0, double hy1, double hg1) Value(double t) {
                (double hy0, double hy1) = Odd(t, (t) => t * t * (3 - t * 2));
                (double hg0, double hg1) = Even(t, (t) => t * t * (1 - t));

                return (hy0, hg0, hy1, hg1);
            }

            public static (double hy0, double hg0, double hy1, double hg1) Grad(double t) {
                (double hy0, double hy1) = Even(t, (t) => -t * (6 - t * 6));
                (double hg0, double hg1) = Odd(t, (t) => -t * (2 - t * 3));

                return (hy0, hg0, hy1, hg1);
            }
        }

        public static class Quintic {
            public static (double hy0, double hg0, double hgg0, double hy1, double hg1, double hgg1) Value(double t) {
                (double hy0, double hy1) = Odd(t, (t) => t * t * t * (10 + t * (-15 + t * 6)));
                (double hg0, double hg1) = Even(t, (t) => t * t * t * (4 + t * (-7 + t * 3)));
                (double hgg0, double hgg1) = Odd(t, (t) => t * t * t * (1 + t * (-2 + t)) / 2);

                return (hy0, hg0, hgg0, hy1, hg1, hgg1);
            }

            public static (double hy0, double hg0, double hgg0, double hy1, double hg1, double hgg1) Grad(double t) {
                (double hy0, double hy1) = Even(t, (t) => -t * t * (30 + t * (-60 + t * 30)));
                (double hg0, double hg1) = Odd(t, (t) => -t * t * (12 + t * (-28 + t * 15)));
                (double hgg0, double hgg1) = Even(t, (t) => -t * t * (3 + t * (-8 + t * 5)) / 2);

                return (hy0, hg0, hgg0, hy1, hg1, hgg1);
            }

            public static (double hy0, double hg0, double hgg0, double hy1, double hg1, double hgg1) SecondGrad(double t) {
                (double hy0, double hy1) = Odd(t, (t) => t * (60 + t * (-180 + t * 120)));
                (double hg0, double hg1) = Even(t, (t) => t * (24 + t * (-84 + t * 60)));
                (double hgg0, double hgg1) = Odd(t, (t) => t * (3 + t * (-12 + t * 10)));

                return (hy0, hg0, hgg0, hy1, hg1, hgg1);
            }
        }

        public static class Septic {
            public static (double hy0, double hg0, double hgg0, double hggg0, double hy1, double hg1, double hgg1, double hggg1) Value(double t) {
                (double hy0, double hy1) = Odd(t, (t) => t * t * t * t * (35 + t * (-84 + t * (70 - t * 20))));
                (double hg0, double hg1) = Even(t, (t) => t * t * t * t * (15 + t * (-39 + t * (34 - t * 10))));
                (double hgg0, double hgg1) = Odd(t, (t) => t * t * t * t * (5 + t * (-14 + t * (13 - t * 4))) / 2);
                (double hggg0, double hggg1) = Even(t, (t) => t * t * t * t * (1 + t * (-3 + t * (3 - t * 1))) / 6);

                return (hy0, hg0, hgg0, hggg0, hy1, hg1, hgg1, hggg1);
            }

            public static (double hy0, double hg0, double hgg0, double hggg0, double hy1, double hg1, double hgg1, double hggg1) Grad(double t) {
                (double hy0, double hy1) = Even(t, (t) => -t * t * t * (140 + t * (-420 + t * (420 - t * 140))));
                (double hg0, double hg1) = Odd(t, (t) => -t * t * t * (60 + t * (-195 + t * (204 - t * 70))));
                (double hgg0, double hgg1) = Even(t, (t) => -t * t * t * (10 + t * (-35 + t * (39 - t * 14))));
                (double hggg0, double hggg1) = Odd(t, (t) => -t * t * t * (4 + t * (-15 + t * (18 - t * 7))) / 6);

                return (hy0, hg0, hgg0, hggg0, hy1, hg1, hgg1, hggg1);
            }

            public static (double hy0, double hg0, double hgg0, double hggg0, double hy1, double hg1, double hgg1, double hggg1) SecondGrad(double t) {
                (double hy0, double hy1) = Odd(t, (t) => t * t * (420 + t * (-1680 + t * (2100 - t * 840))));
                (double hg0, double hg1) = Even(t, (t) => t * t * (180 + t * (-780 + t * (1020 - t * 420))));
                (double hgg0, double hgg1) = Odd(t, (t) => t * t * (30 + t * (-140 + t * (195 - t * 84))));
                (double hggg0, double hggg1) = Even(t, (t) => t * t * (2 + t * (-10 + t * (15 - t * 7))));

                return (hy0, hg0, hgg0, hggg0, hy1, hg1, hgg1, hggg1);
            }

            public static (double hy0, double hg0, double hgg0, double hggg0, double hy1, double hg1, double hgg1, double hggg1) ThirdGrad(double t) {
                (double hy0, double hy1) = Even(t, (t) => -t * (840 + t * (-5040 + t * (8400 - t * 4200))));
                (double hg0, double hg1) = Odd(t, (t) => -t * (360 + t * (-2340 + t * (4080 - t * 2100))));
                (double hgg0, double hgg1) = Even(t, (t) => -t * (60 + t * (-420 + t * (780 - t * 420))));
                (double hggg0, double hggg1) = Odd(t, (t) => -t * (4 + t * (-30 + t * (60 - t * 35))));

                return (hy0, hg0, hgg0, hggg0, hy1, hg1, hgg1, hggg1);
            }
        }

        public static class Nonic {
            public static (double hy0, double hg0, double hgg0, double hggg0, double hgggg0, double hy1, double hg1, double hgg1, double hggg1, double hgggg1) Value(double t) {
                (double hy0, double hy1) = Odd(t, (t) => t * t * t * t * t * (126 + t * (-420 + t * (540 + t * (-315 + t * 70)))));
                (double hg0, double hg1) = Even(t, (t) => t * t * t * t * t * (56 + t * (-196 + t * (260 + t * (-155 + t * 35)))));
                (double hgg0, double hgg1) = Odd(t, (t) => t * t * t * t * t * (21 + t * (-77 + t * (106 + t * (-65 + t * 15)))) / 2);
                (double hggg0, double hggg1) = Even(t, (t) => t * t * t * t * t * (6 + t * (-23 + t * (33 + t * (-21 + t * 5)))) / 6);
                (double hgggg0, double hgggg1) = Odd(t, (t) => t * t * t * t * t * (1 + t * (-4 + t * (6 + t * (-4 + t * 1)))) / 24);

                return (hy0, hg0, hgg0, hggg0, hgggg0, hy1, hg1, hgg1, hggg1, hgggg1);
            }

            public static (double hy0, double hg0, double hgg0, double hggg0, double hgggg0, double hy1, double hg1, double hgg1, double hggg1, double hgggg1) Grad(double t) {
                (double hy0, double hy1) = Even(t, (t) => -t * t * t * t * (630 + t * (-2520 + t * (3780 + t * (-2520 + t * 630)))));
                (double hg0, double hg1) = Odd(t, (t) => -t * t * t * t * (280 + t * (-1176 + t * (1820 + t * (-1240 + t * 315)))));
                (double hgg0, double hgg1) = Even(t, (t) => -t * t * t * t * (105 + t * (-462 + t * (742 + t * (-520 + t * 135)))) / 2);
                (double hggg0, double hggg1) = Odd(t, (t) => -t * t * t * t * (30 + t * (-138 + t * (231 + t * (-168 + t * 45)))) / 6);
                (double hgggg0, double hgggg1) = Even(t, (t) => -t * t * t * t * (5 + t * (-24 + t * (42 + t * (-32 + t * 9)))) / 24);

                return (hy0, hg0, hgg0, hggg0, hgggg0, hy1, hg1, hgg1, hggg1, hgggg1);
            }

            public static (double hy0, double hg0, double hgg0, double hggg0, double hgggg0, double hy1, double hg1, double hgg1, double hggg1, double hgggg1) SecondGrad(double t) {
                (double hy0, double hy1) = Odd(t, (t) => t * t * t * (2520 + t * (-12600 + t * (22680 + t * (-17640 + t * 5040)))));
                (double hg0, double hg1) = Even(t, (t) => t * t * t * (1120 + t * (-5880 + t * (10920 + t * (-8680 + t * 2520)))));
                (double hgg0, double hgg1) = Odd(t, (t) => t * t * t * (210 + t * (-1155 + t * (2226 + t * (-1820 + t * 540)))));
                (double hggg0, double hggg1) = Even(t, (t) => t * t * t * (20 + t * (-115 + t * (231 + t * (-196 + t * 60)))));
                (double hgggg0, double hgggg1) = Odd(t, (t) => t * t * t * (5 + t * (-30 + t * (63 + t * (-56 + t * 18)))) / 6);

                return (hy0, hg0, hgg0, hggg0, hgggg0, hy1, hg1, hgg1, hggg1, hgggg1);
            }

            public static (double hy0, double hg0, double hgg0, double hggg0, double hgggg0, double hy1, double hg1, double hgg1, double hggg1, double hgggg1) ThirdGrad(double t) {
                (double hy0, double hy1) = Even(t, (t) => -t * t * (7560 + t * (-50400 + t * (113400 + t * (-105840 + t * 35280)))));
                (double hg0, double hg1) = Odd(t, (t) => -t * t * (3360 + t * (-23520 + t * (54600 + t * (-52080 + t * 17640)))));
                (double hgg0, double hgg1) = Even(t, (t) => -t * t * (630 + t * (-4620 + t * (11130 + t * (-10920 + t * 3780)))));
                (double hggg0, double hggg1) = Odd(t, (t) => -t * t * (60 + t * (-460 + t * (1155 + t * (-1176 + t * 420)))));
                (double hgggg0, double hgggg1) = Even(t, (t) => -t * t * (5 + t * (-40 + t * (105 + t * (-112 + t * 42)))) / 2);

                return (hy0, hg0, hgg0, hggg0, hgggg0, hy1, hg1, hgg1, hggg1, hgggg1);
            }

            public static (double hy0, double hg0, double hgg0, double hggg0, double hgggg0, double hy1, double hg1, double hgg1, double hggg1, double hgggg1) FourthGrad(double t) {
                (double hy0, double hy1) = Odd(t, (t) => t * (15120 + t * (-151200 + t * (453600 + t * (-529200 + t * 211680)))));
                (double hg0, double hg1) = Even(t, (t) => t * (6720 + t * (-70560 + t * (218400 + t * (-260400 + t * 105840)))));
                (double hgg0, double hgg1) = Odd(t, (t) => t * (1260 + t * (-13860 + t * (44520 + t * (-54600 + t * 22680)))));
                (double hggg0, double hggg1) = Even(t, (t) => t * (120 + t * (-1380 + t * (4620 + t * (-5880 + t * 2520)))));
                (double hgggg0, double hgggg1) = Odd(t, (t) => t * (5 + t * (-60 + t * (210 + t * (-280 + t * 126)))));

                return (hy0, hg0, hgg0, hggg0, hgggg0, hy1, hg1, hgg1, hggg1, hgggg1);
            }
        }
    }
}
