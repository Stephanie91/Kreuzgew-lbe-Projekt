using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KreuzgewoelbeCore.RoundedTriangles
{
    public class Edge<V> where V : Vertex
    {
        public V Start { get; private set; }
        public V End { get; private set; }

        public Triangle LeftTriangle { get; private set; }
        public Triangle RightTriangle { get; private set; }

        public Edge(V start, V end)
        {
            Start = start;
            End = end;

            //todo 
            //vielleicht triangles aus alignedfaces der vertices holen.
            //vielleicht reiner getter
        }
    }
}
