using System;
using System.Text.RegularExpressions;
namespace C_Sharp_Monkey;
public static class TokenTypeExtensions
{
    public static string TypeToString(this TokenType tokenType)
    {
        return typeDictionary[tokenType];
    }

    public static TokenType LiteralToType(this string literal)
    {
        if (typeDictionary.Where(t => t.Value == literal).Count() > 0)
        {
            return typeDictionary.First(t => t.Value == literal).Key;
        }

        return TokenType.IDENT;
    }

    private static Dictionary<TokenType, string> typeDictionary = new Dictionary<TokenType, string>
    {
            { TokenType.ILLEGAL,  "ILLEGAL"},
            { TokenType.EOF,  "EOF"},
            { TokenType.IDENT,  "IDENT"}, // add, foobar, x, y, ...
            { TokenType.INT,  "INT"},   // 343456
            { TokenType.ASSIGN,  "="},
            { TokenType.PLUS,  "+"},
            { TokenType.MINUS,  "-"},
            { TokenType.BANG,  "!"},
            { TokenType.ASTERISK,  "*"},
            { TokenType.SLASH,  "/"},
            { TokenType.LT,  "<"},
            { TokenType.GT,  ">"},
            { TokenType.EQ,  "=="},
            { TokenType.NOT_EQ,  "!="},
            { TokenType.COMMA,  ","},
            { TokenType.SEMICOLON,  ";"},
            { TokenType.LPAREN,  "("},
            { TokenType.RPAREN,  ")"},
            { TokenType.LBRACE,  "{"},
            { TokenType.RBRACE,  "}"},
            { TokenType.FUNCTION,  "fn"},
            { TokenType.LET,  "let"},
            { TokenType.IF,  "if"},
            { TokenType.ELSE,  "else"},
            { TokenType.RETURN,  "return"},
            { TokenType.TRUE,  "true"},
            { TokenType.FALSE,  "false"},
    };

    public static bool IsKeyword(this string keyword)
    {
        switch (keyword)
        {
            case "fn":
            case "let":
            case "true":
            case "false":
            case "if":
            case "else":
            case "return":
            case "==":
            case "!=":
                return true;
            default: return false;
        }
    }

    public static bool IsLetter(this string? keyword)
    {
        if (keyword == null)
            return false;
        Regex rx = new Regex(@"[a-zA-Z]");
        return rx.Match(keyword) != Match.Empty;
    }

    public static bool IsNumber(this string? keyword)
    {
        if (keyword == null)
            return false;
        Regex rx = new Regex(@"\d");
        return rx.Match(keyword) != Match.Empty;
    }
}


