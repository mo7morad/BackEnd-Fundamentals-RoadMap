/*
Remove Invalid Parentheses
Problem: Remove the minimum number of invalid parentheses to make the string valid.

Example:
Input: "(()))"
Output: "()" or "(())"

Key Points:

Use a stack to track mismatched parentheses.
*/


using System;
using System.Collections.Generic;
using System.Text;

class Program
{
    public static string CleanParenthesesSmart(string s)
    {
        Stack<int> openStackIndecies = new Stack<int>();
        HashSet<int> indicesToRemove = new HashSet<int>();

        for (int i = 0; i < s.Length; i++)
        {
            char c = s[i];

            if (c == '(')
            {
                openStackIndecies.Push(i);
            }
            else if (c == ')')
            {
                if (openStackIndecies.Count == 0)
                {
                    indicesToRemove.Add(i);
                }
                else
                {
                    openStackIndecies.Pop();
                }
            }
        }

        while (openStackIndecies.Count > 0)
        {
            indicesToRemove.Add(openStackIndecies.Pop());
        }

        StringBuilder result = new StringBuilder(s.Length);
        for (int i = 0; i < s.Length; i++)
        {
            if (!indicesToRemove.Contains(i))
            {
                result.Append(s[i]);
            }
        }

        return result.ToString();
    }

    static void Main()
    {
        string[] tests =
        {
            "(()))",   // Output: (())
            "((()",    // Output: ()
            ")()(",    // Output: ()
            "()()",    // Output: ()()
            "(a(b(c)d)", // Output: (a(b(c)d)) -> (a(b(c)d) ? No -> a(b(c)d) or similar valid
            "",
        };
        
        foreach (var t in tests)
        {
            Console.WriteLine($"Input:  {t}");
            Console.WriteLine($"Output: {CleanParenthesesSmart(t)}");
            Console.WriteLine("---");
        }
    }
}


// Another sloution

// using System;
// using System.Collections.Generic;


// class Program
// {
//     static string RemoveInvalidParentheses(string s)
//     {
//         Stack<int> stack = new Stack<int>();
//         HashSet<int> invalidIndices = new HashSet<int>();


//         for (int i = 0; i < s.Length; i++)
//         {
//             if (s[i] == '(')
//             {
//                 stack.Push(i);
//             }
//             else if (s[i] == ')')
//             {
//                 if (stack.Count == 0)
//                 {
//                     invalidIndices.Add(i);
//                 }
//                 else
//                 {
//                     stack.Pop();
//                 }
//             }
//         }


//         while (stack.Count > 0)
//         {
//             invalidIndices.Add(stack.Pop());
//         }


//         char[] result = new char[s.Length - invalidIndices.Count];
//         int index = 0;
//         for (int i = 0; i < s.Length; i++)
//         {
//             if (!invalidIndices.Contains(i))
//             {
//                 result[index++] = s[i];
//             }
//         }


//         return new string(result);
//     }


//     static void Main()
//     {
//         Console.WriteLine(RemoveInvalidParentheses("(()))")); // Output: "(())" or "()"
//         Console.ReadKey();
//     }
// }
