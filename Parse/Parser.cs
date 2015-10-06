// Hunter Crossett and Emmitt Bush CSC 4101
// Parser -- the parser for the Scheme printer and interpreter
// TEST2!!!!!
// Defines
//
//   class Parser;
//
// Parses the language
//
//   exp  ->  ( rest
//         |  #f
//         |  #t
//         |  ' exp
//         |  integer_constant
//         |  string_constant
//         |  identifier
//    rest -> )
//         |  exp+ [. exp] )
//
// and builds a parse tree.  Lists of the form (rest) are further
// `parsed' into regular lists and special forms in the constructor
// for the parse tree node class Cons.  See Cons.parseList() for
// more information.
//
// The parser is implemented as an LL(0) recursive descent parser.
// I.e., parseExp() expects that the first token of an exp has not
// been read yet.  If parseRest() reads the first token of an exp
// before calling parseExp(), that token must be put back so that
// it can be reread by parseExp() or an alternative version of
// parseExp() must be called.
//
// If EOF is reached (i.e., if the scanner returns a NULL) token,
// the parser returns a NULL tree.  In case of a parse error, the
// parser discards the offending token (which probably was a DOT
// or an RPAREN) and attempts to continue parsing with the next token.

using System;
using Tokens;
using Tree;

namespace Parse
{
    public class Parser {
	
        private Scanner scanner;

        public Parser(Scanner s) { scanner = s; }
  
        public Node parseExp()
        {
            // TODO: write code for parsing an exp
                return parseExp(Scanner.getNextToken());   
        }
        private Node parseExp(Token t)
        {
            token t = Scanner.getNextToken();
            if(t == null)
                return null;
            else if(t.getType == TokenType.LPAREN)
                return parseRest();
            else if(t.getType == TokenType.TRUE)
                return new BoolLit(true);
            else if(t.getType == TokenType.FALSE)
                return new BoolLit(false);
            else if(t.getType == TokenType.INT)
                return new IntLit(t.getIntVal());
            else if(t.getType == TokenType.IDENT)
                return new Ident(t.getName());
            else if(t.getType == TokenType.QUOTE)
                return new Cons(new Ident("quote"), new Cons(parseExp(), null));
            else if(t.getType == TokenType.STRING)
                return new StrLit(t.getStringVal());
            return null;
                
            
        }
  
  // rest -> )
  //       | exp R
  // R   --> rest (for a look ahead to make sure exp.exp is only called)
  //       | .exp)
        protected Node parseRest()
        {
            token t = Scanner.getNextToken();
            if(t == null)
                return null;
            else if(t.getType == TokenType.RPAREN)
                return new Nil();
            else if(t.getType == TokenType.DOT)
                // NEED TO PRINT OUT 'NEED TO HAVE AT LEAST ONE EXPRESSION BEFORE ANY DOT"
                return null;
            else
                
            // TODO: write code for parsing a rest
            return null;
        }

        // TODO: Add any additional methods you might need.
    }
}

