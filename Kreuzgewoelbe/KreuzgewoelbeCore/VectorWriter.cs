using System.Collections.Generic;
using System.Globalization;
using System.IO;

namespace KreuzgewoelbeCore
{
    public class VectorWriter
    {
        public void Write(string path, IEnumerable<Vector3D> points, char seperator = ',')
        {
            using (StreamWriter writer = new StreamWriter(path))
            {
                foreach (Vector3D point in points)
                {
                    writer.WriteLine(point.X.ToString(CultureInfo.InvariantCulture) + seperator + point.Y.ToString(CultureInfo.InvariantCulture) + seperator + point.Z.ToString(CultureInfo.InvariantCulture));
                }
            }
        }
    }
}