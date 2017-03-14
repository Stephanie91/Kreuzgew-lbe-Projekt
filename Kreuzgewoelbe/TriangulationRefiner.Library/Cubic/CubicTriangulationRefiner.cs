using KreuzgewoelbeCore.RoundedTriangles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TriangulationRefiner.Cubic
{
    public class CubicTriangulationRefiner : TriangulationRefiner
    {
        public CubicTriangulationRefiner(IEdgeExtractor edgeExtractor)
            : base(edgeExtractor)
        { }

        protected override FunctionEdge FunctionEdgeFactory(Edge<VertexNormal> baseEdge)
        {
            return new CubicFunctionEdge(baseEdge);
        }
    }
}
