using KreuzgewoelbeCore;
using KreuzgewoelbeCore.RoundedTriangles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace TriangulationRefiner
{
    /// <summary>
    /// parametrisiert Werte auf Bereich von 0 bis 1 in R.
    /// </summary>
    public abstract class ParameterizedFunctionEdge : FunctionEdge
    {
        private Vector3D _EdgeVector;

        public ParameterizedFunctionEdge(VertexNormal start, VertexNormal end)
            : base(start, end)
        {
            _EdgeVector = end.Position - start.Position;
        }

        /// <summary>
        /// Berechne wert im Parametrisierten Raum.
        /// </summary>
        /// <param name="gradientStart">Steigung in x=0</param>
        /// <param name="gradientEnd">steigung in x=1</param>
        /// <returns>gibt (x,y) im R zurück</returns>
        protected abstract Tuple<double, double> GetNextVertex(double gradientStart, double gradientEnd);

        protected sealed override FaceEditableVertex GetNextVertex()
        {
            var gradientStart = new GradientResult(this, p => p.Start);

            var gradientEnd = new GradientResult(this, p => p.End);

            //sonderfall: nehme mittelpunkt der geraden
            if (gradientStart.Gradient == 0 && gradientEnd.Gradient == 0)
            {
                return new FaceEditableVertex(Start.Position + _EdgeVector * 0.5);
            }
            else
            {
                //Übergebe Parametrisierte Werte.
                //steigung in B wird negativ, damit die Funktion hier sinkt
                var parameterizedValues = GetNextVertex(gradientStart.Gradient, gradientEnd.Gradient);

                //zurück parametrisieren der Werte
                Vector3D interpolatedUpvector =
                    (gradientStart.UpVector * (1 - parameterizedValues.Item1)
                    + gradientEnd.UpVector * (parameterizedValues.Item1))
                    .Normalize();

                Vector3D position =
                    Start.Position
                    + parameterizedValues.Item1 * _EdgeVector
                    + parameterizedValues.Item2 * interpolatedUpvector;

                return new FaceEditableVertex(position);
            }
        }

        private class GradientResult
        {
            public double Gradient { get; set; }
            public Vector3D Lot { get; set; }
            public Vector3D GradientVector { get; set; }
            public Vector3D UpVector { get; set; }

            public GradientResult(ParameterizedFunctionEdge edge, Func<ParameterizedFunctionEdge, VertexNormal> vertexSelector)
            {
                Vector3D normalVector = vertexSelector(edge).Normal;

                Lot = Vector3D.CrossProduct(normalVector, edge._EdgeVector);
                GradientVector = Vector3D.CrossProduct(Lot, normalVector).Normalize();
                UpVector = Vector3D.CrossProduct(edge._EdgeVector, Lot).Normalize();

                //formel für gradient ignoriert evtl. lineare abhängigkeiten
                double grad;

                bool b1 = TryGradientFromVector(edge, v => v.X, v => v.Y, out  grad);
                bool b2 = TryGradientFromVector(edge, v => v.X, v => v.Z, out  grad);
                bool b3 = TryGradientFromVector(edge, v => v.Y, v => v.Z, out  grad);
                bool b4 = TryGradientFromVector(edge, v => v.Y, v => v.X, out  grad);

                if (!TryGradientFromVector(edge, v => v.X, v => v.Y, out grad))
                {
                    if (!TryGradientFromVector(edge, v => v.X, v => v.Z, out grad))
                    {
                        if (!TryGradientFromVector(edge, v => v.Y, v => v.Z, out grad))
                        {
                            throw new ArgumentException("Rays dont match.");
                        }
                    }
                }

                Gradient = grad;
            }

            private bool TryGradientFromVector(
                ParameterizedFunctionEdge edge,
                Func<Vector3D, double> component1,
                Func<Vector3D, double> component2,
                out double result)
            {
                double divider = (
                component1(UpVector) * component2(GradientVector)
                - component2(UpVector) * component1(GradientVector)
                );

                if (divider == 0)
                {
                    result = 0;
                    return false;
                }
                else
                {
                    result = (component2(edge.End.Position) * component1(GradientVector)
                            - component2(edge.Start.Position) * component1(GradientVector)
                            - component1(edge.End.Position) * component2(GradientVector)
                            + component1(edge.Start.Position) * component2(GradientVector))
                            / divider;

                    return true;
                }
            }
        }
    }
}
