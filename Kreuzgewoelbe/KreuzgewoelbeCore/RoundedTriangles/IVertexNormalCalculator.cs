using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
 

namespace KreuzgewoelbeCore.RoundedTriangles
{
    public interface IVertexNormalCalculator
    {
        /// <summary>
        /// Erstellt eine Triangulation in der jedes Vertex eine Normale hat.
        /// </summary>
        /// <param name="triangulation">Eine Triangulation, in der nicht jedes Vertex eine Normale hat.</param>
        /// <returns></returns>
        Triangulation<VertexNormal> GetNormalTriangulation(Triangulation<Vertex> triangulation);
    }
}
