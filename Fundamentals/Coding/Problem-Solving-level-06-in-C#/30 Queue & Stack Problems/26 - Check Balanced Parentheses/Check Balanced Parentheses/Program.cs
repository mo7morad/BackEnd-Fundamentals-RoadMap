/*

Check Balanced Parentheses
Problem: Check if a given string has balanced parentheses.

Input: "({[]})" or "({[)]}"
Output: true for "({[]})" and false for "({[)]}"
Key Idea: Use a stack to keep track of opening brackets and ensure they are closed in the correct order.

*/


using System;
using System.Collections.Generic;

class Program
{
    public static bool IsBalanced(string input)
    {
        if (input.Length % 2 != 0)
        {
            return false;
        }

        Stack<char> stack = new Stack<char>();

        Dictionary<char, char> pairs = new Dictionary<char, char>() {
            { ')', '(' },
            { '}', '{' },
            { ']', '[' }
        };

        foreach (char c in input)
        {
            // If it is an Opening bracket, Push to stack
            if (c == '(' || c == '{' || c == '[')
            {
                stack.Push(c);
            }
            // If it is a Closing bracket
            else if (pairs.ContainsKey(c))
            {
                // Check 1: Is the stack empty? (Means we have a closing bracket with no opening)
                // Check 2: Does the top of the stack match the current closing bracket?
                if (stack.Count == 0 || stack.Pop() != pairs[c])
                {
                    return false;
                }
            }
        }

        // Final Check: The stack must be empty.
        // If items remain, it means we had opening brackets that were never closed.
        return stack.Count == 0;
    }

    static void Main()
    {
        // Test Case 1: Nested (The "Onion")
        Console.WriteLine($"Nested '({{[]}})': {IsBalanced("({[]})")}"); // Expected: True

        // Test Case 2: Sequential (The "Side-by-Side" - This breaks the Two Pointer method)
        Console.WriteLine($"Sequential '()[]{{}}': {IsBalanced("()[]{}")}"); // Expected: True

        // Test Case 3: Mixed
        Console.WriteLine($"Mixed '({{}})[()]': {IsBalanced("({})[()]")}"); // Expected: True

        // Test Case 4: Invalid Order
        Console.WriteLine($"Invalid Order '([)]': {IsBalanced("([)]")}"); // Expected: False

        // Test Case 5: Odd Length
        Console.WriteLine($"Odd Length '({{}}': {IsBalanced("({{}")}"); // Expected: False
    }
}


// Another Solution

//using System;
//using System.Collections.Generic;

//class Program
//{
//    public static bool IsBalanced(string input)
//    {
//        if (input.Length % 2 != 0) return false;

//        Stack<char> stack = new Stack<char>();

//        foreach (char c in input)
//        {
//            // 1. If open, push the EXPECTED closer
//            if (c == '(') stack.Push(')');
//            else if (c == '{') stack.Push('}');
//            else if (c == '[') stack.Push(']');

//            // 2. If it is a closer, check if it matches the top of stack
//            // (If stack is empty OR the top doesn't match current char -> Invalid)
//            else if (stack.Count == 0 || stack.Pop() != c)
//            {
//                return false;
//            }
//        }

//        return stack.Count == 0;
//    }

//    static void Main()
//    {
//        // Test Case 1: Nested (The "Onion")
//        Console.WriteLine($"Nested '({{[]}})': {IsBalanced("({[]})")}"); // Expected: True

//        // Test Case 2: Sequential (The "Side-by-Side" - This breaks the Two Pointer method)
//        Console.WriteLine($"Sequential '()[]{{}}': {IsBalanced("()[]{}")}"); // Expected: True

//        // Test Case 3: Mixed
//        Console.WriteLine($"Mixed '({{}})[()]': {IsBalanced("({})[()]")}"); // Expected: True

//        // Test Case 4: Invalid Order
//        Console.WriteLine($"Invalid Order '([)]': {IsBalanced("([)]")}"); // Expected: False

//        // Test Case 5: Odd Length
//        Console.WriteLine($"Odd Length '({{}}': {IsBalanced("({{}")}"); // Expected: False
//    }
//}

// Another Solution 

//public static bool IsBalanced(string input)
//{
//    if (input.Length % 2 != 0) return false;

//    var stack = new Stack<char>();

//    foreach (char c in input)
//    {
//        // Check if it's an opening bracket
//        if (c is '(' or '{' or '[')
//        {
//            stack.Push(c);
//        }
//        else
//        {
//            // Check if stack is empty (fail)
//            if (stack.Count == 0) return false;

//            // Check if current char matches the top of the stack
//            char open = stack.Pop();
//            bool isMatch = (open, c) switch
//            {
//                ('(', ')') => true,
//                ('{', '}') => true,
//                ('[', ']') => true,
//                _ => false
//            };

//            if (!isMatch) return false;
//        }
//    }

//    return stack.Count == 0;
//}