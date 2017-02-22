using System;
using System.Collections.Generic;
using System.Linq;

namespace KreuzgewoelbeCore.RoundedTriangles
{
	public class SomeTriangleExtractor : ITriangleExtractor
	{
		// caution: this expects that ITriangle has
		// value-semantics for GetHashCode and Equals
		public IEnumerable<ITriangle> GetTriangles (ITriangulation triangulation)
		{
			var ret = new HashSet<ITriangle> ();
			foreach (var vertex in triangulation.GetVertices()) {
				foreach (var triangle in vertex.GetAlignedFaces()) {
					ret.Add (triangle);
				}
			}

			return ret;
		}
	}
}

