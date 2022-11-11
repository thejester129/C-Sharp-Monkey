using System;
namespace C_Sharp_Monkey
{
    public class TokenTypes
    {
        public static readonly string ILLEGAL = "ILLEGAL";
        public static readonly string EOF = "EOF";

        // Identifiers + literals
        public static readonly string IDENT = "IDENT"; // add, foobar, x, y, ...
        public static readonly string INT = "INT";   // 343456

        // Operators
        public static readonly string ASSIGN = "=";
        public static readonly string PLUS = "+";
        public static readonly string MINUS = "-";
        public static readonly string BANG = "!";
        public static readonly string ASTERISK = "*";
        public static readonly string SLASH = "/";
        public static readonly string LT = "<";
        public static readonly string GT = ">";
        public static readonly string EQ = "==";
        public static readonly string NOT_EQ = "!==";

        // Delimiters
        public static readonly string COMMA = ",";
        public static readonly string SEMICOLON = ";";

        public static readonly string LPAREN = "(";
        public static readonly string RPAREN = ")";
        public static readonly string LBRACE = "{";
        public static readonly string RBRACE = "}";

        // Keywords
        public static readonly string FUNCTION = "FUNCTION";
        public static readonly string LET = "LET";
        public static readonly string IF = "if";
        public static readonly string ELSE = "else";
        public static readonly string RETURN = "return";
        public static readonly string TRUE = "true";
        public static readonly string FALSE = "false";
    }
}

