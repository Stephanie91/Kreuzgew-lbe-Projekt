using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KreuzgewoelbeCore;
using KreuzgewoelbeCore.RoundedTriangles;

namespace TriangulationRefiner.Library
{
    class CubicEdgeTriangle
    {
        public CubicFunctionEdge AB { get; set; }
        public CubicFunctionEdge BC { get; set; }
        public CubicFunctionEdge CA { get; set; }

        public ITriangle Triangle { get; set; }
    }
}
