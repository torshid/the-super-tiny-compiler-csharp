using System;

namespace CompilerConsole
{
    class Program
    {
        static void Main()
        {
            while(true)
            {
                Console.WriteLine("========================================================");

                string output = SuperTinyCompiler.Compiler.Compile(Console.ReadLine());

                Console.WriteLine("---------------------------");

                Console.WriteLine(output);
            }
        }
    }
}
