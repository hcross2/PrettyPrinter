//Hunter Crossett and Emmitt Bush
using System;
namespace Tree
{
    public class Cons : Node
    {
        private Node car;
        private Node cdr;
        private Special form;
        public Cons(Node a, Node d)
        {
            car = a;
            cdr = d;
            parseList();
        }
    
        // parseList() `parses' special forms, constructs an appropriate
        // object of a subclass of Special, and stores a pointer to that
        // object in variable form.  It would be possible to fully parse
        // special forms at this point.  Since this causes complications
        // when using (incorrect) programs as data, it is easiest to let
        // parseList only look at the car for selecting the appropriate
        // object from the Special hierarchy and to leave the rest of
        // parsing up to the interpreter.
        void parseList()
        {
            if (car.isSymbol()) // is this implemeneted yet?
            {
                string name = car.getName(); //implement getname
                if (name == "quote" || name == "'")
                    form = new quote();
                else if (name == "lamda") //assumes strings can be compared this way
                    form = new lamda();
                else if (name == "if")
                    form = new If();
                else if (name == "begin")
                    form = new begin();
                else if (name == "let")
                    form = new Let();
                else if (name == "cond")
                    form = new cond();
                else if (name == "define")
                    form = new define();
                else if (name == "set!")
                    form = new Set();
                else    
                    form = new Regular();
            }
        }
 
        public override void print(int n)
        {
            form.print(this, n, false);
        }

        public override void print(int n, bool p)
        {
            form.print(this, n, p);
        }
        
        public override Node getCar()
        {
            return this.car;
        }
        
        public override Node getCdr()
        {
            return this.cdr;
        }
        
        public boolean isPair();
        {
            if (car != null & cdr != null )
                return true;
            else    
                return false;
        }
    }
}