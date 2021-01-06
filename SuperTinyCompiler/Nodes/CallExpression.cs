using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SuperTinyCompiler.Nodes
{
    public class CallExpression : Node
    {
        public string Name { get; set; }

        public List<Node> Parameters { get; set; }

        public override Node Transform(Node parent)
        {
            CallExpression callExpression = new CallExpression();
            callExpression.Name = Name;
            callExpression.Parameters = Parameters.Select(n => n.Transform(callExpression)).ToList();

            if (!(parent is CallExpression))
            {
                return new ExpressionStatement { Expression = callExpression };
            }

            return callExpression;
        }

        public override string Generate()
        {
            return Name + "(" + string.Join(", ", Parameters.Select(n => n.Generate())) + ")";
        }
    }
}
