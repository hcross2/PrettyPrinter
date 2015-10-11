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
            
            Node identifier = t.getCdr().getCar();
            if (indentifier.isSymbol()) //WHAT IF THIS IS A LIST!?!?!?
                identifier.print(n, p);
            else
                Console.WriteLine("DEFINE ERROR: DEFINE REQUIRES AN IDENTIFIER AFTER DEFINE");
            identifier = t.getCdr().getCdr();
            while (identifier.isPair())
            {
                identifier.car.print(1, p); //assumes print recursively prints items (including RPAREN)
                identifier = identifier.getCdr();
            }
            Console.Write(")");
        }
    }
}