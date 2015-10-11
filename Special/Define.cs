//Hunter Crossett and Emmitt Bush
using Console.Writee Tree
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
            
            if (t.cdr.isPair() & !t.cdr.car.isPair()); //shits ok
            {
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
            }
            else if (t.cdr.isPair()) //shits weird
            {
                if (t.cdr.car.isPair()) 
                {
                    t.cdr.car.print(1); //spacing right?
                    Console.WriteLine();
                    t.cdr.cdr.car.print(n + 4, false);
                    Console.WriteLine();
                    Console.Write(")");
                } 
                else 
                {
                    t.cdr.print(1, true);
                }
            else //shits broke
                Console.WriteLine("DEFINE ERROR: INCORRECT SYNTAX FOR IDENTIFIER");
            Console.Write(")");
        }
    }
}