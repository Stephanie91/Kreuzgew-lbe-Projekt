using KreuzgewoelbeCore.RoundedTriangles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace TriangulationRefiner
{
    public abstract class FunctionEdge : Edge<VertexNormal>
    {
        public FaceEditableVertex NextVertex { get { return _NextVertex.Value; } }

        /// <summary>
        /// sehr hilfreich, um die referenz zu behalten
        /// </summary>
        private Lazy<FaceEditableVertex> _NextVertex;

        public FunctionEdge(VertexNormal start, VertexNormal end)
            : base(start, end)
        {
            _NextVertex = new Lazy<FaceEditableVertex>(GetNextVertex);
        }

        protected abstract FaceEditableVertex GetNextVertex();
    }
}
