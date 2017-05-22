using KreuzgewoelbeCore.RoundedTriangles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TriangulationRefiner
{
    interface IEditableVertex
    {
        void SetTriangles(IList<Triangle> vertices);
    }
}
