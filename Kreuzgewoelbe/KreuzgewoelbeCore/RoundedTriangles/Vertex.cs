using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
 

namespace KreuzgewoelbeCore.RoundedTriangles
{
    public class Vertex : IEquatable<Vertex>
    {
        public Vector3D Position { get; private set; }

        protected IList<Triangle> _AlignedFaces;


        public Vertex(Vector3D position, IList<Triangle> alignedFaces)
        {
            Position = position;
            _AlignedFaces = alignedFaces;
        }

        public IList<Triangle> GetAlignedFaces()
        {
            return _AlignedFaces;
        }

        public bool Equals(Vertex b)
        {
            return b != null &&
                Position.Equals(b.Position);
        }

        public override bool Equals(object b)
        {
            return Equals(b as Vertex);
        }

        public override int GetHashCode()
        {
            return Position.GetHashCode() + this.GetType().GetHashCode();
        }
    }
}
