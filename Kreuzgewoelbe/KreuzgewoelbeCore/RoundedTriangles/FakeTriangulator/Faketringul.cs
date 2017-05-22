using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace KreuzgewoelbeCore.RoundedTriangles.FakeTriangulator
{
    public class Faketringul : ITriangulator
    {
        public Triangulation<Vertex> GetTriangulation(IMeasuredData data)
        {
            int size = 100;
            var vertices = new Vertex[size, size];

            for (int x = 0; x < size; x++)
            {
                for (int y = 0; y < size; y++)
                {
                    vertices[y, x] = new Vertex(new Vector3D(x, y, F(x, y)), new List<Triangle>());
                }
            }

            Vertex[] result = new Vertex[size * size];
            for (int x = 0; x < size - 1; x++)
            {
                for (int y = 0; y < size - 1; y++)
                {
                    var t1 = new Triangle(vertices[y, x], vertices[y, x + 1], vertices[y + 1, x]);
                    var t2 = new Triangle(vertices[y + 1, x + 1], vertices[y + 1, x], vertices[y, x + 1]);

                    vertices[y, x].GetAlignedFaces().Add(t1);
                    vertices[y + 1, x + 1].GetAlignedFaces().Add(t2);

                    vertices[y, x + 1].GetAlignedFaces().Add(t1);
                    vertices[y, x + 1].GetAlignedFaces().Add(t2);

                    vertices[y + 1, x].GetAlignedFaces().Add(t1);
                    vertices[y + 1, x].GetAlignedFaces().Add(t2);

                    result[y + x * size] = vertices[y, x];
                }
            }

            return new Triangulation<Vertex>(result);
        }

        private double F(int x, int y)
        {
            return x * x + y * y;
        }
    }
}
