using KreuzgewoelbeCore;
using KreuzgewoelbeCore.RoundedTriangles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace TriangulationRefiner
{
    /// <summary>
    /// ein vertex, dessen anliegende Faces im nachhinein gesetzt werden können.
    /// </summary>
    public class FaceEditableVertex : Vertex, IEditableVertex
    {
        public FaceEditableVertex(Vector3D position)
            : base(position, new List<Triangle>())
        {

        }

        public void SetTriangles(IList<Triangle> vertices)
        {
            this._AlignedFaces = vertices;
        }
    }
}
