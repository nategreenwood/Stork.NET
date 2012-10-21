namespace Stork.NET.Core.Parse
{
    public class Symbol : TokenType
    {
        public Symbol()
        {
            
        }
        public Symbol(string symbolText = "")
            : base(MetaType.Value, symbolText)
        {
        }
    }
}