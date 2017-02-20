using KreuzgewoelbeCore.RoundedTriangles;
using KreuzgewoelbeCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TriangulationRefiner.Library
{
    public class CubicTriangulationRefiner : ITriangulationRefiner
    {
        private IEdgeExtractor _EdgeExtractor;

        public CubicTriangulationRefiner(IEdgeExtractor edgeExtractor)
        {
            _EdgeExtractor = edgeExtractor;
        }

        public ITriangulation GetRefinedTriangulation(INormalTriangulation triangulation)
        {
            var edges = _EdgeExtractor.GetEdges(triangulation).Select(e => new CubicFunctionEdge(e)).ToList();

            var triangles = GetEdgeTriples(edges);

            //TODO

            return new RefinedTriangulation();
        }

        private List<CubicEdgeTriangle> GetEdgeTriples(IEnumerable<CubicFunctionEdge> edges)
        {
            var triangles = new List<CubicEdgeTriangle>();

            foreach (var et in edges.SelectMany(e => new[]
            { 
                new { Edge = e, Triangle = e.LeftTriangle },
                new { Edge = e, Triangle = e.RightTriangle }
            }))
            {
                var triangleEdgeTripel = triangles.FirstOrDefault(t => t.Triangle == et.Triangle);

                if (triangleEdgeTripel == null)
                {
                    triangles.Add(new CubicEdgeTriangle
                    {
                        Triangle = et.Triangle,
                        AB = et.Edge
                    });
                }
                else if (triangleEdgeTripel.BC == null)
                {
                    triangleEdgeTripel.BC = et.Edge;
                }
                else if (triangleEdgeTripel.CA == null)
                {
                    triangleEdgeTripel.CA = et.Edge;
                }
                else
                {
                    throw new ArgumentException("Can not add a forth Edge to  triangle.");
                }

            }

            return triangles;
        }
    }
}
