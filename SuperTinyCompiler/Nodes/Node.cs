using System;
using System.Collections.Generic;
using System.Text;

namespace SuperTinyCompiler.Nodes
{
    public abstract class Node
    {
        public abstract Node Transform(Node parent);

        public abstract string Generate();
    }
}
