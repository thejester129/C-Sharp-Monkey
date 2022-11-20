using System;
namespace C_Sharp_Monkey;
public interface ILexer
{
    Token NextToken();
}

public class Lexer : ILexer
{
    private string input;
    private int position;
    private int readPosition;
    private string? currentChar;
    public Lexer(string input)
    {
        this.input = input;
        this.position = 0;
        this.readPosition = 0;
    }

    public Token NextToken()
    {
        ReadNextChar();
        SkipWhitespace();

        if (this.currentChar == null)
            return new Token(TokenType.EOF, "");

        if (this.oneCharTokens.Contains(this.currentChar.LiteralToType()))
            return new Token(this.currentChar.LiteralToType(), this.currentChar);

        if (this.currentChar == "=")
        {
            if (PeekNextChar() == "=")
            {
                ReadNextChar();
                return new Token(TokenType.EQ, "==");
            }

            return new Token(TokenType.ASSIGN, "=");
        }

        if (this.currentChar == "!")
        {
            if (PeekNextChar() == "=")
            {
                ReadNextChar();
                return new Token(TokenType.NOT_EQ, "!=");
            }

            return new Token(TokenType.BANG, "!");
        }

        if (this.currentChar.IsLetter())
            return ReadWord();

        if (this.currentChar.IsNumber())
            return ReadNumber();

        return new Token(TokenType.ILLEGAL, this.currentChar);
    }

    private void ReadNextChar()
    {
        if (this.readPosition >= input.Length)
        {
            this.currentChar = null;
            return;
        }
        this.currentChar = input[readPosition].ToString();
        this.position = this.readPosition;
        this.readPosition++;
        return;
    }

    private void SkipWhitespace()
    {
        while (this.currentChar == " "
            || this.currentChar == "\t"
            || this.currentChar == "\n"
            || this.currentChar == "\r")
        {
            ReadNextChar();
        }
    }
    private string? PeekNextChar()
    {
        if (this.readPosition >= input.Length)
        {
            this.currentChar = null;
            return null;
        }
        return input[readPosition].ToString();
    }

    private Token ReadWord()
    {
        var literal = this.currentChar;
        if (literal == null)
            return new Token(TokenType.ILLEGAL, this.currentChar);

        while (PeekNextChar().IsLetter())
        {
            ReadNextChar();
            literal += this.currentChar;
        }

        return new Token(literal.LiteralToType(), literal);
    }

    private Token ReadNumber()
    {
        var literal = this.currentChar;
        if (literal == null)
            return new Token(TokenType.ILLEGAL, this.currentChar);

        while (PeekNextChar().IsNumber())
        {
            ReadNextChar();
            literal += this.currentChar;
        }

        return new Token(TokenType.INT, literal);
    }
    private List<TokenType> oneCharTokens = new List<TokenType>{
        TokenType.PLUS,
        TokenType.MINUS,
        TokenType.LPAREN,
        TokenType.RPAREN,
        TokenType.LBRACE,
        TokenType.RBRACE,
        TokenType.COMMA,
        TokenType.SEMICOLON,
        TokenType.SLASH,
        TokenType.ASTERISK,
        TokenType.GT,
        TokenType.LT,
        TokenType.EOF
    };
}

