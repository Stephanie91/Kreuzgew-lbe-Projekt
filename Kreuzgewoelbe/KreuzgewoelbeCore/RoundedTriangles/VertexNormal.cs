using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
 

namespace KreuzgewoelbeCore.RoundedTriangles
{
    public class VertexNormal : Vertex
    {
        public Vector3D Normal { get; private set; }

        public VertexNormal(Vector3D position, Vector3D normal, IEnumerable<Triangle> alignedFaces)
            : base(position, alignedFaces)
        {
            Normal = normal;
        }
    }
}
