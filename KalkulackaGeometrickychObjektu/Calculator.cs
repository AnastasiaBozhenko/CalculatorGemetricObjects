
using System.Globalization;
using System.Linq;
using System.Reflection;

namespace KalkulackaGeometrickychObjektu
{
    public class Calculator
    {
        //private string TheEnd = "Exit the program with any key...";
        private string InvalidChoice = "Invalid choice, press any key and repeat the choice.";

        /// <summary>
        /// Na zakladě parametrů zadaných v interaktivním moodu provede geometrické operace nad objektem
        /// </summary>
        public void CalcMain()
        {
            var types = Utils.GetDictionaryValues();

            var textInfoObjects = new CultureInfo("cs-CZ", false).TextInfo;

            string choice = "";
            while (choice != "end")
            {
                Console.Clear();
                Console.WriteLine("\n  ------------------------------------" +
                                    "\n  Calculator of geometric objects" +
                                    "\n  ------------------------------------" +
                                    "\n  Select the type of geometric object to calculate:\n");
                Console.WriteLine("\n  " + textInfoObjects.ToTitleCase(string.Join("\n  ", types.Keys.ToList())));

                choice = Console.ReadLine().ToLower();
                types.TryGetValue(choice, out var typeOfObject);
                if (typeOfObject == null)
                {
                    Console.WriteLine(InvalidChoice);
                    break;
                }

                //Vytvoření instance objektu
                var instanceOfObject=Activator.CreateInstance(typeOfObject) as AGeometricObject;
                if (instanceOfObject == null)
                {
                    Console.WriteLine(InvalidChoice);
                    break;
                }
                instanceOfObject.LoadValues();

                //Uloženi do slovníku <string/název, method>
                var methods=instanceOfObject.GetComputationMethods();
                var textInfoMethods = new CultureInfo("cs-CZ", false).TextInfo;
                Console.WriteLine("\n  Select the type of operation:");
                Console.WriteLine("\n  "+ textInfoMethods.ToTitleCase(string.Join("\n  ", methods.Keys.ToList())));

                choice = Console.ReadLine().ToLower();
                methods.TryGetValue(choice, out var method);
                if (method == null)
                {
                    Console.WriteLine(InvalidChoice);
                    break;
                }

                //Vytvoření metody pro object(activator pro methods(Tuple:
                //method.Item1.Invoke(instanceOfObject, null)))
                var resultOfMethod = method.Method.Invoke(instanceOfObject, null);
                Console.WriteLine($"\nThe {choice} of the {typeOfObject.Name.ToLower()} is {resultOfMethod} {method.Units}.");
                Console.ReadKey();      
            }
        }

        //private string GeomObject;

        /// <summary>
        /// Na zakladě vstupních parametrů provede geometrické operace nad objektem
        /// </summary>
        /// <param name="GeomObject"></param>
        /// <param name="Method"></param>
        /// <param name="sides"></param>
        public double CalcMain( string GeomObject, string Method, IEnumerable<double> sides)
        {
            var types = Utils.GetDictionaryValues();
            types.TryGetValue(GeomObject, out var typeOfObject);
            if (typeOfObject == null)
            {
                throw new Exception(InvalidChoice);
            }
            //Vytvoření instance objektu
            var instanceOfObject = Activator.CreateInstance(typeOfObject) as AGeometricObject;
            if (instanceOfObject == null)
            {
                throw new Exception(InvalidChoice);
            }
            instanceOfObject.LoadValues(sides.ToArray());

            //Uloženi do slovníku <string/název, method>
            var methods = instanceOfObject.GetComputationMethods();
            methods.TryGetValue(Method, out var method);
            if (method == null)
            {
                throw new Exception(InvalidChoice);
            }
            //Vytvoření metody pro object(activator pro methods(Tuple:
            var resultOfMethod = method.Method.Invoke(instanceOfObject, null);
            return (double)resultOfMethod;
        }
         
        public void WriteResultOfCalc(string GeomObject, string Method, IEnumerable<double> sides)
        {
            var result=CalcMain(GeomObject, Method, sides);
            Console.WriteLine($"\nThe {Method} of the {GeomObject} is {result}.");
        }
        
        /// <summary>
        /// Vratí slovník všech objektů a metod k objektům.
        /// </summary>
        /// <returns>dictionary Object+methods</returns>
        public IDictionary<string,string> GetDictObjectAndMethod()
        {
            var types = Utils.GetDictionaryValues();
            var method = "";
            Dictionary<string, string> objectsAndMethods = new Dictionary<string, string>();
            foreach (var keyValue in types)
            {
                var instanceOfObject = Activator.CreateInstance(keyValue.Value) as AGeometricObject;
                var methods = instanceOfObject.GetComputationMethods().Keys;
                method = string.Join(',', methods);
                objectsAndMethods.Add(keyValue.Key, method);
            }
            return objectsAndMethods;
        }
    }
}
