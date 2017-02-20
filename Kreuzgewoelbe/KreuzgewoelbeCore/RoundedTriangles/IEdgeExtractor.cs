using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KreuzgewoelbeCore.RoundedTriangles
{
    public interface IEdgeExtractor
    {
        /// <summary>
        /// Gibt jede Kante in der Triangulation genau einmal zurück.
        /// </summary>
        /// <param name="triangulation"></param>
        /// <returns></returns>
        IEnumerable<IEdge> GetEdges(ITriangulation triangulation);

        IEnumerable<IEdgeNormal> GetEdges(INormalTriangulation triangulation);
    }
}
