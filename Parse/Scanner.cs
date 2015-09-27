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
        
        private boolean IndentifierCharacter(char ch)
        {
            return( ch >= 'A' && ch <= 'Z' 
                    || ch == '!' 
                    || ch == '$' 
                    || ch == '%' 
                    || ch == '&' 
                    || ch == '*' 
                    || ch == '+' 
                    || ch == '-' 
                    || ch == '.' 
                    || ch == '/' 
                    || ch == ':' 
                    || ch == '<' 
                    || ch == '=' 
                    || ch == '>' 
                    || ch == '?' 
                    || ch == '@' 
                    || ch == '^' 
                    || ch == '_' 
                    || ch == '~')  
        }

        public Scanner(TextReader i) { In = i; }
  
        // TODO: Add any other methods you need
        //What will we need? - Hunter

        public Token getNextToken()
        {
<<<<<<< HEAD
            int ch;
            
=======
            int ch; //current character we are working on
>>>>>>> origin/master

            try
            {
                //Read in character. May fail, hense try
                ch = In.Read();
                if(ch=='#')  //**********************WORK ON THIS
            
                // TODO: skip white space and comments
                
                //below: is just for spaces, in this order (space, tab, line feed or new line, carriage return, formfeed)
                //below: if you see " ", or "\t", "\n", "\r", or "\f" then getNextToken
                if(ch==" ")
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
                //comments start with a semicolon, so once you see a semicolon skip everything on that line.
                if(ch ==';')
                {
                    ch=InRead(); //NEED TO RETURN NULL FOR EOF
                    if (ch == -1) //assumes EOF is -1
                        return null;
                    char x;
                    while (!(x == '\'' && ch == 'n')) //changed from x!=\ and ch!=n for legibility
                        {
                            x=ch;
                            ch.InRead();
                            if (ch == -1) //assumes EOF is -1
                                return null;
                        }
                       getNextToken();
                }
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
                    if (ch == -1) //assumes EOF is -1
                        return null;
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
<<<<<<< HEAD
                    int a = 0;
                    do
                    {
                        ch = In.Read();
                        if (ch == -1) //assumes EOF is -1
                            return null;
                        buf[a++] == ch; //Hunter doesnt know what this is so he wrote V
                    }while(ch!='"')
                    return new StringToken(new String(buf, 0, a));
                    /*
                    String temp = "";
                    do 
                    {
                        ch = In.Read();
                        if (ch == -1) //assumes EOF is -1
                            return null;
                       temp += ch;
                    }while(ch!='"')
                    return new StringToken(temp);
                    */
=======
                    return new StringToken(new String(buf, x, BUFFINDEX));
                    //return new StringToken(new String(buf, 0, 0)); //I don't think this should be 0,0
>>>>>>> origin/master
                }

    
                // Integer constants
                else if (ch >= '0' && ch <= '9')
                {
                    int i = ch - '0';
                    // TODO: scan the number and convert it to an integer
                    int peekch = In.peek();
                    while(peekch >= '0' && peekch <= '9')
                    {
                        ch = In.Read();
                        i = 10*i + ch -'0';
                        peekch = In.peek();
                    }

                    // make sure that the character following the integer
                    // is not removed from the input stream
                    return new IntToken(i);
                }
        
        
                // Identifiers
                else if (IndentifierCharacter(ch))
                         // or ch is some other valid first character
                         // for an identifier
                {
                    int peekch = In.peek();
                    if (peekch == -1) //assumes EOF is -1
                        return null;
                    while(IndentifierCharacter(peekch) || peekch >= '0' && peekch <= '9')
                    {
                        ch = In.Read()
                        buf[a++] == ch;
                        peekch = In.peek();
                    }
                    // TODO: scan an identifier into the buffer

                    // make sure that the character following the integer
                    // is not removed from the input stream

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