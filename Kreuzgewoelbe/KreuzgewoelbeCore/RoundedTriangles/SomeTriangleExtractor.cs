using System;
using System.Collections.Generic;
using System.Linq;

namespace KreuzgewoelbeCore.RoundedTriangles
{
	public class SomeTriangleExtractor : ITriangleExtractor
	{
		// caution: this expects that ITriangle has
		// value-semantics for GetHashCode and Equals
		public IEnumerable<Triangle> GetTriangles(Triangulation<Vertex> triangulation)
		{
			var ret = new HashSet<Triangle> ();
			foreach (var vertex in triangulation.GetVertices()) {
				foreach (var triangle in vertex.GetAlignedFaces()) {
					ret.Add (triangle);
				}
			}

			return ret;
		}
	}
}

