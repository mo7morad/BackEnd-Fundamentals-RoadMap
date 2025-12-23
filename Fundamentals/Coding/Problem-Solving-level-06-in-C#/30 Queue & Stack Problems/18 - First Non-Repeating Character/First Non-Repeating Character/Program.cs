class Program
{
    static void FindUniquePrinter(string stream)
    {
        HashSet<char> seenCharacters = new HashSet<char>();

        foreach (char c in stream)
        {
            // If we have NOT seen it before
            if (!seenCharacters.Contains(c))
            {
                seenCharacters.Add(c);
                Console.Write(c + " ");
            }
            // If we HAVE seen it before
            else
            {
                Console.Write("- ");
            }
        }
    }

    static void Main()
    {
        // Input:  a a b c c d e s a
        // Output: a - b c - d e s -
        FindUniquePrinter("aabccdesa");
    }
}


// Another Solution


//class Program
//{
//    static Queue<char> GetNonRepeatingCharacters(string Text)
//    {
//        Queue<char> NonRepeatingCharacters = new Queue<char>();
//        for (int i = 0; i < Text.Length; i++)
//        {
//            if (!NonRepeatingCharacters.Contains(Text[i]))
//                NonRepeatingCharacters.Enqueue(Text[i]);
//            else
//                NonRepeatingCharacters.Enqueue('-');
//        }

//        return NonRepeatingCharacters;
//    }

//    static void Main()
//    {
//        Queue<char> q = GetNonRepeatingCharacters("aabccdesa");
//        foreach (char item in q)
//        {
//            Console.Write(item + "  ");
//        }
//    }
//}
