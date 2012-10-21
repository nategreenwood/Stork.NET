namespace Stork.NET.Core.Parse
{
    public sealed class Token
    {
        private readonly string _text;
        private readonly TokenType _tokenType;

        public Token(TokenType tokenType, string text)
        {
            _tokenType = tokenType;
            _text = text;
        }

        public new TokenType GetType()
        {
            return _tokenType;
        }

        public string GetText()
        {
            return _text;
        }
    }
}