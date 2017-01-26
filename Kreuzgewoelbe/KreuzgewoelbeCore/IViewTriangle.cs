using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KreuzgewoelbeCore
{
    public interface IViewTriangle
    {
        VectorDummy A { get; }
        VectorDummy B { get; }
        VectorDummy C { get; }
    }
}
