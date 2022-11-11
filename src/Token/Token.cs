using System;
namespace C_Sharp_Monkey
{
    public class Token
    {
        public string TokenType { get; private set; }
        public string Literal { get; private set; }

        public Token(string tokenType, string literal)
        {
            this.TokenType = tokenType;
            this.Literal = literal;
        }

    }
}