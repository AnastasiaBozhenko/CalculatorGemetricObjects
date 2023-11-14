
namespace KalkulackaGeometrickychObjektu
{
    [AttributeUsage(AttributeTargets.Class)]
    public class GeomObjectAttribute:Attribute
    {
        public string Name { get; private set; }
        //public string Description { get; private set; }

        public GeomObjectAttribute(string name)
        {
            Name = name;
        }
    }
}
