namespace C_Sharp_Monkey.AST;

public interface IExpression : INode
{
    TokenType TokenType { get; }
}

public abstract class Expression : IExpression
{
    public string Literal { get; private set; }

    public virtual TokenType TokenType => throw new NotImplementedException();

    public Expression(string literal)
    {
        this.Literal = literal;
    }
}

public class Identifier : Expression
{
    public override TokenType TokenType => TokenType.IDENT;
    public string Value { get; private set; }
    public Identifier(string literal, string value) : base(literal)
    {
        this.Value = value;
    }
}