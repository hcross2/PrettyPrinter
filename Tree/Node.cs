// Node -- Base class for parse tree node objects
// Hunter Crossett and Emmitt Bush CSC 4101
namespace Tree
{
    public class Node
    {
        // The argument of print(int) is the number of characters to indent.
        // Every subclass of Node must implement print(int).
        public virtual void print(int n) 
        { 
            
        }

        // The first argument of print(int, bool) is the number of characters
        // to indent.  It is interpreted the same as for print(int).
        // The second argument is only useful for lists (nodes of classes
        // Cons or Nil).  For all other subclasses of Node, the boolean
        // argument is ignored.  Therefore, print(n,p) defaults to print(n)
        // for all classes other than Cons and Nil.
        // For classes Cons and Nil, print(n,TRUE) means that the open
        // parenthesis was printed already by the caller.
        // Only classes Cons and Nil override print(int, bool).
        // For correctly indenting special forms, you might need to pass
        // additional information to print.  What additional information
        // you pass is up to you.  If you only need one more bit, you can
        // encode that in the sign bit of n. If you need additional parameters,
        // make sure that you define the method print in all the appropriate
        // subclasses of Node as well.
        public virtual void print(int n, bool p)
        {
            print(n);
        }

        // For parsing Cons nodes, for printing trees, and later for
        // evaluating them, we need some helper functions that test
        // the type of a node and that extract some information.

        // TODO: implement these in the appropriate subclasses to return true.
        public virtual bool isBool()    // BoolLit
        { 
            return false; 
        }  
        
        public virtual bool isNumber()  // IntLit
        { 
            return false; 
        } 
         
        public virtual bool isString()  // StringLit
        { 
            return false; 
        }  
        
        public virtual bool isSymbol()  // Ident
        { 
            return false; 
        }  
        
        public virtual bool isNull()   // Nil
        { 
            return false; 
        }  
        
        public virtual bool isPair()   // Cons
        { 
            return false; 
        }  

        // TODO: Report an error in these default methods and implement them
        // in class Cons.  After setCar, a Cons cell needs to be `parsed' again
        // using parseList.
        public virtual Node getCar() //need param?
        { 
            return car; 
        }
        public virtual Node getCdr() //needs param?
        { 
            return cdr; 
        }
        public virtual void setCar(Node a) 
        { 
            a = car;
        }
        public virtual void setCdr(Node d) 
        {
            d = cdr;
        }
        public string getName()
        {
            return null;
        }
    }
}

