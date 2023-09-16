using System;
using System.Threading.Tasks;
using Microsoft.CodeAnalysis.CSharp.Scripting;
using Microsoft.CodeAnalysis.Scripting;

namespace TestRoslyn
{
    class Program
    {

        static async Task Main()
        {
            // Define a C# script as a string
            string code = @"
                using System;
            
                public class Calculator
                {
                    public int Add(int a, int b)
                    {
                        return a + b;
                    }
                }

                new Calculator().Add(5, 7)
            ";

            try
            {
                // Compile and execute the C# script
                var result = await CSharpScript.EvaluateAsync<int>(code);

                Console.WriteLine($"Result of the script: {result}");
            }
            catch (CompilationErrorException e)
            {
                Console.WriteLine($"Compilation error: {string.Join(Environment.NewLine, e.Diagnostics)}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex}");
            }
            
            Console.ReadKey();
        }
    }
}