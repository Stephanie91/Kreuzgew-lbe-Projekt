using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KreuzgewoelbeCore.RoundedTriangles
{
    public class VertexNormal : Vertex
    {
        public Vector3D Normal { get; private set; }

        public VertexNormal(Vector3D position, Vector3D normal)
            : base(position)
        {
            Normal = normal;
        }
    }
}
