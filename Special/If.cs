//Hunter Crossett and Emmitt Bush
using System;
namespace Tree
{
    public class If : Special
    {
	public If() { }
        public override void print(Node t, int n, bool p)
        {
            for (int i = 0; i < n; i++)
            {
                    Console.Write(' ');
            }
            if (!p)
            {
                Console.Write("(");
                p = true;
            }
            Console.Write("if");
            
            if (t.getCdr().isPair() & t.getCdr().getCdr().isPair() & t.getCdr().getCdr().getCdr().isPair() & !t.getCdr().getCdr().getCdr().getCdr().isPair()) //shits ok
            { //assumes a lot of cases dont happen like (if #t.............
                t.getCdr().print(1, false);
                n = n + 4;
                Console.WriteLine();
                t.getCdr().getCdr().getCar().print(n, p);
                Console.WriteLine();
                t.getCdr().getCdr().getCdr().getCar().print(n);
            }
            else //shits broke
                Console.WriteLine("IF ERROR: INCORRECT SYNTAX");
            Console.Write(")");
        }
    }
}