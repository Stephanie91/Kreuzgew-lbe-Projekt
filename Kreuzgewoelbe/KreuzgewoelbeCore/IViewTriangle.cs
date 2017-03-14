using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
 

namespace KreuzgewoelbeCore
{
    public interface IViewTriangle
    {
        Vector3D A { get; }
        Vector3D B { get; }
        Vector3D C { get; }
    }
}
