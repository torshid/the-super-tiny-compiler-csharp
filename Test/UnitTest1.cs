using Newtonsoft.Json;
using NUnit.Framework;
using SuperTinyCompiler;
using SuperTinyCompiler.Nodes;
using System;

namespace Test
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Test1()
        {
            string input = "(add 2 (subtract 4 2)) (del 1)";

            string output = Compiler.Compile(input);

            Console.WriteLine(output);
        }
    }
}