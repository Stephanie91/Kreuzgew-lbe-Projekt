using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KreuzgewoelbeCore.RoundedTriangles
{
    public interface ITriangleExtractor
    {
        /// <summary>
        /// Gibt jedes Dreieck genau einmal zurück
        /// </summary>
        /// <param name="triangulation"></param>
        /// <returns></returns>
        IEnumerable<ITriangle> GetTriangles(ITriangulation triangulation);
    }
}
