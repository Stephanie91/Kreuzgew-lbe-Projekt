using KreuzgewoelbeCore;
using KreuzgewoelbeCore.RoundedTriangles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TriangulationRefiner
{
    public class FaceEditableVertexNormal : VertexNormal, IEditableVertex
    {
        public FaceEditableVertexNormal(Vector3D position, Vector3D normal)
            : base(position, normal, Enumerable.Empty<Triangle>())
        {

        }

        public void SetTriangles(IEnumerable<Triangle> vertices)
        {
            this._AlignedFaces = vertices;
        }
    }
}
