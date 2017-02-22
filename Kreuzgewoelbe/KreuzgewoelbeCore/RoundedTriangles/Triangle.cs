using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KreuzgewoelbeCore.RoundedTriangles
{
    public class Triangle : IViewTriangle
    {
        public Vertex VertexA { get; private set; }
        public Vertex VertexB { get; private set; }
        public Vertex VertexC { get; private set; }

        public Vector3D A
        {
            get { return VertexA.Position; }
        }

        public Vector3D B
        {
            get { return VertexA.Position; }
        }

        public Vector3D C
        {
            get { return VertexA.Position; }
        }
    }
}
