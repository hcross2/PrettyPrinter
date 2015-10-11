// Nil -- Parse tree node class for representing the empty list
// Hunter Crossett and Emmitt Bush CSC 4101
using System;

namespace Tree
{
    public class Nil : Node
    {
        public Nil() { }
  
        public override void print(int n)
        {
            print(n, false); //what?
        }

        public override void print(int n, bool p) {
	    // There's got to be a more efficient way to print n spaces.
	    for (int i = 0; i < n; i++)
                Console.Write(" ");

            if (p)
                Console.WriteLine(")");
            else
                Console.WriteLine("()");
        }
    }
}
