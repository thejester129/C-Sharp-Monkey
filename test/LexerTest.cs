using System.Collections.Generic;
using C_Sharp_Monkey;
using Newtonsoft.Json.Linq;
using NUnit.Framework;

namespace C_Sharp_Monkey_Tests;

public class Tests
{
    private Lexer Sut;

    [SetUp]
    public void Setup()
    {
        Sut = new Lexer();
    }

    [Test]
    public void TestBasicTokens()
    {
        var input = "=+(){},;";

        var expectedTokens = new List<(string, string)> {
            (TokenTypes.ASSIGN, "="),
            (TokenTypes.PLUS, "+"),
            (TokenTypes.LPAREN, "("),
            (TokenTypes.RPAREN, ")"),
            (TokenTypes.LBRACE, "{"),
            (TokenTypes.RBRACE, "}"),
            (TokenTypes.COMMA, ","),
            (TokenTypes.SEMICOLON, ";"),
            (TokenTypes.EOF, ""),
        };

        InsureExpectedTokens(input, expectedTokens);
    }

    [Test]
    public void TestMultilineString()
    {
        var input = @"let five = 5;
                    let ten = 10;
                    let add = fn(x, y) {
                        x + y;
                    };
                    let result = add(five, ten);
                    !-/*5;
                    5 < 10 > 5;

                    if (5 < 10) {
                        return true;
                    } else {
                        return false;
                    }
                    10 == 10;
                    10 != 9;";

        var expectedTokens = new List<(string, string)>
            { 
                (TokenTypes.LET, "let"),
                (TokenTypes.IDENT, "five"),
                (TokenTypes.ASSIGN, "="),
                (TokenTypes.INT, "5"),
                (TokenTypes.SEMICOLON, ";"),
                (TokenTypes.LET, "let"),
                (TokenTypes.IDENT, "ten"),
                (TokenTypes.ASSIGN, "="),
                (TokenTypes.INT, "10"),
                (TokenTypes.SEMICOLON, ";"),
                (TokenTypes.LET, "let"),
                (TokenTypes.IDENT, "add"),
                (TokenTypes.ASSIGN, "="),
                (TokenTypes.FUNCTION, "fn"),
                (TokenTypes.LPAREN, "("),
                (TokenTypes.IDENT, "x"),
                (TokenTypes.COMMA, ","),
                (TokenTypes.IDENT, "y"),
                (TokenTypes.RPAREN, ")"),
                (TokenTypes.LBRACE, "{"),
                (TokenTypes.IDENT, "x"),
                (TokenTypes.PLUS, "+"),
                (TokenTypes.IDENT, "y"),
                (TokenTypes.SEMICOLON, ";"),
                (TokenTypes.RBRACE, "}"),
                (TokenTypes.SEMICOLON, ";"),
                (TokenTypes.LET, "let"),
                (TokenTypes.IDENT, "result"),
                (TokenTypes.ASSIGN, "="),
                (TokenTypes.IDENT, "add"),
                (TokenTypes.LPAREN, "("),
                (TokenTypes.IDENT, "five"),
                (TokenTypes.COMMA, ","),
                (TokenTypes.IDENT, "ten"),
                (TokenTypes.RPAREN, ")"),
                (TokenTypes.SEMICOLON, ";"),
                (TokenTypes.BANG, "!"),
                (TokenTypes.MINUS, "-"),
                (TokenTypes.SLASH, "/"),
                (TokenTypes.ASTERISK, "*"),
                (TokenTypes.INT, "5"),
                (TokenTypes.SEMICOLON, ";"),
                (TokenTypes.INT, "5"),
                (TokenTypes.LT, "<"),
                (TokenTypes.INT, "10"),
                (TokenTypes.GT, ">"),
                (TokenTypes.INT, "5"),
                (TokenTypes.SEMICOLON, ";"),
                (TokenTypes.IF, "if"),
                (TokenTypes.LPAREN, "("),
                (TokenTypes.INT, "5"),
                (TokenTypes.LT, "<"),
                (TokenTypes.INT, "10"),
                (TokenTypes.RPAREN, ")"),
                (TokenTypes.LBRACE, "{"),
                (TokenTypes.RETURN, "return"),
                (TokenTypes.TRUE, "true"),
                (TokenTypes.SEMICOLON, ";"),
                (TokenTypes.RBRACE, "}"),
                (TokenTypes.ELSE, "else"),
                (TokenTypes.LBRACE, "{"),
                (TokenTypes.RETURN, "return"),
                (TokenTypes.FALSE, "false"),
                (TokenTypes.SEMICOLON, ";"),
                (TokenTypes.RBRACE, "}"),
                (TokenTypes.INT, "10"),
                (TokenTypes.EQ, "=="),
                (TokenTypes.INT, "10"),
                (TokenTypes.SEMICOLON, ";"),
                (TokenTypes.INT, "10"),
                (TokenTypes.NOT_EQ, "!="),
                (TokenTypes.INT, "9"),
                (TokenTypes.SEMICOLON, ";"),
                (TokenTypes.EOF, "")
            };

        InsureExpectedTokens(input, expectedTokens);
    }

    // Helper
    private void InsureExpectedTokens(string input, List<(string, string)> expectedTokens)
    {
        foreach(var expected in expectedTokens)
        {
            var nextToken = Sut.NextToken();
            var expectedType = expected.Item1;
            var expectedLiteral = expected.Item2;

            Assert.AreEqual(expectedType, nextToken.TokenType);
            Assert.AreEqual(expectedLiteral, nextToken.Literal);
        }
    }
}
