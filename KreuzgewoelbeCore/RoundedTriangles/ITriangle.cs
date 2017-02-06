using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KreuzgewoelbeCore.RoundedTriangles
{
    public interface ITriangle : IViewTriangle
    {
        IVertex VertexA { get; }
        IVertex VertexB { get; }
        IVertex VertexC { get; }
    }
}
