using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
 

namespace KreuzgewoelbeCore.RoundedTriangles
{
    public interface ITriangleExtractor
    {
        /// <summary>
        /// Gibt jedes Dreieck genau einmal zurück
        /// </summary>
        /// <param name="triangulation"></param>
        /// <returns></returns>
        IEnumerable<Triangle> GetTriangles<V>(Triangulation<V> triangulation) where V : Vertex;
    }
}
