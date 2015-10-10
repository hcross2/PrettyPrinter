//Hunter Crossett and Emmitt Bush
using System;
namespace Tree
{
    public class Let : Special
    {
	public Let() { }
        public override void print(Node t, int n, bool p)
        {
            for (int i = 0; i < n; i++)
			    Console.Write(' ');
            if (!p) //bool is for checking RPAREN is written
            {
                Console.Write("("); 
                p = true;
            }
            Console.WriteLine("let"); //print out keywords
            Node temp = t.getCdr().getCar();
            if (temp.getCdr().isPair())            //probably should throw an error if it isnt.
                temp.getCdr().print(n + 4, true); 
            Console.WriteLine();
            
            Node rest = t.getCdr().getCdr();
            if (rest.isPair())
                rest.print(n + 4, true);
            Console.WriteLine();
            
            for (int i = 0; i < n; i++) 
            Console.Write(' ');
            Console.Write(")");
        }
    }
}


