//Hunter Crossett and Emmitt Bush
using System;
namespace Tree
{
    public class Quote : Special
    {
    private Cons list = null;
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
                if (t.getCdr().isNull()) // should check if it is a nil node
                {
                    Console.Write(" ");
                }
                else
                {
                    t.getCdr().print(0, false);
                }
        }
    }
}

