using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace KreuzgewoelbeCore
{
    public class TestPointGenerator
    {
        private double Z(double xValue, double yValue)
        {
            return 100 - (Math.Pow(xValue, 2) + Math.Pow(yValue, 2));
        }

        public IEnumerable<Vector3D> GenerateRegularPoints(int lowerBound, int upperBound)
        {
            for (int x = lowerBound; x <= upperBound; x++)
            {
                for (int y = lowerBound; y <= upperBound; y++)
                {
                    yield return new Vector3D(x, y, Z(x, y)); ;
                }
            }
        }

        public IEnumerable<Vector3D> GenerateIrregularPoints(int count)
        {
            Random random = new Random();
            for (int i = 0; i < count; i++)
            {
                yield return new Vector3D(random.NextDouble()*10.2, random.NextDouble() * 10.2, random.NextDouble() * 10.2);
            }
        }
    }
}
