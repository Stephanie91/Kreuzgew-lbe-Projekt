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
        IEnumerable<Edge<Vertex>> GetEdges(Triangulation<Vertex> triangulation);

        IEnumerable<Edge<VertexNormal>> GetEdges(Triangulation<VertexNormal> triangulation);
    }
}
