using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace KreuzgewoelbeCore.RoundedTriangles
{
    public class SomeEdgeExtractor : IEdgeExtractor
    {
        public IEnumerable<Edge<V>> GetEdges<V>(Triangulation<V> triangulation) where V : Vertex
        {
            var ret = new HashSet<Edge<V>>();
            foreach (var vertex in triangulation.GetVertices())
            {
                foreach (var triangle in vertex.GetAlignedFaces())
                {
                    if (!(triangle.VertexA is V && triangle.VertexB is V && triangle.VertexC is V))
                    {
                        throw new ArgumentException("Not all vertices are of the expected type.");
                    }

                    ret.Add(new Edge<V>((V)triangle.VertexA, (V)triangle.VertexB));
                    ret.Add(new Edge<V>((V)triangle.VertexB, (V)triangle.VertexC));
                    ret.Add(new Edge<V>((V)triangle.VertexC, (V)triangle.VertexA));
                }
            }

            return ret;
        }
    }
}
