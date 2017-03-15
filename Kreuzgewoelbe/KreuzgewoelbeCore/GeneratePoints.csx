#r "C:\Windows\Microsoft.NET\Framework\v2.0.50727\System.dll"
#r "C:\Program Files (x86)\Reference Assemblies\Microsoft\Framework\v3.5\System.Core.dll"
#r "C:\Program Files (x86)\Reference Assemblies\Microsoft\Framework\v3.5\System.Xml.Linq.dll"
#r "C:\Program Files (x86)\Reference Assemblies\Microsoft\Framework\v3.5\System.Data.DataSetExtensions.dll"
#r ""
#r "C:\Windows\Microsoft.NET\Framework\v2.0.50727\System.Data.dll"
#r "C:\Windows\Microsoft.NET\Framework\v2.0.50727\System.Xml.dll"
#r "bin\Debug\KreuzgewoelbeCore.dll"
using KreuzgewoelbeCore;
var t = new TestPointGenerator();
var points = t.GenerateRegularPoints(1, 100);
var irrPoints = t.GenerateIrregularPoints(10000);
VectorWriter writer = new VectorWriter();
writer.Write(Path.Combine(Environment.CurrentDirectory, @"Regular.csv"), points, ';');
writer.Write(Path.Combine(Environment.CurrentDirectory, @"Irregular.csv"), irrPoints, ';');