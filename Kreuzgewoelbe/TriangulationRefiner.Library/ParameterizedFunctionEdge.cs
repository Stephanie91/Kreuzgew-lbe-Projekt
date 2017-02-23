using KreuzgewoelbeCore;
using KreuzgewoelbeCore.RoundedTriangles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        protected abstract EditableVertex GetNextVertex(double gradientStart, double gradientEnd);

        protected sealed override EditableVertex GetNextVertex()
        {
            var gradientStart = GetGradientOverEdge(Start.Normal);
            //steigung wird negativ, damit die Funktion hier sinkt
            var gradientEnd = -GetGradientOverEdge(End.Normal);

            //sonderfall: nehme mittelpunkt der geraden
            if (gradientStart == 0 && gradientEnd == 0)
            {
                return new EditableVertex(Start.Position + _EdgeVector * 0.5);
            }
            else
            {
                return GetNextVertex(gradientStart, gradientEnd);
            }
        }

        private double GetGradientOverEdge(Vector3D normal)
        {
            //lot auf normalvektor und kante
            var lot = Vector3D.CrossProduct(normal, _EdgeVector);
            //steigungsvektor
            var gradientVector = Vector3D.CrossProduct(lot, normal);
            //Vector that is pointing from edge towards its gradient
            //it can be placed anywhere on the edge, this is still true.
            var upVector = Vector3D.CrossProduct(lot, _EdgeVector).Normalize();
            //formel für parametrisierte steigung nach dokumentation
            double gradient =
                (End.Position.Y * gradientVector.X
                - Start.Position.Y * gradientVector.X
                - End.Position.X * gradientVector.Y
                + Start.Position.X * gradientVector.Y)
                / (
                upVector.X * gradientVector.Y
                - upVector.Y * gradientVector.X
                );

            return gradient;
        }
    }
}
