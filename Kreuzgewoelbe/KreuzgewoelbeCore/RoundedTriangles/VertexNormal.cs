using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace KreuzgewoelbeCore.RoundedTriangles
{
    public class VertexNormal : Vertex
    {
        public Vector3D Normal { get; private set; }

        public VertexNormal(Vector3D position, Vector3D normal, IList<Triangle> alignedFaces)
            : base(position, alignedFaces)
        {
            Normal = normal;
        }

        public VertexNormal(Vertex toCopy, Vector3D normal)
            : this(toCopy.Position, normal, toCopy.GetAlignedFaces())
        {

        }
    }
}
