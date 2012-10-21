namespace Stork.NET.Core.Parse
{
    public sealed class Int : TokenType
    {
        public Int(string intValue = "")
            : base(MetaType.Value, intValue)
        {
        }
    }
}