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
                Console.Write(' ');
            if (!p)
            {
                Console.Write("(");
                p = true;
            }
            Console.Write("if (");
            Node stm = t.getCdr(); //stm = statement
            if (stm.isPair() & stm.getCdr().isPair() & stm.getCdr().getCdr().isPair() ) //shits ok
            { //assumes a lot of cases dont happen like (if #t.............
                stm.getCar().print(1, false); // this prints the statement inside the 'IF'
                Console.WriteLine();
                n = n + 4;
                stm.getCdr().getCar().print(n, p);
                if (stm.getCdr().getCdr().isPair())
                {
                    Console.WriteLine();
                    stm.getCdr().getCdr().getCar().print(n, p);
                }
                Console.WriteLine();
            }
            else //shits broke
                Console.WriteLine("IF ERROR: INCORRECT SYNTAX");
            for (int i = 0; i < n; i++)
                Console.Write(' ');
            Console.Write(")");
        }
    }
}