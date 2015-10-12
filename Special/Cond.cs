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
            Node u = t.getCdr();
            while (u.isPair())  
            {    
                Console.WriteLine();
                for (int i = 0; i < n; i++) 
                    Console.Write(' ');     
                u.print(n + 4, true); 
                u = u.getCdr();
            }
            for (int i = 0; i < n; i++) 
                Console.Write(' ');
            Console.WriteLine();
            Console.Write(")");
            Console.WriteLine();
        }
    }
}


