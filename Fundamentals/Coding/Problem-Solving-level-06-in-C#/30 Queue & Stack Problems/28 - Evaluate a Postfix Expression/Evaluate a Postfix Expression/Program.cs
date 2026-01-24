/*

Evaluate a Postfix Expression
Problem: Evaluate a postfix expression using a stack.

Example:
Input: "231*+9-"
Output: -4


Key Points:

Push numbers onto the stack.
Perform operations using the top two elements for each operator.
Step-by-Step Execution for "231*+9-"
1- Initial Expression: "231*+9-"

2- Processing the Characters:

Character 2:
Digit → Push 2 onto the stack.
Stack: [2]
Character 3:
Digit → Push 3 onto the stack.
Stack: [2, 3]
Character 1:
Digit → Push 1 onto the stack.
Stack: [2, 3, 1]
Character *:
Operator → Pop 1 and 3 from the stack.
Multiply: 3 * 1 = 3
Push result (3) onto the stack.
Stack: [2, 3]
Character +:
Operator → Pop 3 and 2 from the stack.
Add: 2 + 3 = 5
Push result (5) onto the stack.
Stack: [5]
Character 9:
Digit → Push 9 onto the stack.
Stack: [5, 9]
Character -:
Operator → Pop 9 and 5 from the stack.
Subtract: 5 - 9 = -4
Push result (-4) onto the stack.
Stack: [-4]
3- Final Step:

The last element in the stack (-4) is popped and returned as the result.

*/


using System;
using System.Collections.Generic;

class Program
{
    public static int EvaluatePostfix(string expression)
    {
        Stack<int> stack = new Stack<int>();

        foreach (char c in expression)
        {
            // 1. If it's a number, Push it
            if (char.IsDigit(c))
            {
                // Convert char '5' to int 5
                // (c - '0') is a hack to convert char to int quickly
                stack.Push(c - '0');
            }
            // 2. If it's an operator, Pop & Calculate
            else
            {
                int val2 = stack.Pop(); // Top item (Right side)
                int val1 = stack.Pop(); // Second item (Left side)

                switch (c)
                {
                    case '+': stack.Push(val1 + val2); break;
                    case '-': stack.Push(val1 - val2); break; // Watch the order!
                    case '*': stack.Push(val1 * val2); break;
                    case '/': stack.Push(val1 / val2); break;
                }
            }
        }
        return stack.Pop();
    }

    static void Main()
    {
        Console.WriteLine(EvaluatePostfix("231*+9-")); // Output: -4
    }
}