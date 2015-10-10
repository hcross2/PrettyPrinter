//Hunter Crossett and Emmitt Bush
using System;
namespace Tree
{
    public class Begin : Special
    {
	public Begin() { }
        public override void print(Node t, int n, bool p)
        {
            for (int i = 0; i < n; i++)
			    Console.Write(' ');
            if (!p) //bool is for checking RPAREN is written
            {
                Console.Write("("); 
                p = true;
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