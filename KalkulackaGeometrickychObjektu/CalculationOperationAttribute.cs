
namespace KalkulackaGeometrickychObjektu
{
    [AttributeUsage(AttributeTargets.Method)]
    public class CalculationOperationAttribute:Attribute
    {
        public string Name { get; private set; }

        public string Units { get; private set; }
        //public string Description { get; private set; }

        public  CalculationOperationAttribute(string name, string units)
        {
            Name = name;
            Units = units;
        }
    }
}
