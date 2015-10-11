// IdentToken -- Token object for representing identifiers.
// Hunter Crossett and Emmitt Bush CSC 4101
namespace Tokens
{
    public class IdentToken : Token
    {
        private string name;

        public IdentToken(string s) : base(TokenType.IDENT)
        {
            name = s;
        }

        public override string getName()
        {
            return name;
        }
    }
}
