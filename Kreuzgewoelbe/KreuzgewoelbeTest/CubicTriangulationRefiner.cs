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
            VertexNormal vA = new VertexNormal(default(Vector3D), default(Vector3D), triangles);
            VertexNormal vB = new VertexNormal(default(Vector3D), default(Vector3D), triangles);
            VertexNormal vC = new VertexNormal(default(Vector3D), default(Vector3D), triangles);
            triangles[0] = new Triangle(vA, vB, vC);

            var triangulation = new Triangulation<VertexNormal>(new[] { vA, vB, vC });

            fakeEdgeExtractor.Setup(e => e.GetEdges(triangulation)).Returns(() => new[]
            {
             new Edge<VertexNormal>(vA,vB),   
            });


            var refiner = new CubicTriangulationRefiner(fakeEdgeExtractor.Object);


            //act
            var result = refiner.GetRefinedTriangulation(triangulation);


            //assert

        }
    }
}
