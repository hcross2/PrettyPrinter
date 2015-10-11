// StringToken -- Token object for representing string constants.
// Hunter Crossett and Emmitt Bush CSC 4101
namespace Tokens
{
    public class StringToken : Token
    {
        private string stringVal;

        public StringToken(string s) : base(TokenType.STRING)
        {
            stringVal = s;
        }

        public override string getStringVal()
        {
            return stringVal;
        }
    }
}
