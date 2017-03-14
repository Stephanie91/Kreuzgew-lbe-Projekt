using KreuzgewoelbeCore.RoundedTriangles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace TriangulationRefiner
{
    class GenericTriangulationRefiner : TriangulationRefiner
    {
        private Func<Edge<VertexNormal>, FunctionEdge> _Factory;

        public GenericTriangulationRefiner(IEdgeExtractor edgeExtractor,
            Func<Edge<VertexNormal>, FunctionEdge> edgeFactory)
            : base(edgeExtractor)
        {
            _Factory = edgeFactory;
        }

        protected override FunctionEdge FunctionEdgeFactory(Edge<VertexNormal> baseEdge)
        {
            return _Factory(baseEdge);
        }
    }
}
