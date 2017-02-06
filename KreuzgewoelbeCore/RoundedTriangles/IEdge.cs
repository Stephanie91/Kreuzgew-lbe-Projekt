using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KreuzgewoelbeCore.RoundedTriangles
{
    /// <summary>
    /// Repräsentiert eine Kante in einer Triangulation
    /// </summary>
    public interface IEdge
    {
        IVertex Start { get; }
        IVertex End { get; }
        ITriangle LeftTriangle { get; }
        ITriangle RightTriangle { get; }
    }
}
