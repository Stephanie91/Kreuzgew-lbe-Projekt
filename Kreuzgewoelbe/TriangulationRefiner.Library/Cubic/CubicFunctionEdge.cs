using KreuzgewoelbeCore;
using KreuzgewoelbeCore.RoundedTriangles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TriangulationRefiner.Cubic
{
    public class CubicFunctionEdge : FunctionEdge
    {
        public CubicFunctionEdge(VertexNormal start, VertexNormal end)
            : base(start, end)
        { }

        public CubicFunctionEdge(Edge<VertexNormal> toCopy)
            : this(toCopy.Start, toCopy.End)
        { }

        protected override Vertex GetNextVertex()
        {
            throw new NotImplementedException("todo");
        }
    }
}
