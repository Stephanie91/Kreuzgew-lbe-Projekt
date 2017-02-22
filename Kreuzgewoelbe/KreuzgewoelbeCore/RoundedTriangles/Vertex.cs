using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KreuzgewoelbeCore.RoundedTriangles
{
    public class Vertex
    {
        public Vector3D Position { get; private set; }

        private IEnumerable<Triangle> _AlignedFaces;

        public Vertex(Vector3D position, IEnumerable<Triangle> alignedFaces)
        {
            Position = position;
            _AlignedFaces = alignedFaces;
        }

        public IEnumerable<Triangle> GetAlignedFaces()
        {
            return _AlignedFaces;
        }
    }
}
