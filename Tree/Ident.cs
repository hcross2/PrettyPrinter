// Ident -- Parse tree node class for representing identifiers
// Hunter Crossett and Emmitt Bush CSC 4101
using System;

namespace Tree
{
    public class Ident : Node
    {
        private string name;

        public Ident(string n)
        {
            name = n;
        }

        public override void print(int n)
        {
	    // There got to be a more efficient way to print n spaces.
	    for (int i = 0; i < n; i++)
                Console.Write(" ");

            Console.WriteLine(name);
        }
        public string getName()
        {
            return name;
        }
        public bool isSymbol()
        {
            return true;
        }
    }
}

