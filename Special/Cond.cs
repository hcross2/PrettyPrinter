//Hunter Crossett and Emmitt Bush
using System;
namespace Tree
{
    public class Cond : Special
    {
	public Cond() { }
        public override void print(Node t, int n, bool p)
        { 
            for (int i = 0; i < n; i++)
			    Console.Write(' ');
            if (!p) //bool is for checking RPAREN is written
            {
                Console.Write("("); 
                p = true;
            }
            Console.WriteLine("cond"); //print out keywords
            if (t.getCdr().isPair())            //probably should throw an error if it isnt.
                t.getCdr().print(n + 4, true); 
            for (int i = 0; i < n; i++) 
            Console.Write(' ');
            Console.Write(")");
            
            void printQuote(Node t, int n bool p)
            {
                print(t, n, p);
            }
        }
    }
}


