using System;
using System.Collections.Generic;
using System.Linq;

namespace KreuzgewoelbeCore.RoundedTriangles
{
	public class SomeSurfaceAreaCalculator : ISurfaceAreaCalculator
	{
		// assumes triangles to be unique (no duplicate triangles)
		public double GetSurface(IEnumerable<Triangle> triangles)
		{
			// rounding errs?
			return triangles.Aggregate (0.0, 
				(sum, triangle) =>
					sum + CalcSurface(triangle)
				);
		}

		// this belongs to triangle...
		private static double CalcSurface(Triangle triangle)
		{
			var deltaB = triangle.B - triangle.A;
			var deltaC = triangle.C - triangle.A;
			// surface of the parrelelogram spanned by the vectors
			// divided by 2 to get the surface of the triangle
			return Vector3D.CrossProduct (deltaB, deltaC).Length / 2;
		}
	}
}

