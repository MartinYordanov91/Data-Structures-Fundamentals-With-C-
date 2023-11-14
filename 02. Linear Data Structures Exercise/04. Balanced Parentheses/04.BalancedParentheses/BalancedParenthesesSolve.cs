namespace Problem04.BalancedParentheses
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class BalancedParenthesesSolve : ISolvable
    {
        public bool AreBalanced(string parentheses)
        {
            Stack<char> chars = new Stack<char>();

            for (int i = 0; i < parentheses.Length; i++)
            {
                if (new char[3] { ')', '}', ']' }.Contains(parentheses[i]))
                {
                    if (parentheses[i] == ')' && chars.Any() &&chars.Peek() == '(')
                    {
                        chars.Pop();
                        continue;
                    }
                    else if (parentheses[i] == '}' && chars.Any() && chars.Peek() == '{')
                    {
                        chars.Pop();
                        continue;
                    }
                    else if (parentheses[i] == ']' && chars.Any() && chars.Peek() == '[')
                    {
                        chars.Pop();
                        continue;
                    }
                    
                }

                chars.Push(parentheses[i]);
            }

            return chars.Any() ? false : true;
        }
    }
}
