using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace KalkulackaGeometrickychObjektu
{
    public class MethodProp
    {
        public MethodInfo Method { get; private set; }
        public string Units { get; private set; }

        public MethodProp(MethodInfo method, string units)
        {
            Method= method;
            Units = units;
        }
    }
}
