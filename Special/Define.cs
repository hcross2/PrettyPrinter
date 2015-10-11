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
                {
                    Console.Write(' ');
                }
                Console.Write("(");
                p = true;
            }
            Console.Write("define");
            
            if (t.getCdr().isPair() & !t.getCdr().getCar().isPair()) //shits ok
            {
                n = 1;
                Node identifier = t.getCdr().getCar();
                if (identifier.isSymbol()) //WHAT IF THIS IS A LIST!?!?!?
                    identifier.print(n, p);
                else
                    Console.WriteLine("DEFINE ERROR: DEFINE REQUIRES AN IDENTIFIER AFTER DEFINE");
                identifier = t.getCdr().getCdr();
                while (identifier.isPair())
                {
                    identifier.getCar().print(1, p); //assumes print recursively prints items (including RPAREN)
                    identifier = identifier.getCdr();
                }
            }
            else if (t.getCdr().isPair()) //shits weird
            {
                if (t.getCdr().getCar().isPair()) 
                {
                    t.getCdr().getCar().print(1); //spacing right?
                    Console.WriteLine();
                    t.getCdr().getCdr().getCar().print(n + 4, false);
                    Console.WriteLine();
                    Console.Write(")");
                } 
                else 
                {
                    t.getCdr().print(1, true);
                }
            }
            else //shits broke
                Console.WriteLine("DEFINE ERROR: INCORRECT SYNTAX FOR IDENTIFIER");
            Console.Write(")");
        }
    }
}