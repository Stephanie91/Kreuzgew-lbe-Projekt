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

        public Vertex(Vector3D position)
        {
            Position = position;
        }

        public IEnumerable<Triangle> GetAlignedFaces()
        {
            throw new NotImplementedException();
        }
    }
}
