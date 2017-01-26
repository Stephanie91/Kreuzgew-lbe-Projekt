using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KreuzgewoelbeCore.RoundedTriangles
{
    public interface IVertex
    {
        VectorDummy Position { get; }

        IEnumerable<ITriangle> GetAlignedFaces();
    }
}
