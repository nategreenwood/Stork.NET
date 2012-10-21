namespace Stork.NET.Core.Parse
{
    public abstract class TokenType
    {
        private readonly MetaType _metaType;
        private readonly string _text;

        protected TokenType(MetaType type, string text)
        {
            _metaType = type;
            _text = text;
        }

        protected TokenType()
        {
        }

        public new MetaType GetType()
        {
            return _metaType;
        }

        public string GetText()
        {
            return _text;
        }
    }
}