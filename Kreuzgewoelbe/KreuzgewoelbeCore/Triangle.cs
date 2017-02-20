using System;

namespace KreuzgewoelbeCore
{
    public struct Triangle
    {
        private readonly double _sideA;
        private readonly double _sideB;
        private readonly double _sideC;

        public Triangle(double sideA, double sideB, double sideC)
        {
            _sideA = sideA;
            _sideB = sideB;
            _sideC = sideC;
        }

        public double Area()
        {
            var s = 1.0 / 2.0 * (_sideA + _sideB + _sideC);
            var area = Math.Sqrt(s * (s - _sideA) * (s - _sideB) * (s - _sideC));
            return area;
        }
    }
}
