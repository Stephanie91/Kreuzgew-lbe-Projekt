using KreuzgewoelbeCore;
using KreuzgewoelbeCore.RoundedTriangles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TriangulationRefiner.Library
{
    class CubicFunctionEdge : IEdgeNormal
    {
        private IEdgeNormal _BaseEdge;
        public Vector3D Turningpoint { get; private set; }


        public IVertexNormal Start { get { return _BaseEdge.Start; } }

        public IVertexNormal End { get { return _BaseEdge.End; } }

        IVertex IEdge.Start { get { return Start; } }

        IVertex IEdge.End { get { return End; } }

        public ITriangle LeftTriangle { get { return _BaseEdge.LeftTriangle; } }

        public ITriangle RightTriangle { get { return _BaseEdge.RightTriangle; } }

        public CubicFunctionEdge(IEdgeNormal baseEdge)
        {
            _BaseEdge = baseEdge;

            Turningpoint = CalculateTurningpoint();
        }

        private Vector3D CalculateTurningpoint()
        {
            //TODO
            throw new NotImplementedException();
        }

    }
}
