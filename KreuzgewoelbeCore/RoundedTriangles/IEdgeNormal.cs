using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KreuzgewoelbeCore.RoundedTriangles
{
    public interface IEdgeNormal : IEdge
    {
        IVertexNormal Start { get; }
        IVertexNormal End { get; }
    }
}
