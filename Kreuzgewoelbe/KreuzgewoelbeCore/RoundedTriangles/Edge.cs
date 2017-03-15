using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace KreuzgewoelbeCore.RoundedTriangles
{
    public class Edge<V> : IEquatable<Edge<V>> where V : Vertex
    {
        public V Start { get; private set; }
        public V End { get; private set; }

        /// <summary>
        /// nicht zwingend auf der linken Seite
        /// </summary>
        public Triangle LeftTriangle { get; private set; }
        /// <summary>
        /// nicht zwingend auf der rechten Seite
        /// </summary>
        public Triangle RightTriangle { get; private set; }

        public Edge(V start, V end)
        {
            Start = start;
            End = end;

            var containingTriangles = start.GetAlignedFaces().Union(end.GetAlignedFaces());

            int index = 0;
            foreach (var triangle in containingTriangles)
            {
                switch (index)
                {
                    case 0:
                        LeftTriangle = triangle;
                        break;
                    case 1:
                        RightTriangle = triangle;
                        break;
                    default:
                        throw new ArgumentException("Only two triangles can share an edge. The vertices seem to be invalid.");
                }
                index++;
            }
        }


        public bool Equals(Edge<V> b)
        {
            return b != null &&
            (Start.Equals(b.Start)
            && End.Equals(b.End)
            ||
            (Start.Equals(b.End)
            && End.Equals(b.Start)));
        }

        public override bool Equals(object obj)
        {
            return Equals(obj as Edge<V>);
        }

        public override int GetHashCode()
        {
            return Start.GetHashCode() +
            End.GetHashCode();
        }
    }
}
