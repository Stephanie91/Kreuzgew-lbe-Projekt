using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
 

namespace KreuzgewoelbeCore.RoundedTriangles
{
    public interface IEdgeExtractor
    {
        /// <summary>
        /// Gibt jede Kante in der Triangulation genau einmal zurück.
        /// </summary>
        /// <param name="triangulation"></param>
        /// <returns></returns>
        IEnumerable<Edge<V>> GetEdges<V>(Triangulation<V> triangulation) where V : Vertex;
    }
}
