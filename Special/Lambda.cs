//Hunter Crossett and Emmitt Bush
using System;
namespace Tree
{
    public class Lambda : Special
    {
	public Lambda() { }
        public override void print(Node t, int n, bool p)
        {
            for (int i = 0; i < n; i++)
                    Console.Write(' ');
            if (!p)
            {
                Console.Write("(");
                p = true;
            }
            Console.Write("lambda");
            
            if (); //shits ok
            { 
               
            }
            else //shits broke
                Console.WriteLine("IF ERROR: INCORRECT SYNTAX");
            Console.Write(")");
  	    }
    }
}