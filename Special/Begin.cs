//Hunter Crossett and Emmitt Bush
using System;
namespace Tree
{
    public class Begin : Special
    {
	public Begin() { }
        public override void print(Node t, int n, bool p, bool q) //when is this q passed in?
        {
            for (int i = 0; i < n; i++)
			    Console.Write(' ');
            if (!p) //bool is for checking LPAREN is written
            {
                Console.Write("("); 
                p = true;
            }
            if (!q) //bool is for LPAREN for statements
            {
                Console.WriteLine();
                int o = n + 4; //indent!
                Node cdr = t.getCdr(); //the rest!
                while (cdr.isPair()) 
                {
                    cdr.getCar().print(o, p, q)
                    Console.WriteLine();
                    cdr = cdr.getCdr(); 
                }
                //what if it is not a correct list? check for it? idk
                for (int i = 0; i < n; i++)
                    Console.Write(' ');
                Console.Write(")"); //finished the begin
            }
            Console.WriteLine("begin"); //print out keywords
            if (t.getCdr().isPair())            //probably should throw an error if it isnt.
                t.getCdr().print(n + 2, true); 
		for (int i = 0; i < n; i++) 
            Console.Write(' ');
		Console.Write(")");
        }
    }
}