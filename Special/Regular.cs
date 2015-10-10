//Hunter Crossett and Emmitt Bush
using System;
namespace Tree
{
    public class Regular : Special
    {
        private Cons cons;
        public Regular() { }
        public override void print(Node t, int n, bool p)
        {
            for (int i = 0; i < n; i++)
                Console.Write(' ');
            if (!p)
                Console.Write("(");
            if (cons.getCar().isCons() | cons.getCar().isNil()) //is isCons ok?
                cons.getCar().print(n, false);
            else
                cons.getCar().print(n, true);
    	
            if (cons.getCdr() != null)
                Console.Write(" ");
    	
		
    	if (cons.getCdr() != null) {
    		cons.getCdr().print(n, true);
    	} else {
			System.out.print(")");		
		} 
        }
    }
}


