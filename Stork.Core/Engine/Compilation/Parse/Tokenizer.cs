namespace Stork.NET.Core.Engine.Compilation
{
    using Exception;
    using Stork.NET.Core.IO;
    using System;
    using System.Collections.Generic;
    using System.Reflection;
    using System.Text;
    using System.Linq;

    public class Tokenizer
    {
        #region Fields/Properties

        private static Dictionary<string, MetaType> _keywordTypes;
        private static HashSet<char> _operatorCharacters;
        private static IDictionary<string, MetaType> _operatorTypes;
        private static Dictionary<char, char> _stringEscapes;
        
        private readonly ParseReader _input;
        private Token _next;
        #endregion

        #region Ctors

        public Tokenizer()
        {
            _keywordTypes = new Dictionary<string, MetaType>();
            _operatorCharacters = new HashSet<char>();
            _operatorTypes = new Dictionary<string, MetaType>();

            System.Type[] localTypes = Assembly.GetExecutingAssembly().GetTypes();

            // Find all keyword types in this assembly. 
            // Default location is \Parse\Types
            foreach (var localType in localTypes)
            {
                if (typeof(TokenType).IsAssignableFrom(localType))
                {
                    if (localType.IsAbstract)
                        continue;

                    // All classes that we're loading here may have a single 
                    // parameter constructor. 
                    var ctor = localType.GetConstructor(new System.Type[] { typeof(string) });

                    TokenType t;
                    if (ctor != null)
                        t = (TokenType)Activator.CreateInstance(localType, new object[] { "" });
                    else
                        t = (TokenType)Activator.CreateInstance(localType);

                    if (t.GetType() == MetaType.Keyword)
                    {
                        _keywordTypes.Add(t.GetText(), (t.GetType())); 
                    }
                    else if (t.GetType() == MetaType.Operator)
                    {
                        _operatorTypes.Add(t.GetText(), (t.GetType()));
                        for (int i = 0; i < t.GetText().Length; i++)
                        {
                            _operatorCharacters.Add(t.GetText()[i]);
                        }
                    }
                }

            }

            // Gather up all chars representign string escape sequences
            _stringEscapes = new Dictionary<char, char>
                {
                    {'n', '\n'},
                    {'r', '\r'},
                    {'f', '\f'},
                    {'t', '\t'},
                    {'b', '\b'},
                    {'\\', '\\'}
                };
        }

        public Tokenizer(ParseReader input)
            : this()
        {
            _input = input;
        }

        #endregion

        #region Member Methods

        protected ParseReader GetInput
        {
            get { return _input; }
        }

        //public Token NextToken()
        //{
        //    Token result = null;

        //    DiscardWhitespace();

        //    if (GetInput.Peek() == -1) // Eof
        //    {
        //        var tokenType = new EoF();
        //        result = new Token(tokenType, tokenType.GetText());
        //    }
        //    else if (char.IsLetter(Convert.ToChar(GetInput.Peek()))) // Symbol or Keyword
        //    {
        //        var buffer = new StringBuilder();
        //        while (char.IsLetter(Convert.ToChar(GetInput.Peek())))
        //        {
        //            buffer.Append((char)GetInput.Read());
        //        }

        //        string text = buffer.ToString();
        //        if (_keywordTypes.ContainsKey(text))
        //        {
        //            // Get a matching class name
        //            var type = Assembly.GetExecutingAssembly().GetTypes()
        //                .Single(d => d.Name.Equals(text, StringComparison.OrdinalIgnoreCase));

        //            var instance = Activator.CreateInstance(type) as TokenType;
        //            result = new Token(instance, text);
        //        }
        //        else
        //        {
        //            TokenType type = new Symbol(text);
        //            result = new Token(type, type.GetText());
        //        }
        //    }
        //    else if (char.IsDigit(Convert.ToChar(GetInput.Peek()))) // Numeric type
        //    {
        //        int offset = GetInput.GetOffset();
        //        var buffer = new StringBuilder();

        //        while (char.IsDigit(Convert.ToChar(GetInput.Peek())))
        //            buffer.Append((char)GetInput.Read());

        //        // If the next char after a digit is a period, we 
        //        // need to check to ensure there is at least one 
        //        // digit after the period. Otherwise, it's just an Int
        //        if (GetInput.Peek() == '.')
        //        {
        //            buffer.Append((char)GetInput.Expect('.'));
        //            if (char.IsDigit(Convert.ToChar(GetInput.Peek())))
        //            {
        //                while (char.IsDigit(Convert.ToChar(GetInput.Peek())))
        //                    buffer.Append((char)GetInput.Read());

        //                result = new Token(new Float(), buffer.ToString());
        //            }
        //            else
        //            {
        //                throw new InternalStorkNetException("Floating-point numbers must have at least one digit after the decimal.");
        //            }
        //        }
        //        else
        //        {
        //            result = new Token(new Int(), buffer.ToString());
        //        }
        //    }
        //    else if (GetInput.Peek() == '\"') // String literal
        //    {
        //        var buffer = new StringBuilder();
        //        GetInput.Expect('\"');

        //        while(GetInput.Peek() != -1 && GetInput.Peek() != '\n' && GetInput.Peek() != '\"')
        //        {
        //            char c = Convert.ToChar(GetInput.Read());
        //            if(c == '\\') // THis might be an escape character
        //            {
        //                if(GetInput.Peek() != -1)
        //                {
        //                    if(_stringEscapes.ContainsKey((char)GetInput.Peek()))
        //                    {

        //                        buffer.Append(_stringEscapes[Convert.ToChar(GetInput.Read())]);
        //                    }
        //                    else
        //                    {
        //                        throw new InternalStorkNetException("Unrecognized escape sequence: " + Convert.ToChar(GetInput.Peek()) +
        //                        "at offset: " + GetInput.GetOffset());
        //                    }
        //                }
        //                else
        //                {
        //                    throw new InternalStorkNetException("Unexpected end of file. Offset: " + GetInput.GetOffset());
        //                }
        //            }
        //            else
        //            {
        //                buffer.Append(c);
        //            }
        //        }
        //        GetInput.Expect('\"');
        //        result = new Token(new String(), buffer.ToString());
        //    }
        //    else if (_operatorCharacters.Contains(Convert.ToChar(GetInput.Peek()))) // Operator
        //    {
        //        int offset = GetInput.GetOffset();
        //        var buffer = new StringBuilder();

        //        buffer.Append(Convert.ToChar(GetInput.Peek()));

        //        // todo: Not sure what's going on here. Investigate
        //        while(_operatorTypes.ContainsKey(buffer.ToString()))
        //        {
        //            GetInput.Read();
        //            if(GetInput.Peek() != -1)
        //            {
        //                buffer.Append(Convert.ToChar(GetInput.Peek()));
        //            }
        //            else
        //            {
        //                buffer.Append(' ');
        //                break;
        //            }
        //        }

        //        if(!_operatorTypes.ContainsKey(buffer.ToString().Trim()))
        //            throw new InternalStorkNetException("Unrecognized operator: " + buffer.ToString() + "at offset: "  + offset);

        //        // Get whatever class that this buffer matches. For instance, 
        //        // if the buffer.ToString() == "*", the the class would be Star(), etc.
        //        var types = Assembly.GetExecutingAssembly().GetTypes().Where(t => typeof (TokenType).IsAssignableFrom(t) && !t.IsAbstract);
        //        foreach (var type in types)
        //        {
        //            var instance = Activator.CreateInstance(type) as TokenType;

        //            if (instance != null)
        //            {
        //                if (instance.GetText().Equals(buffer.ToString().Trim()))
        //                {
        //                    result = new Token(instance, instance.GetText());
        //                    // We found a matching class, so no need to search through
        //                    // any remaining types
        //                    break;
        //                }
        //            }
        //        }

        //        if(result == null)
        //            throw new InternalStorkNetException(
        //                "Unable to find operator type in current list of TokenType derived classes. Ensure there is a class, derived from TokenType which matches " +
        //                "the current operator text: " + buffer);
        //    }
        //    else
        //    {
        //        throw new InternalStorkNetException("Unrecognized character; " + Convert.ToChar(GetInput.Peek()));
        //    }

        //    return result;
        //}

        public Token NextToken()
        {
            Token result = PeekToken();
            _next = null;

            return result;
        }

        protected void DiscardWhitespace()
        {
            if (GetInput.Peek() == -1)
                return;

            while (char.IsWhiteSpace(Convert.ToChar(GetInput.Peek())))
            {
                GetInput.Read();
            }
        }

        public void Close()
        {
            GetInput.Close();
        }

        public TokenType PeekType()
        {
            return PeekToken().GetType();
        }

        public Token PeekToken()
        {
            if (_next == null)
            {
                //todo: Begin here next time!!!!
            }

            return _next;
        }

        public Token ConsumeToken(TokenType type)
        {
            Token result = NextToken();
            if(result.GetType() != type)
            {
                throw new ParseException("Expected token '" + type + "', found '" + result.GetType() + "'");
            }

            return result;
        }

        #endregion

    }
}
