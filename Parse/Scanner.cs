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

        public Scanner(TextReader i) { In = i; }
  
        // TODO: Add any other methods you need
        //What will we need? - Hunter

        public Token getNextToken()
        {
            int ch; //current character we are working on

            try
            {
                //Read in character. May fail, hense try
                ch = In.Read();
   
                // TODO: skip white space and comments

                if (ch == -1)
                    return null;
        
                // Special characters
                else if (ch == '\'')
                    return new Token(TokenType.QUOTE);
                else if (ch == '(')
                    return new Token(TokenType.LPAREN);
                else if (ch == ')')
                    return new Token(TokenType.RPAREN);
                else if (ch == '.')
                    // We ignore the special identifier `...'.
                    return new Token(TokenType.DOT);
                
                // Boolean constants
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
                    int x = BUFFINDEX; //0 difference because null strings can exist
                    while (ch!='"') //while ch is not the closing " get length of string
                    {
                        ch = In.Read(); //should be have any error cases?
                        BUFFINDEX++;
                    }
                    // TODO: scan a string into the buffer variable buf
                    return new StringToken(new String(buf, x, BUFFINDEX));
                    //return new StringToken(new String(buf, 0, 0)); //I don't think this should be 0,0
                }

    
                // Integer constants
                else if (ch >= '0' && ch <= '9')
                {
                    int i = ch - '0';
                    // TODO: scan the number and convert it to an integer

                    // make sure that the character following the integer
                    // is not removed from the input stream
                    return new IntToken(i);
                }
        
                // Identifiers
                else if (ch >= 'A' && ch <= 'Z'
                         // or ch is some other valid first character
                         // for an identifier
                         ) {
                    // TODO: scan an identifier into the buffer

                    // make sure that the character following the integer
                    // is not removed from the input stream

                    return new IdentToken(new String(buf, 0, 0));
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