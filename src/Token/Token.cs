using System;
namespace C_Sharp_Monkey
{
    public class Token
    {
        public TokenType TokenType { get; private set; }
        public string? Literal { get; private set; }

        public Token(TokenType tokenType, string? literal)
        {
            this.TokenType = tokenType;
            this.Literal = literal;
        }

    }
}