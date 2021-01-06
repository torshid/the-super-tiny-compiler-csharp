using System;
using System.Collections.Generic;
using System.Text;

namespace SuperTinyCompiler.Nodes
{
    public class StringLiteral : Node
    {
        public string Value { get; set; }

        public override Node Transform(Node parent)
        {
            return new StringLiteral { Value = Value };
        }

        public override string Generate()
        {
            return "\"" + Value + "\"";
        }
    }
}
