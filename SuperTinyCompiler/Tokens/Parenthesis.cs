using System;
using System.Collections.Generic;
using System.Text;

namespace SuperTinyCompiler.Tokens
{
    public class Parenthesis : Token
    {
        public Type Value { get; set; }

        public enum Type
        {
            Start,
            End
        }
    }
}
