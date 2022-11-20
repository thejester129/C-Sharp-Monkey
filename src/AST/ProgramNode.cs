using C_Sharp_Monkey.AST;


public interface IProgramNode : INode
{
    List<IStatement> Statements { get; set; }
}
public class ProgramNode : IProgramNode
{
    public List<IStatement> Statements { get; set; } = new List<IStatement>();
    public ProgramNode()
    {
    }

    public string Literal
        => Statements.First()?.Literal ?? "";
}