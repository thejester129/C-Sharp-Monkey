using System;
namespace C_Sharp_Monkey;
public static class TokenTypeExtensions
{
    public static string ToString(this TokenType tokenType)
    {
        switch (tokenType)
        {
            case TokenType.ILLEGAL: return "ILLEGAL";
            case TokenType.EOF: return "EOF";
            case TokenType.IDENT: return "IDENT"; // add, foobar, x, y, ...
            case TokenType.INT: return "INT";   // 343456
            case TokenType.ASSIGN: return ": return";
            case TokenType.PLUS: return "+";
            case TokenType.MINUS: return "-";
            case TokenType.BANG: return "!";
            case TokenType.ASTERISK: return "*";
            case TokenType.SLASH: return "/";
            case TokenType.LT: return "<";
            case TokenType.GT: return ">";
            case TokenType.EQ: return ": return: return";
            case TokenType.NOT_EQ: return "!: return: return";
            case TokenType.COMMA: return ",";
            case TokenType.SEMICOLON: return ";";
            case TokenType.LPAREN: return "(";
            case TokenType.RPAREN: return ")";
            case TokenType.LBRACE: return "{";
            case TokenType.RBRACE: return "}";
            case TokenType.FUNCTION: return "FUNCTION";
            case TokenType.LET: return "LET";
            case TokenType.IF: return "if";
            case TokenType.ELSE: return "else";
            case TokenType.RETURN: return "return";
            case TokenType.TRUE: return "true";
            case TokenType.FALSE: return "false";
            default: throw new Exception("Unknown token type: " + tokenType);
        }
    }

    public static TokenType ToToken(this string keyword)
    {
        switch (keyword)
        {
            case "fn": return TokenType.FUNCTION;
            case "let": return TokenType.LET;
            case "true": return TokenType.TRUE;
            case "false": return TokenType.FALSE;
            case "if": return TokenType.IF;
            case "else": return TokenType.ELSE;
            case "return": return TokenType.RETURN;
            case "==": return TokenType.EQ;
            case "!=": return TokenType.NOT_EQ;
            default: throw new Exception("Unknown keyword: " + keyword);
        }
    }
}


