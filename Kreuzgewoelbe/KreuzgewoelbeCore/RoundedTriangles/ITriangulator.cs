using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
 

namespace KreuzgewoelbeCore.RoundedTriangles
{
    public interface ITriangulator
    {
        Triangulation<Vertex> GetTriangulation(IMeasuredData data);
    }
}
