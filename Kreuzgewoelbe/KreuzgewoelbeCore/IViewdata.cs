using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
 

namespace KreuzgewoelbeCore
{
    public interface IViewdata
    {
        IEnumerable<IViewTriangle> GetTriangles();
    }
}
