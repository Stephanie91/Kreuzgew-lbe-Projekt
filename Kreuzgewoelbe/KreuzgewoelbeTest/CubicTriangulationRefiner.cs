using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TriangulationRefiner.Cubic;
using Moq;
using KreuzgewoelbeCore.RoundedTriangles;
using KreuzgewoelbeCore;
using System.Linq;
using TriangulationRefiner;
using System.Collections;
using System.Collections.Generic;

namespace KreuzgewoelbeTest
{
    [TestClass]
    public class CubicTriangulationRefinerTest
    {
        [TestMethod]
        public void CubicMultipleTests()
        {
            const double maxDiff = 0.1;

            var result = GetNewVerticesFromTriangle(
                new Vector3D(1.23, 2.62, 4.08), new Vector3D(0.91, 1.51, 2.5),
                new Vector3D(0.31, 3.69, 3.36), new Vector3D(0.29, 2.79, 2.14),
                new Vector3D(2.87, 2.74, 3.04), new Vector3D(2.3, 2.36, 2.41));

            //assert
            //genau ein neuer Punkt hat ungefähr die mit Excel berechneten Werte
            Assert.AreEqual(1, result.Where(v =>
                 Math.Abs(v.Position.X - 0.8) < maxDiff
                 && Math.Abs(v.Position.Y - 3.2) < maxDiff
                 && Math.Abs(v.Position.Z - 3.7) < maxDiff).Count());
        }

        public IEnumerable<Vertex> GetNewVerticesFromTriangle(
            Vector3D vAPos, Vector3D vANorm,
            Vector3D vBPos, Vector3D vBNorm,
            Vector3D vCPos, Vector3D vCNorm)
        {
            //arrange
            var fakeEdgeExtractor = new Mock<IEdgeExtractor>();

            Triangle[] triangles = new Triangle[1];

            Vector3D vA = vAPos;
            Vector3D vB = vBPos;
            Vector3D vC = vCPos;

            VertexNormal vtA = new VertexNormal(vA, vANorm.Normalize(), triangles);
            VertexNormal vtB = new VertexNormal(vB, vBNorm.Normalize(), triangles);
            VertexNormal vtC = new VertexNormal(vC, vCNorm.Normalize(), triangles);
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


            return result.GetVertices().OfType<FaceEditableVertex>().ToList();
        }
    }
}
