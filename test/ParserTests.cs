using System.Collections.Generic;
using System.Linq;
using C_Sharp_Monkey;
using C_Sharp_Monkey.AST;
using Newtonsoft.Json.Linq;
using NUnit.Framework;

namespace C_Sharp_Monkey_Tests;

public class ParserTests
{

    [Test]
    public void TestLetStatements()
    {
        var input = new List<Token>{
            new Token(TokenType.LET, "let"),
            new Token(TokenType.IDENT, "x"),
            new Token(TokenType.ASSIGN, "="),
            new Token(TokenType.INT, "5"),
            new Token(TokenType.SEMICOLON, ";"),
            new Token(TokenType.LET, "let"),
            new Token(TokenType.IDENT, "y"),
            new Token(TokenType.ASSIGN, "="),
            new Token(TokenType.INT, "10"),
            new Token(TokenType.SEMICOLON, ";"),
            new Token(TokenType.LET, "let"),
            new Token(TokenType.IDENT, "fooBar"),
            new Token(TokenType.ASSIGN, "="),
            new Token(TokenType.INT, "838383"),
            new Token(TokenType.SEMICOLON, ";"),
            new Token(TokenType.EOF, ""),
        };

        var sut = new Parser(input);

        var output = sut.Parse();

        Assert.NotNull(output);

        Assert.AreEqual(3, output.Statements.Count());

        TestLetStatement(output.Statements[0], "x", 5);
        TestLetStatement(output.Statements[1], "y", 10);
        TestLetStatement(output.Statements[2], "fooBar", 838383);
    }

    private void TestLetStatement(IStatement statement, string expectedName, int expectedValue)
    {
        Assert.AreEqual(TokenType.LET, statement.TokenType);
        Assert.True(statement is LetStatement);

        var letStatement = statement as LetStatement;

        Assert.AreEqual(expectedName, letStatement.Name.Literal);
        //Assert.Equals(expectedValue, letStatement.Value);
    }
}