namespace Stork.NET.Core.Engine.Compilation
{
    public sealed class String : TokenType
    {
        public String()
        {
            
        }
        public String(string stringValue = "")
            : base(MetaType.Value, stringValue)
        {
        }
    }
}