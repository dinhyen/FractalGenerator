using System;
using System.Windows;
using System.Windows.Media;
using System.Windows.Controls;

namespace FractalGenerator
{
    class DrawingVisualCanvas : Canvas
    {
        private VisualCollection _children;

        protected override void OnRender(DrawingContext dc)
        {
            base.OnRender(dc);

            // The body
            dc.DrawGeometry(Brushes.Blue, null, Geometry.Parse(
            @"M 240,250
                  C 200,375 200,250 175,200
                  C 100,400 100,250 100,200
                  C 0,350 0,250 30,130
                  C 75,0 100,0 150,0
                  C 200,0 250,0 250,150 Z"));
            // Left eye
            dc.DrawEllipse(Brushes.Black, new Pen(Brushes.White, 10),
                new Point(95, 95), 15, 15);
            // Right eye
            dc.DrawEllipse(Brushes.Black, new Pen(Brushes.White, 10),
                new Point(170, 105), 15, 15);
            // The mouth
            Pen p = new Pen(Brushes.Black, 10);
            p.StartLineCap = PenLineCap.Round;
            p.EndLineCap = PenLineCap.Round;
            dc.DrawLine(p, new Point(75, 160), new Point(175, 150));
        }

        protected override int VisualChildrenCount
        {
            get { return 1; }
            //get { return _children.Count; }
        }

        protected override Visual GetVisualChild(int index)
        {
            return new DrawingVisual();

            //if (index < 0 || index >= _children.Count)
            //    throw new ArgumentOutOfRangeException();

            //return _children[index];
        }

    }   // class
}   // ns
