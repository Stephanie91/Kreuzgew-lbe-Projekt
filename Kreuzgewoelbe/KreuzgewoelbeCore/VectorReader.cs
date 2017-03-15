using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;

namespace KreuzgewoelbeCore
{
    public class VectorReader
    {
        public IEnumerable<Vector3D> Read(string path, char seperator = ',')
        {
            int lineCnt = 1;
            char[] sep = new char[] { seperator };
            using (var reader = new StreamReader(path))
            {
                while (!reader.EndOfStream)
                {
                    string line = reader.ReadLine();
                    if (line != null)
                    {
                        string[] vec = line.Split(sep, StringSplitOptions.None);
                        if (vec.Length != 3)
                        {
                            throw new FormatException($"Wrong format in line: {lineCnt}");
                        }

                        yield return new Vector3D(
                            Convert.ToDouble(vec[0].Trim(), CultureInfo.InvariantCulture),
                            Convert.ToDouble(vec[1].Trim(), CultureInfo.InvariantCulture),
                            Convert.ToDouble(vec[2].Trim(), CultureInfo.InvariantCulture)
                        );
                    }
                    lineCnt++;
                }

            }
        }
    }
}
