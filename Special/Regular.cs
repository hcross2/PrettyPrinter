//Hunter Crossett and Emmitt Bush
using System;
namespace Tree
{
    public class Regular : Special
    {
//        private Cons cons;
        public Regular() { }
        public override void print(Node t, int n, bool p)
        {
            Console.WriteLine("Shit does print!");
            for (int i = 0; i < n; i++)
            {
                Console.Write(' ');
            }
            if (!p)
            {
                Console.Write("(");
                p = true;
            }
            if (t.getCar().isPair() | t.getCar().isNull())
            { 
                t.getCar().print(n, false);
            }
            else
            {
                t.getCar().print(n, true);
            }
    	
            if (t.getCdr() != null)
            {
                Console.Write(" ");
            }
    	
            if (t.getCdr() != null)
            {
                t.getCdr().print(n, true);
            }
            else
                Console.Write(")");		

        }
    }
}