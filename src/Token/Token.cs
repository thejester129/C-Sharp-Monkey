using System;
namespace C_Sharp_Monkey
{
    public class Token
    {
        public TokenType Type { get; private set; }
        public string? Literal { get; private set; }

        public Token(TokenType tokenType, string? literal)
        {
            this.Type = tokenType;
            this.Literal = literal;
        }

    }
}