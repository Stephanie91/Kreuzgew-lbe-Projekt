using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KreuzgewoelbeCore
{
    public interface IAlgorithm
    {
        /// <summary>
        /// Gibt Messdaten rein und berechnet
        /// </summary>
        /// <param name="daten"></param>
        void SetMeasuredData(IMeasuredData data);

        double GetSurfaceArea();

        IViewdata GetView();
    }
}
