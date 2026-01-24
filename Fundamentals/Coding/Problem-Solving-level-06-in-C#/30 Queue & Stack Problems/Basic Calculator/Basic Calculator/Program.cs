/*

Basic Calculator
Problem: Evaluate a mathematical expression containing +, -, (, ) without * or /.

Example:
Input: "1 + (2 - 3)"
Output: 0


Key Points:

Use a stack to handle parentheses and maintain the current sum.

*/

using System;
using System.Collections.Generic;
using System.Text;

class Program
{
    public static int EvaluatePostfix(string expression)
    {
        Stack<int> stack = new Stack<int>();

        foreach (char c in expression)
        {
            if (char.IsDigit(c))
            {
                stack.Push(c - '0');
            }
            else
            {
                int val2 = stack.Pop();
                int val1 = stack.Pop();

                switch (c)
                {
                    case '+': stack.Push(val1 + val2); break;
                    case '-': stack.Push(val1 - val2); break;
                    case '*': stack.Push(val1 * val2); break;
                    case '/': stack.Push(val1 / val2); break;
                }
            }
        }

        return stack.Pop();
    }

    public static string FormulaToPostfix(string formula)
    {
        var stack = new Stack<char>();
        var sb = new StringBuilder();

        foreach (char c in formula)
        {
            if (char.IsDigit(c))
            {
                sb.Append(c);
            }
            else if (c == '(')
            {
                stack.Push(c);
            }
            else if (c == ')')
            {
                while (stack.Count > 0 && stack.Peek() != '(')
                    sb.Append(stack.Pop());

                stack.Pop(); // Remove '('
            }
            else // operator
            {
                while (stack.Count > 0 && GetPrecedence(stack.Peek()) >= GetPrecedence(c))
                    sb.Append(stack.Pop());
                stack.Push(c);
            }
        }

        while (stack.Count > 0)
            sb.Append(stack.Pop());

        return sb.ToString();
    }

    static int GetPrecedence(char op) => op switch
    {
        '*' or '/' => 2,
        '+' or '-' => 1,
        _ => 0
    };


    static void Main()
    {
        string postfix;

        postfix = FormulaToPostfix("1+2-3");
        Console.WriteLine($"This is the postfix formula: {postfix}");
        Console.WriteLine($"This is After Evaluation: {EvaluatePostfix(postfix)}");

        postfix = FormulaToPostfix("4+5-6+7-8");
        Console.WriteLine($"This is the postfix formula: {postfix}");
        Console.WriteLine($"This is After Evaluation: {EvaluatePostfix(postfix)}");

        postfix = FormulaToPostfix("1+2-3+4");
        Console.WriteLine($"This is the postfix formula: {postfix}");
        Console.WriteLine($"This is After Evaluation: {EvaluatePostfix(postfix)}");

        postfix = FormulaToPostfix("1+2*3");
        Console.WriteLine($"This is the postfix formula: {postfix}");
        Console.WriteLine($"This is After Evaluation: {EvaluatePostfix(postfix)}");

        postfix = FormulaToPostfix("1+2*3+(5+6+7)");
        Console.WriteLine($"This is the postfix formula: {postfix}");
        Console.WriteLine($"This is After Evaluation: {EvaluatePostfix(postfix)}");
    }
}



// problem simple direct solution

//using System;
//using System.Collections.Generic;

//class Program
//{
//    public static int Calculate(string s)
//    {
//        Stack<int> stack = new Stack<int>();

//        int result = 0;
//        int currentNumber = 0;
//        int sign = 1;

//        foreach (char c in s)
//        {
//            if (char.IsDigit(c))
//            {
//                // Build multi-digit numbers
//                currentNumber = currentNumber * 10 + (c - '0');
//            }
//            else if (c == '+')
//            {
//                result += sign * currentNumber;
//                currentNumber = 0;
//                sign = 1;
//            }
//            else if (c == '-')
//            {
//                result += sign * currentNumber;
//                currentNumber = 0;
//                sign = -1;
//            }
//            else if (c == '(')
//            {
//                // SAVE current state to stack
//                stack.Push(result);
//                stack.Push(sign);

//                // RESET for the new sub-expression
//                result = 0;
//                sign = 1;
//            }
//            else if (c == ')')
//            {
//                // Finish current sub-expression
//                result += sign * currentNumber;
//                currentNumber = 0;

//                // RESTORE previous state from stack
//                int previousSign = stack.Pop();
//                int previousResult = stack.Pop();

//                result = previousResult + (previousSign * result);
//            }
//        }

//        result += sign * currentNumber;
//        return result;
//    }

//    static void Main()
//    {
//        Console.WriteLine(Calculate("1 + 1"));              // 2
//        Console.WriteLine(Calculate("2 - 1 + 2"));          // 3
//        Console.WriteLine(Calculate("(1+(4+5+2)-3)+(6+8)")); // 23
//        Console.WriteLine(Calculate("1 + (2 - 3)"));        // 0
//        Console.WriteLine(Calculate("2 - (3 + 4)"));        // -5
//    }
//}