using System;
namespace C_Sharp_Monkey
{
    public static class Repl
    {
        public static void Start()
        {
            while (true)
            {
                Console.Write("# ");

                string? line = Console.ReadLine();

                if (line == null)
                {
                    continue;
                }

                if (line == "exit")
                {
                    break;
                }

                var lexer = new Lexer(line);

                var nextToken = lexer.NextToken();

                while (nextToken != null && nextToken.TokenType != TokenType.EOF)
                {
                    Console.WriteLine("Parsed " + nextToken.Literal + " as " + nextToken.TokenType);
                    nextToken = lexer.NextToken();
                }
            }
        }
    }
}

