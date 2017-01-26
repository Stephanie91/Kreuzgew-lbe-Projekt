using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KreuzgewoelbeCore.RoundedTriangles
{
    public interface ITriangulationRefiner
    {
        /// <summary>
        /// Erstellt ein detailierteres Netz aus Dreiecken.
        /// </summary>
        /// <param name="triangulation"></param>
        /// <returns></returns>
        ITriangulation GetRefinedTriangulation(INormalTriangulation triangulation);
    }
}
