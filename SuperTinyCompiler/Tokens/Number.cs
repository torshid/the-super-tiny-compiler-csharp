using System;
using System.Collections.Generic;
using System.Text;

namespace SuperTinyCompiler.Tokens
{
    public class Number : Token
    {
        public long Value { get; set; }
    }
}
