# HermiteSpline

 Hermite Spline is a piecewise interpolation function that determines the interpolation polynomial using the values of the support points at both ends of the interval and the derivative as constraints. Unlike the B-spline, it always passes through the support point. Depending on the rule that determines the derivative at the support point, there are different properties such as monotonicity and overshoot. It is necessary to use these rules for different purposes.

![hermite spline](https://github.com/tk-yoshimura/HermiteSpline/blob/main/figures/hermite_spline.svg)

## Cubic Hermite Spline

The segmented polynomial of a cubic hermite spline is defined by the following equation.

![define cubic spline](https://github.com/tk-yoshimura/HermiteSpline/blob/main/figures/define_cubic_spline.svg)  
![deltax](https://github.com/tk-yoshimura/HermiteSpline/blob/main/figures/deltax.svg)  

These are the constraints that must be met.

![formularise cubic spline](https://github.com/tk-yoshimura/HermiteSpline/blob/main/figures/formularise_cubic_spline.svg)

From this matrix representation, the coefficients of the hermite basis functions can be obtained.

![matrix cubic spline](https://github.com/tk-yoshimura/HermiteSpline/blob/main/figures/matrix_cubic_spline.svg)  
![coef cubic spline](https://github.com/tk-yoshimura/HermiteSpline/blob/main/figures/coef_cubic_spline.svg)  
![hermite basic cubic](https://github.com/tk-yoshimura/HermiteSpline/blob/main/figures/hermite_basic_cubic.svg)  

## Quintic Hermite Spline

In the same way, we can find the Hermite spline of the fifth order. To use this, we also need the second derivative at the support point.

![define quintic spline](https://github.com/tk-yoshimura/HermiteSpline/blob/main/figures/define_quintic_spline.svg)  
![formularise quintic spline](https://github.com/tk-yoshimura/HermiteSpline/blob/main/figures/formularise_quintic_spline.svg)

![coef quintic spline](https://github.com/tk-yoshimura/HermiteSpline/blob/main/figures/coef_quintic_spline.svg)  
![hermite basic quintic](https://github.com/tk-yoshimura/HermiteSpline/blob/main/figures/hermite_basic_quintic.svg)  

## Higher-Order Hermite Spline

Even higher-order Hermite splines can be defined. However, these are rarely used.

### Septic

![coef septic spline](https://github.com/tk-yoshimura/HermiteSpline/blob/main/figures/coef_septic_spline.svg)  
![hermite basic septic](https://github.com/tk-yoshimura/HermiteSpline/blob/main/figures/hermite_basic_septic.svg)  
![hermite basic septic zoom](https://github.com/tk-yoshimura/HermiteSpline/blob/main/figures/hermite_basic_septic_zoom.svg)  

### Nonic

![coef nonic spline](https://github.com/tk-yoshimura/HermiteSpline/blob/main/figures/coef_nonic_spline.svg)  