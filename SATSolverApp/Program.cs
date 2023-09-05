using SATSolverLib;
using System.Text;

var filePath = "C:/Users/Denis/Documents/RiderProjects/SATSolverLib/TestApp/TestFiles/sat_100_449.txt";

if (!File.Exists(filePath))
    throw new ArgumentException($"File on path {filePath} does not exist");

var cnf = DimacsParser.ParseFile(filePath);
var isSat = Solver.Dpll(cnf, out var solution);

WriteModelToConsole(solution);
return;

static void WriteModelToConsole(bool[] model)
{
    if (!model[0])
    {
        Console.WriteLine("s NOT SATISFIABLE");
    }
    else
    {
        var builder = new StringBuilder("s SATISFIABLE");
        builder.Append('\n');
        builder.Append("v ");
        for (int i = 1; i < model.Length; i++)
        {
            builder.Append(model[i] ? i : -i);
            builder.Append(' ');
        }

        builder.Append(0);
        Console.WriteLine(builder.ToString());
    }
}