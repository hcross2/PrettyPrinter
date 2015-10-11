//Hunter Crossett and Emmitt Bush
using System;
namespace Tree
{
    public class Define : Special
    {
	public Define() { }
        public override void print(Node t, int n, bool p)
        {
            if (!p)
            {
                for (int i = 0; i < n; i++)
                    Console.Write(' ');
                Console.Write("(");
                p = true;
            }
            Console.Write("define");
            n = 1; 
            
            t.cdr.print(n, p);
        }
    }
}