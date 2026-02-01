/*
Decision-Making Process
Create a decision tree for a simple yes/no quiz to recommend a type of pet based on answers to questions.
*/

using System;
class DecisionNode
{
    public string Question { get; set; } // The question or recommendation stored in the node
    public DecisionNode Yes { get; set; } // Next node if the answer is "Yes"
    public DecisionNode No { get; set; } // Next node if the answer is "No"


    // Constructor to initialize a decision node with a question
    public DecisionNode(string question)
    {
        Question = question;
    }
}


class Program
{
    static void Main(string[] args)
    {
        // Build the decision tree manually
        var root = new DecisionNode("Do you like active pets?");
        root.Yes = new DecisionNode("Do you have a lot of space?");
        root.Yes.Yes = new DecisionNode("Recommended: Dog"); // If Yes -> Yes
        root.Yes.No = new DecisionNode("Recommended: Cat");  // If Yes -> No
        root.No = new DecisionNode("Do you prefer low-maintenance pets?");
        root.No.Yes = new DecisionNode("Recommended: Fish"); // If No -> Yes
        root.No.No = new DecisionNode("Recommended: Hamster"); // If No -> No


        // Start traversal from the root node
        var currentNode = root;


        // Traverse the tree based on user input
        while (currentNode.Yes != null && currentNode.No != null)
        {
            Console.WriteLine(currentNode.Question); // Ask the current question
            string answer = Console.ReadLine().Trim().ToLower(); // Get user input ("yes" or "no")


            // Navigate to the next node based on the answer
            if (answer == "yes")
                currentNode = currentNode.Yes;
            else if (answer == "no")
                currentNode = currentNode.No;
            else
                Console.WriteLine("Please answer 'yes' or 'no'.");
        }


        // Display the recommendation (leaf node)
        Console.WriteLine(currentNode.Question);
    }
}


