using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
 

namespace KreuzgewoelbeCore.RoundedTriangles
{
    public interface ITriangulationRefiner
    {
        /// <summary>
        /// Erstellt ein detailierteres Netz aus Dreiecken.
        /// </summary>
        /// <param name="triangulation"></param>
        /// <returns></returns>
        Triangulation<Vertex> GetRefinedTriangulation(Triangulation<VertexNormal> triangulation);
    }
}
