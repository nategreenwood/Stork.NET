namespace Stork.NET.Core.Parse
{
    public class Star : TokenType
    {
        public Star()
            : base(MetaType.Operator, "*")
        {
        }
    }
}