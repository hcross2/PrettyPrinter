// IntToken -- Token object for representing integer constants.
// Hunter Crossett and Emmitt Bush CSC 4101
namespace Tokens
{
    public class IntToken : Token
    {
        private int intVal;

        public IntToken(int i) : base(TokenType.INT)
        {
            intVal = i;
        }
    
        public override int getIntVal()
        {
            return intVal;
        }
    }
}
