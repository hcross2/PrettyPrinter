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
            token t = Scanner.getNextToken(); //if null parseExp takes care of it.
            return parseExp(t);  
        }
        private Node parseExp(Token t)
        {
            if(t == null)
            {
                return null;
            }
            else if(t.getType == TokenType.LPAREN)
            {
                return parseRest();
            }
            else if(t.getType == TokenType.TRUE)
            {
                return new BoolLit(true);
            }
            else if(t.getType == TokenType.FALSE)
            {
                return new BoolLit(false);
            }
            else if(t.getType == TokenType.INT)
            {
                return new IntLit(t.getIntVal());
            }
            else if(t.getType == TokenType.IDENT)
            {
                return new Ident(t.getName());
            }
            else if(t.getType == TokenType.QUOTE)
            {
                return new Cons(new Ident("quote"), new Cons(parseExp(), Nil()));
            }
            else if(t.getType == TokenType.STRING)
            {
                return new StrLit(t.getStringVal());
            }
            else if(t.getType == TokenType.RPAREN || t.getType == TokenType.DOT)
            {
                Console.write("parseExp error: Can't have right parenthesis or dot");
            }
            else
            {
                Console.write("PraseExp error: Failed to parse");
            }
            return null;
        }
 
  // rest -> ) 
  //       | exp R
  // R   --> .exp) 
  //       | rest (for a look ahead to make sure exp.exp is only called)
        protected Node parseRest()
        {
            token t = Scanner.getNextToken(); //error thrown correctly with null token
            if(t == null)
            {
                Console.write("ParseRest errror: EOF in List ");
                return null;
            }
            else if(t.getType == TokenType.RPAREN)
            {
                return new Nil();
            } 
            else if(t.getType == TokenType.DOT)
            {
                Console.write("ParseRest error: Need to have at least one expression before a dot");
            }
            else 
            {
                Node a=parseExp(t);
                Node d=parseR();
                return new Cons(a,d);
            }
        }
        protected Node parseR()
        {
            token t = Scanner.getNextToken();
            if (t == null)
            {
                Console.write("ParseR errror: EOF in List ");
                return null;                       
            }
            else if(t.getType == TokenType.DOT)
            {
                Node new = parseExp();
                t = Scanner.getNextToken();
                if (t.getType != TokenType.RPAREN)
                {
                    Console.write("PraseR error: Missing RPAREN for (x . y 1 3 ....)");
                }
            }
            else
            {
                parseRest();
            }
        }
    }
}