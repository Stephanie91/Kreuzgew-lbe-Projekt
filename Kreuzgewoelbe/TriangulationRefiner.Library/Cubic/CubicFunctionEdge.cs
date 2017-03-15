using KreuzgewoelbeCore;
using KreuzgewoelbeCore.RoundedTriangles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TriangulationRefiner.Cubic
{
    public class CubicFunctionEdge : ParameterizedFunctionEdge
    {
        public CubicFunctionEdge(VertexNormal start, VertexNormal end)
            : base(start, end)
        { }

        public CubicFunctionEdge(Edge<VertexNormal> toCopy)
            : this(toCopy.Start, toCopy.End)
        { }

        /// <summary>
        /// Benutzt Kubische Funktion nach Extremwerten umgestellt.
        /// Verfahren ist Extrem verkürzt, liefert effizient den Extremwert.
        /// </summary>
        /// <param name="gradientStart"></param>
        /// <param name="gradientEnd"></param>
        /// <returns>(t,f(t))</returns>
        protected override Tuple<double, double> GetNextVertex(double gradientStart, double gradientEnd)
        {
            double functionvalue;

            //faktor, der mehrmals verwendet wird.
            double n = 3 * (gradientStart + gradientEnd);

            //wenn Gradienten unterschiedlich, pq-Formel für die Ableitung der quadratischen Funktion
            if (n != 0)
            {
                //anderer faktor, der mehrmals verwendet wird.
                double m = (-2 * (gradientEnd + 2 * gradientStart)) / n;

                double halfM = m / 2;
                //nach dem +-
                double postSign = Math.Sqrt(halfM * halfM - gradientStart / n);

                //nullstellen
                double nst1 = -halfM + postSign;
                double nst2 = -halfM - postSign;

                bool nst1InRange = InRange(nst1);
                bool nst2InRange = InRange(nst2);

                if (!(nst1InRange ^ nst2InRange))
                {
                    throw new Exception(
                        "None or both Extremas are within 0 and 1."
                        + " No valid cubic funktion can be created.");
                }
                //entscheide, welche NST benutzt wird
                functionvalue = nst1InRange ? nst1 : nst2;
            }
            else
            {
                //wenn Steigung in beiden Seiten genau gleich: Extrema muss in der Mitte zwischen den Punkten liegen.
                functionvalue = 0.5; //Formel sollte immer 0.5 sein: gradientStart / (2 * (gradientEnd + 2 * gradientStart));
            }

            //gebe Extrempunkt/-Koordinate zurück
            return new Tuple<double, double>(functionvalue, GetFunctionValue(gradientStart, gradientEnd, functionvalue));

        }

        private double GetFunctionValue(double gradientStart, double gradientEnd, double t)
        {
            //gradientstart=h
            //gradientEnd=g
            //f(t)=(h+g)t^3+(-h-2g)t^2+gt+0

            return (gradientStart + gradientEnd) * t * t * t + (-2 * gradientStart - gradientEnd) * t * t + t * gradientStart;
        }

        private bool InRange(double val)
        {
            return 0 <= val && val <= 1;
        }
    }
}
