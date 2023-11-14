
using System.Reflection;
using System.Xml.Linq;

namespace KalkulackaGeometrickychObjektu
{
    public abstract class AGeometricObject
    {
        public abstract void LoadValues(params double[] sides);

        public IDictionary<string, MethodProp> GetComputationMethods()
        {
            var methods = GetType().GetMethods().Where(m => m is { IsPublic: true, IsAbstract: false }
                                                            && m.GetCustomAttributes<CalculationOperationAttribute>(true).Any());
            var result = new Dictionary<string, MethodProp>();
            foreach (var methodInfo in methods)
            {
                var attr = methodInfo.GetCustomAttributes<CalculationOperationAttribute>(true).First();
                result.Add(attr.Name.ToLower(), new MethodProp(methodInfo, attr.Units));
            }
            return result;
        }
    }
}
