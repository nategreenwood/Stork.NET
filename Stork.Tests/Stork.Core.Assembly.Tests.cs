// ReSharper disable CheckNamespace

using System.IO;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace StorkCore.Tests
{
    using Stork.NET.Core.Engine.Compilation;
    using Stork.NET.Core.IO;

    // ReSharper disable InconsistentNaming

    public class Stork_Core_ParseReader_Tests
    {
        private const string stringToRead = "abc 123 1bc ab3 1*2*4 1+2+4 -12";
        private ParseReader reader;
        private TextReader textReader;

        [TestInitialize]
        public void Init()
        {
            textReader = new StringReader(stringToRead);
            reader = new ParseReader(textReader);
        }

        [TestMethod]
        public void ParseReader_Can_Initialize()
        {
            Assert.IsNotNull(reader);
        }

        [TestMethod]
        public void ParseReader_MethodWorks_Peek()
        {
            // Here, the first character to be "peeked" from 
            // the string reader is 'a' or 97 in decimal. 
            // So, we want to peek, then peek again to ensure
            // that we get 'a' back both times`
            int result = reader.Peek();
            Assert.IsTrue(result == 97);

            result = reader.Peek();
            Assert.IsTrue(result == 97);
        }
    }

    public class Stork_Core_Tokenizer_Tests
    {
        [TestClass]
        public class Tokenizer_Constructor
        {
            [TestMethod]
            public void can_instantiate_a_valid_object()
            {
                const string textToRead = @"abc 123 if  while for titan + + *";

                using (TextReader textReader = new StringReader(textToRead))
                {
                    var parseReader = new ParseReader(textReader);
                    var tokenizer = new Tokenizer(parseReader);

                    Assert.IsNotNull(tokenizer);
                }
            }
        }

        [TestClass]
        public class Tokenizer_NextToken_Tests
        {
            private static Tokenizer _tokenizer;
            private const string textToRead = "abc + 23.5 \"My input string\" 123 if \" test a newline \n \"";

            [TestCleanup]
            public void Teardown()
            {
                if (_tokenizer != null)
                    _tokenizer.Close();
                _tokenizer = null;
            }

            [TestMethod]
            public void returns_a_symbol_token_as_first_token()
            {
                const int tokenIndex = 1;
                int currentIndex = 1;
                using (var textReader = new StringReader(textToRead))
                using (var parseReader = new ParseReader(textReader))
                {
                    _tokenizer = new Tokenizer(parseReader);

                    while (true)
                    {
                        var token = _tokenizer.NextToken();

                        if (tokenIndex == currentIndex)
                        {
                            Assert.AreEqual(token.GetText(), "abc");
                            Assert.IsInstanceOfType(token.GetType(), typeof (Symbol));
                            break;
                        }
                        currentIndex++;
                    }
                }
            }

            [TestMethod]
            public void returns_a_operator_token_as_second_token()
            {
                // Assemble
                using (var textReader = new StringReader(textToRead))
                using (var parseReader = new ParseReader(textReader))
                {
                    _tokenizer = new Tokenizer(parseReader);

                    const int tokenIndex = 2;
                    int currentIndex = 1;

                    while (true)
                    {
                        // Act
                        var token = _tokenizer.NextToken();

                        if (tokenIndex == currentIndex)
                        {
                            // Assert
                            Assert.AreEqual(token.GetText(), "+");
                            Assert.IsInstanceOfType(token.GetType(), typeof (Plus));
                            break;
                        }
                        currentIndex++;
                    }
                }
            }

            [TestMethod]
            public void returns_a_float_token_as_third_token()
            {
                // Assemble
                using (var textReader = new StringReader(textToRead))
                using (var parseReader = new ParseReader(textReader))
                {
                    _tokenizer = new Tokenizer(parseReader);

                    const int tokenIndex = 3;
                    int currentIndex = 1;

                    while (true)
                    {
                        // Act
                        var token = _tokenizer.NextToken();

                        if (tokenIndex == currentIndex)
                        {
                            //Assert
                            Assert.AreEqual(token.GetText(), "23.5");
                            Assert.IsInstanceOfType(token.GetType(), typeof (Float));
                            break;
                        }
                        currentIndex++;
                    }
                }
            }

            [TestMethod]
            public void returns_a_string_literal_as_fourth_token()
            {
                // Assemble
                using (var textReader = new StringReader(textToRead))
                using (var parseReader = new ParseReader(textReader))
                {
                    _tokenizer = new Tokenizer(parseReader);

                    const int tokenIndex = 4;
                    int currentIndex = 1;

                    while (true)
                    {
                        // Act
                        var token = _tokenizer.NextToken();

                        if (tokenIndex == currentIndex)
                        {
                            //Assert
                            Assert.AreEqual(token.GetText(), "My input string");
                            Assert.IsInstanceOfType(token.GetType(), typeof (String));
                            break;
                        }
                        currentIndex++;
                    }
                }
            }

            [TestMethod]
            public void returns_a_integer_as_fifth_token()
            {
                // Assemble
                using (var textReader = new StringReader(textToRead))
                using (var parseReader = new ParseReader(textReader))
                {
                    _tokenizer = new Tokenizer(parseReader);

                    const int tokenIndex = 5;
                    int currentIndex = 1;

                    while (true)
                    {
                        // Act
                        var token = _tokenizer.NextToken();

                        if (tokenIndex == currentIndex)
                        {
                            //Assert
                            Assert.AreEqual(token.GetText(), "123");
                            Assert.IsInstanceOfType(token.GetType(), typeof (Int));
                            break;
                        }
                        currentIndex++;
                    }
                }
            }

            [TestMethod]
            public void returns_a_keyword_as_sixth_token()
            {
                // Assemble
                using (var textReader = new StringReader(textToRead))
                using (var parseReader = new ParseReader(textReader))
                {
                    _tokenizer = new Tokenizer(parseReader);

                    const int tokenIndex = 6;
                    int currentIndex = 1;

                    while (true)
                    {
                        // Act
                        var token = _tokenizer.NextToken();

                        if (tokenIndex == currentIndex)
                        {
                            //Assert
                            Assert.AreEqual(token.GetText(), "if");
                            Assert.IsInstanceOfType(token.GetType(), typeof (If));
                            break;
                        }
                        currentIndex++;
                    }
                }
            }
        }
    }

    // ReSharper restore InconsistentNaming
}

// ReSharper restore CheckNamespace