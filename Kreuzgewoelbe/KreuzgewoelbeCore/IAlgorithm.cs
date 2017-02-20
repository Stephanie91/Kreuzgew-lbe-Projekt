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

        /// <summary>
        /// Gibt Oberfläche zurück
        /// </summary>
        /// <returns></returns>
        double GetSurfaceArea();

        /// <summary>
        /// Gibt Darstellung der aktuellen Information über Daten zurück 
        /// </summary>
        /// <returns></returns>
        IViewdata GetView();

        /// <summary>
        /// Algorithmus Listener Informieren, dass eine neue Darstellung generiert wurde.
        /// Dies kann auch mehrere male geschehen, nachdem Messdaten zur verfügung gestellt wurden.
        /// </summary>
        event Action<IViewdata> ViewGenerated;
    }
}
