namespace Stork.NET.Core.IO
{
    using System.IO;
    using System;

    public class ParseReader : TextReader
    {
        private const int NONE = -2;
        private readonly TextReader _inner;
        private int _next;
        private int _offest;

        public ParseReader(TextReader inner)
        {
            _inner = inner;
            _next = NONE;
        }

        public int Expect(char want)
        {
            int result = Read();
            if(result != want)
                throw new Exception("Expected character '" + want + "'. Got '" + result + "'");
            
            return result;
        }

        public override int Read()
        {
            int result = Peek();
            _next = NONE;

            return result;
        }

        public override int Read(char[] buffer, int offset, int length)
        {
            int result = 0;
            for (int i = 0; i < length; i++)
            {
                int ch = Read();
                if (ch != -1)
                {
                    buffer[offset + 1] = (char)ch;
                    result++;
                }
                else break;
            }

            return result;
        }

        public override int Peek()
        {
            if (_next == NONE)
            {
                _next = _inner.Read();
                _offest += 1;
            }
            return _next;
        }

        public override void Close()
        {
            GetInner().Close();
        }

        protected TextReader GetInner()
        {
            return _inner;
        }

        public int GetOffset()
        {
            return _offest;
        }
    }
}