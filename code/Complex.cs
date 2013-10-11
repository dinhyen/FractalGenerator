using System;

namespace FractalGenerator
{
    public sealed class Complex
    {
        double r, i;

        public Complex() { r = 0.0; i = 0.0; }
        public Complex(double x, double y) { r = x; i = y; }

        public void set(double x, double y) { r = x; i = y; }
        public double real() { return r; }
        public double imag() { return i; }
        public double modsq() { return r * r + i * i; }

        public Complex add(Complex p) { r += p.real(); i += p.imag(); return this; }
        public Complex add(double p) { r += p; return this; }
        public Complex add(int p) { r += p; return this; }
        public Complex subtr(Complex p) { r -= p.real(); i -= p.imag(); return this; }
        public Complex subtr(double p) { r -= p; return this; }
        public Complex subtr(int p) { r -= p; return this; }
        public Complex mult(double p) { r *= p; i *= p; return this; }
        public Complex mult(int p) { r *= p; i *= p; return this; }
        public Complex mult(Complex p)
        {
            r = r * p.real() - i * p.imag();
            i = i * p.real() + r * p.imag();
            return this;
        }
        public Complex divid(Complex p)
        {
            double tmp = p.modsq();
            r = (r * p.real() + i * p.imag()) / tmp;
            i = (i * p.real() - r * p.imag()) / tmp;
            return this;
        }

        public Complex sqr()
        {
            set(r * r - i * i, 2 * r * i);
            return this;
        }

        public Complex cube()
        {
            double r2 = r * r, i2 = i * i;

            set(r * (r2 - 3 * i2), i * (3 * r2 - i2));
            return this;
        }

        public Complex exp()
        {
            double e1 = Math.Exp(r);

            set(e1 * Math.Cos(i), e1 * Math.Sin(i));
            return this;
        }

        public Complex sin()
        {
            double e1 = Math.Exp(i), e2 = 1 / e1;

            set(Math.Sin(r) * (e1 + e2) / 2, Math.Cos(r) * (e1 - e2) / 2);
            return this;
        }

        public Complex cos()
        {
            double e1 = Math.Exp(i), e2 = 1 / e1;

            set(Math.Cos(r) * (e1 + e2) / 2, -Math.Sin(r) * (e1 - e2) / 2);
            return this;
        }

        public Complex add(Complex p1, Complex p2)
        {
            r = p1.real() + p2.real();
            i = p1.imag() + p2.imag();
            return this;
        }
        public Complex subtr(Complex p1, Complex p2)
        {
            r = p1.real() - p2.real();
            i = p1.imag() - p2.imag();
            return this;
        }
        public Complex mult(Complex p1, Complex p2)
        {
            r = p1.real() * p2.real() - p1.imag() * p2.imag();
            i = p1.imag() * p2.real() + p1.real() * p2.imag();
            return this;
        }
        public Complex divid(Complex p1, Complex p2)
        {
            double tmp = p2.modsq();
            r = (p1.real() * p2.real() + p1.imag() * p2.imag()) / tmp;
            i = (p1.imag() * p2.real() - p1.real() * p2.imag()) / tmp;
            return this;
        }

        public Complex sqr(Complex p)
        {
            r = p.real() * p.real() - p.imag() * p.imag();
            i = 2 * p.real() * p.imag();
            return this;
        }
        public Complex cube(Complex p)
        {
            double r2 = p.real() * p.real(), i2 = p.imag() * p.imag();

            set(p.real() * (r2 - 3 * i2), p.imag() * (3 * r2 - i2));
            return this;
        }

        public Complex exp(Complex p)
        {
            double e1 = Math.Exp(p.real());

            set(e1 * Math.Cos(p.imag()), e1 * Math.Sin(p.imag()));
            return this;
        }

        public Complex sin(Complex p)
        {
            double e1 = Math.Exp(p.imag()), e2 = 1 / e1;

            set(Math.Sin(p.real()) * (e1 + e2) / 2, Math.Cos(p.real()) * (e1 - e2) / 2);
            return this;
        }

        public Complex cos(Complex p)
        {
            double e1 = Math.Exp(p.imag()), e2 = 1 / e1;

            set(Math.Cos(p.real()) * (e1 + e2) / 2, -Math.Sin(p.real()) * (e1 - e2) / 2);
            return this;
        }

    }   // class
}   // namespace
