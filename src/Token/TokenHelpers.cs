using System;
namespace C_Sharp_Monkey
{
    public static class TokenHelpers
    {
        public static Dictionary<string, string> KeywordMap = new Dictionary<string, string>
        {
            {"fn" , TokenTypes.FUNCTION},
            {"let" , TokenTypes.LET},
            {"true" , TokenTypes.TRUE},
            {"false" , TokenTypes.FALSE},
            {"if" , TokenTypes.IF},
            {"else" , TokenTypes.ELSE},
            {"return" , TokenTypes.RETURN},
            {"==" , TokenTypes.EQ},
            {"!=" , TokenTypes.NOT_EQ}
        };
    }

}