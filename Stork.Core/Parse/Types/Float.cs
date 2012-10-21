namespace Stork.NET.Core.Parse
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