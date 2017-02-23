using KreuzgewoelbeCore;
using KreuzgewoelbeCore.RoundedTriangles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TriangulationRefiner
{
    /// <summary>
    /// ein vertex, dessen anliegende Faces im nachhinein gesetzt werden können.
    /// </summary>
    public class FaceEditableVertex : Vertex
    {
        public FaceEditableVertex(Vector3D position)
            : base(position, Enumerable.Empty<Triangle>())
        {

        }

        public void SetTriangles(IEnumerable<Triangle> vertices)
        {
            this._AlignedFaces = vertices;
        }
    }
}
