using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
 

namespace KreuzgewoelbeCore.RoundedTriangles
{
    public class Triangulation<V> where V : Vertex
    {
        private IEnumerable<V> _Vertices;

        public Triangulation(IEnumerable<V> vertices)
        {
            _Vertices = vertices;
        }

        public IEnumerable<V> GetVertices()
        {
            return _Vertices;
        }

        public Triangulation<Vertex> AsVertexTriangulation()
        {
            return new Triangulation<Vertex>(_Vertices.Cast<Vertex>());
        }
    }
}
