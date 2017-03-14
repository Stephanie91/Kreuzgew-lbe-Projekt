using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
 

namespace KreuzgewoelbeCore.RoundedTriangles
{
    public interface ISurfaceAreaCalculator
    {
        double GetSurface(IEnumerable<Triangle> triangles);
    }
}
