namespace Stork.NET.Core.Engine.Compilation
{
    public sealed class Int : TokenType
    {
        public Int(string intValue = "")
            : base(MetaType.Value, intValue)
        {
        }
    }
}