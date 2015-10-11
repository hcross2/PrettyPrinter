//Hunter Crossett and Emmitt Bush
using System;
namespace Tree
{
    public class Lambda : Special
    {
	public Lambda() { }
        public override void print(Node t, int n, bool p)
        {
            for (int i = 0; i < n; i++)
                    Console.Write(' ');
            if (!p)
            {
                Console.Write("(");
                p = true;
            }
            Console.Write("lambda");
            
            if (t.cdr.isPair() & t.cdr.cdr.isPair() & !t.cdr.cdr.cdr.isPair()) //shits ok
            { 
                t.cdr.car.print(1);
                Console.WriteLine();
                t.cdr.cdr.car.print(n + 4, p);
                Console.WriteLine();
            }
            else //shits broke
                Console.WriteLine("LAMBDA ERROR: INCORRECT SYNTAX");
            Console.Write(")");
  	    }
    }
}