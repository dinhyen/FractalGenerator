using System;
using System.Windows.Media;

namespace FractalGenerator
{
    class Mandelbrot
    {
        private int _colCount;
        private int _rowCount;

        protected int MAX_ITER = 40;
        private double ESCAPE_RADIUS = 4.0;
        private bool SMOOTH_COLOR = true;

        private Complex _topLeft;
        private Complex _bottomRight;

        public Complex TopLeft {
            get { return _topLeft; }
            set { _topLeft = value; }
        }
        
        public Complex BottomRight {
            get { return _bottomRight; }
            set { _bottomRight = value; }
        }

        public Mandelbrot()
        {
            ResetViewPort();
        }

        public void ResetViewPort()
        {
            TopLeft = new Complex(-2.0, 1.5);
            BottomRight = new Complex(1.0, -1.5);   // offset to show off main area
        }

        #region Mandelbrot algorithrm
        
        public void Generate(int[,] _pixelArray)
        {
            _rowCount = _pixelArray.GetLength(0);
            _colCount = _pixelArray.GetLength(1);

            Complex pixel;
            double color;

            for (int row = 0; row < _rowCount; ++row)
            {
                for (int col = 0; col < _colCount; ++col)
                {
                    pixel = Translate(col, row);    // col correspond to x, row to y
                    color = ComputePixelColor(pixel);

                    if (color <= -1.0)
                        _pixelArray[row, col] = 0;
                    else
                        if (SMOOTH_COLOR)
                            _pixelArray[row, col] = (int)((color * 256 - 1) % 256);
                        else
                            _pixelArray[row, col] = (int)((color - 1) % 255 + 1);
                }
            }
        }

        private double ComputePixelColor(Complex pixel)
        {
            Complex z = InitZ();
            int iter = 0;
            do
            {
                iter++;
                z = Transform(z, pixel);
            } while ((z.modsq() <= ESCAPE_RADIUS) && (iter <= MAX_ITER));

            if (iter > MAX_ITER)
                return -1.0;

            if (SMOOTH_COLOR)
            {
                // Color smoothing algorithm http://linas.org/art-gallery/escape/escape.html
                z = Transform(z, pixel); iter++;    // a couple of extra iterations helps
                z = Transform(z, pixel); iter++;    // decrease size of error term
                double modulus = z.modsq();
                double mu = iter - Math.Log(Math.Log(modulus)) / Math.Log(2.0);
                return mu;
            }
            else
                return (double)iter;
        }

        private Complex InitZ()
        {
            return new Complex(0.0, 0.0);
        }

        public Complex Transform(Complex z, Complex c)
        {
            return new Complex().sqr(z).add(c);
        }

        public Complex Translate(int x, int y)
        {
            return new Complex(
              TopLeft.real() + (double)x / _colCount * (BottomRight.real() - TopLeft.real()),
              TopLeft.imag() + (double)y / _rowCount * (BottomRight.imag() - TopLeft.imag())
            );
        }

        #endregion

    }   // class
}   // ns
