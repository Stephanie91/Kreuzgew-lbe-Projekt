using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TriangulationRefiner
{
    class Lazy<T>
    {
        private Func<T> _GetValue;
        private T _Value;

        public bool IsLoaded { get; private set; }

        public T Value
        {
            get
            {
                if (!IsLoaded)
                {
                    _Value = _GetValue();
                    IsLoaded = true;
                }
                return _Value;
            }
        }

        public Lazy(Func<T> getValue)
        {
            _GetValue = getValue;
        }
    }
}
