using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;

namespace KreuzgewoelbeCore
{
    public class MeasuredDataFromCsv : IMeasuredData
    {
        private Vector3D[] _Vectors;

        public MeasuredDataFromCsv(string path)
        {
            _Vectors = ParseVectors(File.ReadAllLines(path));
        }

        private Vector3D[] ParseVectors(string[] lines)
        {
            Vector3D[] vectors = new Vector3D[lines.Length];

            for (int i = 0; i < lines.Length; i++)
            {
                string[] lineSplittet = lines[i].Split(';');
                vectors[i] = new Vector3D(double.Parse(lineSplittet[0], CultureInfo.InvariantCulture),
                    double.Parse(lineSplittet[1], CultureInfo.InvariantCulture),
                    double.Parse(lineSplittet[2], CultureInfo.InvariantCulture));
            }

            return vectors;
        }

        public IEnumerable<Vector3D> GetVectors()
        {
            return _Vectors;
        }
    }
}
