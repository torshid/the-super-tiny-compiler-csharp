using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SuperTinyCompiler.Nodes
{
    public class AST : Node
    {
        public List<Node> Body { get; set; }

        public override Node Transform(Node parent)
        {
            AST ast = new AST();
            ast.Body = Body.Select(n => n.Transform(ast)).ToList();
            return ast;
        }

        public override string Generate()
        {
            return string.Join("\r\n", Body.Select(n => n.Generate()));
        }
    }
}
