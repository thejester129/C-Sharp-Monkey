using System;
namespace C_Sharp_Monkey
{
    public interface ILexer
    {
        Token NextToken();
    }

    public class Lexer : ILexer
    {
        public Lexer()
        {
        }

        public Token NextToken()
        {
            throw new NotImplementedException();
        }
    }
}

