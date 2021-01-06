using System;
using System.Collections.Generic;
using System.Text;

namespace SuperTinyCompiler.Nodes
{
    public class NumberLiteral : Node
    {
        public long Value { get; set; }

        public override Node Transform(Node parent)
        {
            return new NumberLiteral { Value = Value };
        }

        public override string Generate()
        {
            return Value.ToString();
        }
    }
}
