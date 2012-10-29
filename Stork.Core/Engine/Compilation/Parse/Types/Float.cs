namespace Stork.NET.Core.Engine.Compilation
{
    public sealed class Float : TokenType
    {
        public Float()
        {
            
        }
        public Float(string floatValue = "")
            : base(MetaType.Value, floatValue)
        {
        }
    }
}