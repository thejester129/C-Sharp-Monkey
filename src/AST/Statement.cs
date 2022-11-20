namespace C_Sharp_Monkey.AST;

public interface IStatement : INode
{
    TokenType TokenType { get; }
}

public abstract class Statement : IStatement
{
    public string? Literal { get; private set; }

    public virtual TokenType TokenType => throw new NotImplementedException();

    public Statement(string? literal)
    {
        this.Literal = literal;
    }
}

public class LetStatement : Statement
{
    public override TokenType TokenType => TokenType.LET;
    public Identifier? Name { get; set; }
    public IExpression? Value { get; set; }

    public LetStatement(string? literal)
    : base(literal)
    {
    }

    public LetStatement(string literal, Identifier name, IExpression value)
    : base(literal)
    {
        this.Name = name;
        this.Value = value;
    }
}

public class ReturnStatement : Statement
{
    public override TokenType TokenType => TokenType.RETURN;
    public Identifier? Name { get; set; }
    public IExpression? Value { get; set; }

    public ReturnStatement(string? literal)
    : base(literal)
    {
    }

    public ReturnStatement(string literal, Identifier name, IExpression value)
    : base(literal)
    {
        this.Name = name;
        this.Value = value;
    }
}