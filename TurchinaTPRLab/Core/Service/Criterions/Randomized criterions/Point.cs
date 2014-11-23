using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TurchinaTPRLab.Core.Service.Criterions.Randomized_criterions
{
    class Point
    {
        private float X;
        private float Y;

        public Point(double x, double y)
        {
            X = (float)x;
            Y = (float)y;
        }

        public float getX
        {
            get { return X; }
        }
        public float getY
        {
            get { return Y; }
        }
    }
}
