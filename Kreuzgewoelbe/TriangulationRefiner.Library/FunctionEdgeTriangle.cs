using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KreuzgewoelbeCore;
using KreuzgewoelbeCore.RoundedTriangles;

namespace TriangulationRefiner
{
    /// <summary>
    /// speichert kanten mit Function für ein angegebenes Dreieck
    /// </summary>
    class FunctionEdgeTriangle
    {
        public FunctionEdge Edge1 { get; set; }
        public FunctionEdge Edge2 { get; set; }
        public FunctionEdge Edge3 { get; set; }

        public Triangle Triangle { get; private set; }

        public FunctionEdgeTriangle(Triangle triangle)
        {
            Triangle = triangle;
        }
    }
}
