using System;
using System.Collections.Generic;
using System.Text;

namespace SuperTinyCompiler.Tokens
{
    public class String : Token
    {
        public string Value { get; set; }
    }
}
