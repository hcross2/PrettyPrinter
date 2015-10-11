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
            
            if (t.cdr.isPair() & t.cdr.cdr.isPair() & t.cdr.cdr.cdr.isPair() & !t.cdr.cdr.cdr.cdr.isPair()) //shits ok
            { //assumes a lot of cases dont happen like (if #t.............
                t.cdr.print(1, false);
                n = n + 4;
                Console.WriteLine();
                t.cdr.cdr.car.print(n, p);
                Console.WriteLine();
                t.cdr.cdr.cdr.car.print(n);
            }
            else //shits broke
                Console.WriteLine("IF ERROR: INCORRECT SYNTAX");
            Console.Write(")");
        }
    }
}