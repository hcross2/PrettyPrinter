//Hunter Crossett and Emmitt Bush
using System;
namespace Tree
{
    public class Set : Special
    {
	public Set() { }
        public override void print(Node t, int n, bool p)
        {  
            if (!p)
        {
            for (int i = 0; i < n; i++)
			    Console.Write(' ');
            p = true;
            Console.Write("(");
        }
            Console.Write("set!");
            n = 1; //1 space between parts and whatnot
            if (indentifier.isSymbol()) //WHAT IF THIS IS A LIST!?!?!?
                identifier.print(n, p);
            else
                Console.WriteLine("SET ERROR: SET! REQUIRES AN IDENTIFIER AFTER DEFINE");
            t.getCdr().print(n, p);
        }
    }
}