namespace C_Sharp_Monkey.AST;

public class Parser
{
    private List<Token> tokens;
    private Token currentToken;
    private Token nextToken;

    public List<string> Errors { get; private set; } = new List<string>();
    public Parser(List<Token> tokens)
    {
        this.tokens = tokens;
        this.currentToken = tokens.ElementAt(0);
        this.nextToken = tokens.ElementAt(1);
    }
    public ProgramNode Parse()
    {
        var programNode = new ProgramNode();

        while (this.currentToken.Type != TokenType.EOF)
        {
            var statement = ParseStatement();
            if (statement != null)
            {
                programNode.Statements.Add(statement);
            }
            AdvanceToken();
        }

        return programNode;
    }

    private void AdvanceToken()
    {
        this.currentToken = nextToken;
        this.nextToken = tokens.IndexOf(nextToken) < tokens.Count() - 1
                            ? tokens.ElementAt(tokens.IndexOf(nextToken) + 1)
                            : nextToken;

    }

    private IStatement? ParseStatement()
    {
        switch (currentToken.Type)
        {
            case TokenType.LET: return ParseLetStatement();
            case TokenType.RETURN: return ParseReturnStatement();
            default: throw new Exception("Not yet implemented :)");
        }
    }

    private LetStatement? ParseLetStatement()
    {
        var statement = new LetStatement(this.currentToken.Literal);

        if (this.nextToken.Type != TokenType.IDENT)
        {
            Errors.Add("Parsing error: Expected identifier, got " + nextToken.Literal);
            return null;
        }

        AdvanceToken();

        statement.Name = new Identifier(this.currentToken.Literal, this.currentToken.Literal);

        if (this.nextToken.Type != TokenType.ASSIGN)
        {
            Errors.Add("Parsing error: Expected assign, got " + nextToken.Literal);
            return null;
        }

        AdvanceToken();

        // TODO skipping expressions
        // until we encounter semicolon
        while (this.currentToken.Type != TokenType.SEMICOLON)
        {
            AdvanceToken();
        }

        return statement;
    }

    private ReturnStatement? ParseReturnStatement()
    {
        var statement = new ReturnStatement(this.currentToken.Literal);

        AdvanceToken();

        // TODO skipping expressions
        // until we encounter semicolon
        while (this.currentToken.Type != TokenType.SEMICOLON)
        {
            AdvanceToken();
        }

        return statement;
    }


}