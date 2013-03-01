namespace Stork.NET.Core.Engine.Compilation
{
    public class SemiColon : TokenType
    {
        public SemiColon()
            : base(MetaType.Operator, ";")
        {
        }
    }
}