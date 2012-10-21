namespace Stork.NET.Core.Parse
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