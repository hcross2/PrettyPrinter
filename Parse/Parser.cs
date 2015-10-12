// Hunter Crossett and Emmitt Bush CSC 4101

using System;
using Tokens;
using Tree;

namespace Parse
{
    public class Parser 
    {
        private Scanner scanner;
        public Parser(Scanner s) 
        {
            scanner = s; 
        }
        public Node parseExp()
        {
            Token t = scanner.getNextToken(); //if null parseExp takes care of it.
            return parseExp(t);  
        }
        private Node parseExp(Token t)
        {
            if(t == null)
            {
                return new Nil();
            }
            else if(t.getType() == TokenType.LPAREN)
            {
                return parseRest();
            }
            else if(t.getType() == TokenType.TRUE)
            {
                return new BoolLit(true);
            }
            else if(t.getType() == TokenType.FALSE)
            {
                return new BoolLit(false);
            }
            else if(t.getType() == TokenType.INT)
            {
                return new IntLit(t.getIntVal());
            }
            else if(t.getType() == TokenType.IDENT)
            {
                return new Ident(t.getName());
            }
            else if(t.getType() == TokenType.QUOTE)
            {
                return new Cons(new Ident("quote"), new Cons(parseExp(), new Nil())); //Type node?
            }
            else if(t.getType() == TokenType.STRING)
            {
                return new StringLit(t.getStringVal());
            }
            else if(t.getType() == TokenType.RPAREN || t.getType() == TokenType.DOT)
            {
                Console.WriteLine("parseExp error: Can't have right parenthesis or dot");
            }
            else
            {
                Console.WriteLine("PraseExp error: Failed to parse");
            }
            Console.WriteLine("THIS IS WHERE NULL IS BEING PASSED IN: scanner parseexp");
            return null;
        }
 
  // rest -> ) 
  //       | exp R
  // R   --> .exp) 
  //       | rest (for a look ahead to make sure exp.exp is only called)
        protected Node parseRest()
        {
            Token t = scanner.getNextToken(); //error thrown correctly with null token
            if(t == null)
            {
                Console.WriteLine("ParseRest errror: EOF in List ");
                return new Nil();
            }
            else if(t.getType() == TokenType.RPAREN)
            {
                Console.WriteLine("We are on the RPAREN");
                return new Nil();
            } 
            else if(t.getType() == TokenType.DOT)
            {
                Console.WriteLine("ParseRest error: Need to have at least one expression before a dot");
            }
            else 
            {
                Node a=parseExp(t);
                Node d=parseR();
                return new Cons(a,d);
            }
            Console.WriteLine("THIS IS WHERE NULL IS BEING PASSED IN scanner parserest");
            return null;
        }
        protected Node parseR()
        {
            Token t = scanner.getNextToken();
            if (t == null)
            {
                Console.WriteLine("ParseR errror: EOF in List ");
                return new Nil();                       
            }
            else if(t.getType() == TokenType.DOT)
            {
                Node temp = parseExp(); //not perfect
                t = scanner.getNextToken();
                if (t.getType() != TokenType.RPAREN)
                {
                    Console.WriteLine("PraseR error: Missing RPAREN for (x . y 1 3 ....)");
                }
                return temp;
            }
            else
            {
                return parseRest();
            }
        }
    }
}