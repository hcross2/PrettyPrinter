//Hunter Crossett and Emmitt Bush 
//4101 CSC LSU

//Very Java-ish
using System;
using System.IO;
using Tokens;

namespace Parse
{
    public class Scanner
    {
        private TextReader In;

        // maximum length of strings and identifier
        private const int BUFSIZE = 1000;
        
        private char[] buf = new char[BUFSIZE];
        
        private bool IndentifierCharacter(char ch) //we wrote a method to call instead of rewriting this each time
        {
            return( ch >= 'A' && ch <= 'Z' 
                    | ch == '!' 
                    | ch == '$' 
                    | ch == '%' 
                    | ch == '&' 
                    | ch == '*' 
                    | ch == '+' 
                    | ch == '-' 
                    | ch == '.' 
                    | ch == '/' 
                    | ch == ':' 
                    | ch == '<' 
                    | ch == '=' 
                    | ch == '>' 
                    | ch == '?' 
                    | ch == '@' 
                    | ch == '^' 
                    | ch == '_' 
                    | ch == '~') ;
        }

        public Scanner(TextReader i) { In = i; }
  
        // TODO: Add any other methods you need
        //What will we need? - Hunter 
        //Nothing! - Emmitt

        public Token getNextToken() 
        {
            int ch; //current character we are working on

            try
            {
                //Read in character. May fail, hense try
                ch = In.Read();
                if(ch==' ')
                    return getNextToken();
                if(ch =='\'')
                {
                        ch = In.Read();
                        if (ch == -1)
                            return null;
                        if(ch == 't')
                            return getNextToken();
                        if(ch == 'n')
                            return getNextToken();
                        if(ch == 'r')
                            return getNextToken();
                        if(ch == 'f')
                            return getNextToken();
                }
                if(ch ==';')
                {
                    ch=In.Read(); //NEED TO RETURN NULL FOR EOF
                    if (ch == -1) //assumes EOF is -1
                        return null;
                    int x = 0;
                    while (!(x == '\'' && ch == 'n')) //changed from x!=\ and ch!=n for legibility
                        {                             //probably should have used peek instead
                            x = ch;
                            ch = In.Read();
                            if (ch == -1) //assumes EOF is -1
                                return null;
                        }
                       getNextToken();
                }
                if (ch == -1)
                    return null;
        
                else if (ch == '\'')
                    return new Token(TokenType.QUOTE);
                else if (ch == '(')
                    return new Token(TokenType.LPAREN);
                else if (ch == ')')
                    return new Token(TokenType.RPAREN);
                else if (ch == '.')
                    // We ignore the special identifier `...'.
                    return new Token(TokenType.DOT);
                
                else if (ch == '#')
                {
                    ch = In.Read();
                    if (ch == 't')
                        return new Token(TokenType.TRUE);
                    else if (ch == 'f')
                        return new Token(TokenType.FALSE);
                    else if (ch == -1)
                    {
                        Console.Error.WriteLine("Unexpected EOF following #");
                        return null;
                    }
                    else
                    {
                        Console.Error.WriteLine("Illegal character '" +
                                                (char)ch + "' following #");
                        return getNextToken();
                    }
                }

                // I believe this is finished - Hunter 2015-9-22
                else if (ch == '"') //" 
                {
                    ch = In.Read();
                    int BUFFINDEX = 0;
                    while (ch!='"') //while ch is not the closing " get length of string
                    {
                        ch = In.Read(); //should be have any error cases?
                        if (ch == -1) //assumes EOF is -1
                        {
                            Console.WriteLine("Scanner Error: EOF in middle of string");
                            return null;
                        }
                        buf[BUFFINDEX++] = (char)ch;
                    }
                    return new StringToken(new String(buf, 0, BUFFINDEX));
                }

                // Integer constants
                else if (ch >= '0' && ch <= '9')
                {
                    int i = ch - '0';
                    int peekch = In.Peek();
                    while(peekch >= '0' && peekch <= '9')
                    {
                        ch = In.Read();
                        i = 10*i + ch -'0';
                        peekch = In.Peek();
                    }
                    return new IntToken(i);
                }
        
                // Identifiers
                else if (IndentifierCharacter((char)ch))
                {
                    int a = 0;
                    int peekch = In.Peek();
                    if (peekch == -1) //assumes EOF is -1
                        return null;
                    while(IndentifierCharacter((char)peekch) || peekch >= '0' && peekch <= '9')
                    {
                        ch = In.Read();
                        buf[a++] = (char)ch;
                        peekch = In.Peek();
                    }
                    return new IdentToken(new String(buf, 0, a));
                }
    
                // Illegal character
                else
                {
                    Console.Error.WriteLine("Illegal input character '"
                                            + (char)ch + '\'');
                    return getNextToken();
                }
            }
            catch (IOException e)
            {
                Console.Error.WriteLine("IOException: " + e.Message);
                return null;
            }
        }
    }
}