using SuperTinyCompiler.Nodes;
using SuperTinyCompiler.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SuperTinyCompiler
{
    public class Compiler
    {
        public static Token[] Tokenize(string input)
        {
            int index = 0;

            List<Token> tokens = new List<Token>();

            while (index < input.Length)
            {
                char currentChar = input[index];

                if (currentChar == '(' || currentChar == ')')
                {
                    tokens.Add(new Parenthesis()
                    {
                        Value = currentChar == '(' ? Parenthesis.Type.Start : Parenthesis.Type.End
                    });

                    index++;
                    continue;
                }

                if (char.IsWhiteSpace(currentChar))
                {
                    index++;
                    continue;
                }

                if (char.IsDigit(currentChar))
                {
                    string digits = string.Empty;

                    do
                    {
                        digits += currentChar;
                    } while (char.IsDigit(currentChar = input[++index]));

                    tokens.Add(new Number()
                    {
                        Value = long.Parse(digits)
                    });

                    continue;
                }

                if (currentChar == '"')
                {
                    string chars = string.Empty;

                    while ((currentChar = input[++index]) != '"')
                    {
                        chars += currentChar;
                    }

                    index++;

                    tokens.Add(new Tokens.String()
                    {
                        Value = chars
                    });

                    continue;
                }

                if (char.IsLetter(currentChar))
                {
                    string chars = string.Empty;

                    do
                    {
                        chars += currentChar;
                    } while (char.IsLetter(currentChar = input[++index]));

                    tokens.Add(new Name()
                    {
                        Value = chars
                    });

                    continue;
                }

                throw new Exception("Could not determine token");
            }

            return tokens.ToArray();
        }

        public static AST Parse(Token[] tokens)
        {
            int index = 0;

            Node Walk()
            {
                Token token = tokens[index];

                if (token is Number)
                {
                    return new NumberLiteral { Value = ((Number)tokens[index++]).Value };
                }

                if (token is Tokens.String)
                {
                    return new StringLiteral { Value = ((Tokens.String)tokens[index++]).Value };
                }

                if (token is Parenthesis && ((Parenthesis)token).Value == Parenthesis.Type.Start)
                {
                    token = tokens[++index];

                    CallExpression callExpression = new CallExpression
                    {
                        Name = ((Name)token).Value, // assuming next token is a name
                        Parameters = new List<Node>()
                    };

                    token = tokens[++index];

                    while (!(token is Parenthesis parenthesis) || parenthesis.Value != Parenthesis.Type.End)
                    {
                        callExpression.Parameters.Add(Walk());

                        token = tokens[index];
                    }

                    index++;

                    return callExpression;
                }

                throw new Exception("Unmanaged token");
            }

            AST ast = new AST
            {
                Body = new List<Node>()
            };

            while (index < tokens.Length)
            {
                ast.Body.Add(Walk());
            }

            return ast;
        }

        public static string Generate(AST ast)
        {
            return ast.Transform(null).Generate();
        }

        public static string Compile(string input)
        {
            return Generate(Parse(Tokenize(input)));
        }
    }
}
