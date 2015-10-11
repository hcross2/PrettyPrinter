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
            Console.Write("if");
            
            if (t.cdr.isPair() & t.cdr.cdr.isPair() & t.cdr.cdr.cdr.isPair() & !t.cdr.cdr.cdr.cdr.isPair()); //shits ok
            {
                n = 1;
                Node identifier = t.getCdr().getCar();
                if (indentifier.isSymbol()) //WHAT IF THIS IS A LIST!?!?!?
                    identifier.print(n, p);
                else
                    Console.WriteLine("IF ERROR: DEFINE REQUIRES AN IDENTIFIER AFTER DEFINE");
                identifier = t.getCdr().getCdr();
                while (identifier.isPair())
                {
                    identifier.car.print(1, p); //assumes print recursively prints items (including RPAREN)
                    identifier = identifier.getCdr();
                }
            }
            else //shits broke
                Console.WriteLine("IF ERROR: INCORRECT SYNTAX");
            Console.Write(")");
        }
    }
}