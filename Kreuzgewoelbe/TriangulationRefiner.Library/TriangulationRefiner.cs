using KreuzgewoelbeCore.RoundedTriangles;
using KreuzgewoelbeCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TriangulationRefiner
{
    public abstract class TriangulationRefiner : ITriangulationRefiner
    {
        private IEdgeExtractor _EdgeExtractor;

        public TriangulationRefiner(IEdgeExtractor edgeExtractor)
        {
            _EdgeExtractor = edgeExtractor;
        }

        /// <summary>
        /// Die hier zurückgegebene implementierung entscheidet über die verwendete Funktion über der Kante
        /// </summary>
        /// <returns></returns>
        protected abstract FunctionEdge FunctionEdgeFactory(Edge<VertexNormal> baseEdge);

        public Triangulation<Vertex> GetRefinedTriangulation(Triangulation<VertexNormal> triangulation)
        {
            var edges = _EdgeExtractor.GetEdges(triangulation).Select(e => FunctionEdgeFactory(e)).ToList();

            var triangles = GetEdgeTriples(edges);

            Triangle[] newTriangles = new Triangle[triangles.Count * 4];

            int index = 0;
            foreach (var fTriangle in triangles)
            {
                //neue randdreiecke
                newTriangles[index++] = CreateNewCornerTriangle(fTriangle, t => t.VertexA);
                newTriangles[index++] = CreateNewCornerTriangle(fTriangle, t => t.VertexB);
                newTriangles[index++] = CreateNewCornerTriangle(fTriangle, t => t.VertexC);

                //neues mittleres dreieck
                newTriangles[index++] = new Triangle(
                    fTriangle.Edge1.NextVertex,
                    fTriangle.Edge2.NextVertex,
                    fTriangle.Edge3.NextVertex);
            }
            //TODO select vertices from triangles

            return new Triangulation<Vertex>(null);
        }

        private Triangle CreateNewCornerTriangle(FunctionEdgeTriangle fTriangle,
            Func<Triangle, Vertex> cornerSelector)
        {
            Vertex corner = cornerSelector(fTriangle.Triangle);

            var closeEdges = new[] { fTriangle.Edge1, fTriangle.Edge2, fTriangle.Edge3 }
                .Where(e => e.Start.Equals(corner)).ToArray();

            if (closeEdges.Length != 2)
            {
                throw new Exception("Something is wrong here.");
            }

            return new Triangle(corner, closeEdges[0].NextVertex, closeEdges[1].NextVertex);
        }

        /// <summary>
        /// ordnet die Kanten ihren umgebenen Dreiecken zu.
        /// </summary>
        /// <param name="edges">jede kante mit funktion genau ein mal</param>
        /// <returns></returns>
        private List<FunctionEdgeTriangle> GetEdgeTriples(IEnumerable<FunctionEdge> edges)
        {
            var triangles = new List<FunctionEdgeTriangle>();

            //wähle für jede kante je ein anligendes Dreieck mit der Kante aus
            foreach (var anonEt in edges.SelectMany(e => new[]
            { 
                new { Edge = e, Triangle = e.LeftTriangle },
                new { Edge = e, Triangle = e.RightTriangle }
            }))
            {
                //nimm bereits erstelltes Dreieck
                var triangleEdgeTripel = triangles.FirstOrDefault(t => t.Triangle == anonEt.Triangle);

                //wenn noch keins erstellt ist, erstelle es
                if (triangleEdgeTripel == null)
                {
                    triangles.Add(new FunctionEdgeTriangle(anonEt.Triangle)
                    {
                        Edge1 = anonEt.Edge
                    });
                } //sonst füge es dem gefundenen Dreieck hinzu
                else if (triangleEdgeTripel.Edge2 == null)
                {
                    triangleEdgeTripel.Edge2 = anonEt.Edge;
                }
                else if (triangleEdgeTripel.Edge3 == null)
                {
                    triangleEdgeTripel.Edge3 = anonEt.Edge;
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
