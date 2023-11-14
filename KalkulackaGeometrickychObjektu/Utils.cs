
namespace KalkulackaGeometrickychObjektu
{
    public static class Utils
    {
        /// <summary>
        /// Zjisti parametr (stranu) pro výpočet 
        /// </summary>
        /// <param name="NameOfside"></param>
        /// <param name="gemetricObject"></param>
        /// <param name="side"></param>
        public static void FindOutSide(string NameOfside, string gemetricObject, out double side)
        {
            Console.WriteLine($"\nEnter the {NameOfside} of the {gemetricObject} for calculation in centimetres: ");
            string side_ =Console.ReadLine().Trim();
            while (!double.TryParse(side_, out side) || side <= 0)
            {
                Console.WriteLine($"\nThe value of the {NameOfside} must be a number greater than 0. \nEnter {NameOfside} again:");
                side_ = Console.ReadLine().Trim();
            }           
        }
        /// <summary>
        /// Vrati název(attribute) class 
        /// </summary>
        /// <param name="classType"></param>
        /// <returns>Jmeno attributu(class)</returns>
        public static string? GetGeometricAttribute(Type classType)
        {
            GeomObjectAttribute geomObjectAttribute = Attribute.GetCustomAttribute(classType, typeof(GeomObjectAttribute)) as GeomObjectAttribute;
            return geomObjectAttribute?.Name;
        }
        /// <summary>
        /// Vratí slovník objektů <název, typ>
        /// </summary>
        /// <returns>slovník objektů(název, typ)</returns>
        public static IDictionary<string, Type> GetDictionaryValues()
        {
            //Make an array for the list of assemblies(GetAssemblies()).
            var types = AppDomain.CurrentDomain.GetAssemblies().SelectMany(x => x.GetTypes())
                .Where(x => typeof(AGeometricObject).IsAssignableFrom(x) && !x.IsInterface && !x.IsAbstract).ToList();

            IDictionary<string, Type> dictionary = new Dictionary<string, Type>();
            foreach (var geometricObject in types)
            {
                dictionary.Add(GetGeometricAttribute(geometricObject).ToLower(), geometricObject);
            }
            return dictionary;
        }
    }
}
