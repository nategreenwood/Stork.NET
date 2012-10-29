namespace Stork.NET.Core.Engine.Compilation
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