﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KreuzgewoelbeCore.RoundedTriangles
{
    public interface IVertexNormal : IVertex
    {
        VectorDummy Normal { get; }
    }
}
