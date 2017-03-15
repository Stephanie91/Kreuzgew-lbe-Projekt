using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TriangulationRefiner.Cubic;
using Moq;
using KreuzgewoelbeCore.RoundedTriangles;
using KreuzgewoelbeCore;

namespace KreuzgewoelbeTest
{
    [TestClass]
    public class CubicTriangulationRefinerTest
    {
        [TestMethod]
        public void CubicTest()
        {
            //arrange
            var fakeEdgeExtractor = new Mock<IEdgeExtractor>();

            Triangle[] triangles = new Triangle[1];

            Vector3D vA = new Vector3D(0, 1, 0);
            Vector3D vB = new Vector3D(1, 1, 0);
            Vector3D vC = new Vector3D(0, 1, 1);

            VertexNormal vtA = new VertexNormal(vA, new Vector3D(-1, 1, -1), triangles);
            VertexNormal vtB = new VertexNormal(vB, vB, triangles);
            VertexNormal vtC = new VertexNormal(vC, vC, triangles);
            triangles[0] = new Triangle(vtA, vtC, vtB);

            var triangulation = new Triangulation<VertexNormal>(new[] { vtA, vtB, vtC });

            fakeEdgeExtractor.Setup(e => e.GetEdges(triangulation)).Returns(() => new[]
            {
             new Edge<VertexNormal>(vtA,vtB),   
             new Edge<VertexNormal>(vtB,vtC),   
             new Edge<VertexNormal>(vtC,vtA),   
            });


            var refiner = new CubicTriangulationRefiner(fakeEdgeExtractor.Object);


            //act
            var result = refiner.GetRefinedTriangulation(triangulation);


            //assert

        }

        public VertexNormal vtA { get; set; }
    }
}
