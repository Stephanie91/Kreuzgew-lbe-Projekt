using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
 

namespace KreuzgewoelbeCore.RoundedTriangles
{
	public class Triangle : IViewTriangle, IEquatable<Triangle>
	{
		public Vertex VertexA { get; private set; }

		public Vertex VertexB { get; private set; }

		public Vertex VertexC { get; private set; }

		public Vector3D A {
			get { return VertexA.Position; }
		}

		public Vector3D B {
			get { return VertexA.Position; }
		}

		public Vector3D C {
			get { return VertexA.Position; }
		}

		public Triangle (Vertex a, Vertex b, Vertex c)
		{
			VertexA = a;
			VertexB = b;
			VertexC = c;
		}

		public bool Equals (Triangle b)
		{
			return b != null &&
			VertexA.Equals (b.VertexA) &&
			VertexB.Equals (b.VertexB) &&
			VertexC.Equals (b.VertexC);
		}

		public override bool Equals (object obj)
		{
			return Equals (obj as Triangle);
		}

		public override int GetHashCode ()
		{
			return VertexA.GetHashCode () +
			VertexB.GetHashCode () +
			VertexC.GetHashCode ();
		}
	}
}
