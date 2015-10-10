// Quote -- Parse tree node strategy for printing the special form quote

using System;

namespace Tree
{
    public class Quote : Special
    {
        // TODO: Add any fields needed.
    private Cons list = null;
        // TODO: Add an appropriate constructor.
	public Quote(Cons t) 
    { 
        this.list = t;
    }

        public override void print(Node t, int n, bool p)
        {
            for (int i = 0; i < n; i++)
            {
                Console.Write(" ");
            }
                Console.Write("'");
                if (t.getCdr() is Nil()) // should check if it is a nil node
                {
                    Console.Write(" ");
                }
                else
                {
                    t.getCdr().print(0, false);
                }
            // TODO: Implement this function.
        }
    }
}

