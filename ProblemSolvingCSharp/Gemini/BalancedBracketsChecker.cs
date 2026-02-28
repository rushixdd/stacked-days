namespace ProblemSolvingCSharp.Gemini;

[TestClass]
public class BalancedBracketsChecker
{
    [TestMethod]
    public void IsBalanced_WithVariousInputs_ReturnsCorrectResult()
    {
        Assert.IsTrue(IsBalancedBracket("()[]{}"));
        Assert.IsTrue(IsBalancedBracket("{[()]}"));
        Assert.IsTrue(IsBalancedBracket(""));

        Assert.IsFalse(IsBalancedBracket("(]"));
        Assert.IsFalse(IsBalancedBracket("([)]"));
        Assert.IsFalse(IsBalancedBracket("{{("));
        Assert.IsFalse(IsBalancedBracket(")("));
    }

    private bool IsBalancedBracket(string brackets)
    {
        if (brackets.Length % 2 == 1)
        {
            return false;
        }
        Stack<char> stack = new Stack<char>();
        Dictionary<char, char> bracketPairs = new Dictionary<char, char>
        {
            {'(',')' },
            {'{','}' },
            {'[',']' }
        };

        foreach(var bracket in brackets)
        {
            if (bracketPairs.ContainsKey(bracket))
            {
                stack.Push(bracket);
            }
            else if (bracketPairs.ContainsValue(bracket))
            {
                if(stack.Count == 0 || bracketPairs[stack.Pop()]!=bracket)
                {
                    return false;
                }
            }
        }

        return stack.Count==0;
    }

    private bool IsValid(string brackets)
    {
        if (brackets.Length % 2 != 0) return false;

        Span<char> stack = stackalloc char[brackets.Length];
        int top = -1;

        foreach (char c in brackets)
        {
            switch (c)
            {
                case '(':
                case '[':
                case '{':
                    stack[++top] = c;
                    break;

                case ')':
                    if (top < 0 || stack[top--] != '(') return false;
                    break;
                case ']':
                    if (top < 0 || stack[top--] != '[') return false;
                    break;
                case '}':
                    if (top < 0 || stack[top--] != '{') return false;
                    break;
            }
        }

        return top == -1;
    }
}
