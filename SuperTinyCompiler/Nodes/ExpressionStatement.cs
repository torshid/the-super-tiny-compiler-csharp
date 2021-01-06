using System;
using System.Collections.Generic;
using System.Text;

namespace SuperTinyCompiler.Nodes
{
    public class ExpressionStatement : Node
    {
        public CallExpression Expression { get; set; }

        public override Node Transform(Node parent)
        {
            throw new NotImplementedException();
        }

        public override string Generate()
        {
            return Expression.Generate() + ";";
        }
    }
}
