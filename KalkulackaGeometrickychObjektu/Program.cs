using System.CommandLine;
using System.CommandLine.Builder;
using System.CommandLine.Help;
using System.CommandLine.Invocation;
using System.CommandLine.Parsing;

namespace KalkulackaGeometrickychObjektu
{
    class Program
    {
        public static int Main(string[] args)
        {
            Calculator calculator = new Calculator();

            var rootCommand = new RootCommand();

            var interactionCommand = new Command("interaction", "A command whose start app in interaction mood.");
            interactionCommand.AddAlias("I");
            rootCommand.AddCommand(interactionCommand);
            interactionCommand.SetHandler(() =>calculator.CalcMain());

            var objectOption = new Option<string>
                ("--object", "An option whose choose type of geometric object.")
                { IsRequired = true };
            objectOption.AddAlias("--O");

            var sideOptions=new Option<IEnumerable<double>>
                ("--sides", "An options whose arguments will use for calculate.")
                { AllowMultipleArgumentsPerToken = true, 
                  IsRequired = true };
            sideOptions.AddAlias("--S");

            var methodOption = new Option<string>
                ("--method", "An option whose choose type of geometric operation.")
                { IsRequired = true };
            methodOption.AddAlias("--M");

            var objectCommand = new Command("object", "A command whose start app in commandLine mood.")
            {
                objectOption,
                methodOption,
                sideOptions
            };
            objectCommand.AddAlias("O");
            rootCommand.AddCommand(objectCommand);

            objectCommand.SetHandler((objectValue, methodValue, sidesValues) =>
                calculator.WriteResultOfCalc(objectValue, methodValue, sidesValues),
                objectOption, methodOption, sideOptions
            );

            IDictionary<string, string> objectsAndMethods = calculator.GetDictObjectAndMethod();
            List<string> resultObjects = new List<string>();
            List<string> resultMethods = new List<string>();;
            foreach ( var pair in objectsAndMethods)
            {
                resultObjects.Add(pair.Key);
                resultMethods.Add(pair.Value);
            }

            var parser = new CommandLineBuilder(objectCommand)
                .UseDefaults()
                .UseHelp(ctx =>
                {
                    ctx.HelpBuilder.CustomizeSymbol(objectOption,
                        firstColumnText: $"--object\n{string.Join("\n", resultObjects)}",
                        secondColumnText: $"--method\n{string.Join("\n", resultMethods)}"); 
                })
                .Build();

            parser.Invoke("-h");

            return rootCommand.Invoke(args);
        }
}
}