namespace Stork.ConsoleHarness
{
    using System;
    using System.IO;
    using NET.Core.Engine.Compilation;
    using NET.Core.Exception;
    using NET.Core.IO;
    using Stork.NET.Core.Engine.Runtime;
    using System.Text;

    class Program
    {
        public static TextReader IN;
        public static TextWriter OUT;
        public static TextWriter ERROR;

        static void Main(string[] args)
        {
            Interactive();
        }

        private void TokenizerOutput()
        {
            string testString = "";
            testString = File.ReadAllText(Environment.CurrentDirectory + @"\ExampleTextFiles\SampleInputFileForTokenization.txt");
            if (string.IsNullOrEmpty(testString))
                return;

            using (var t = new StringReader(testString))
            {
                var tokenizer = new Tokenizer(new ParseReader(t));
                var currentToken = tokenizer.NextToken();

                while (currentToken.GetText() != "$")
                {
                    Console.WriteLine(currentToken.GetType() + " " + currentToken.GetText());
                    currentToken = tokenizer.NextToken();
                }
            }

            Console.ReadKey();
        }

        public static void Interactive()
        {
            IN = Console.In;
            OUT = Console.Out;
            ERROR = Console.Error;

            try
            {
                var scope = new Scope();
                var compiler = new Translator();

                for (string line = Line(); line != null; line = Line())
                {
                    Tokenizer tokens = new Tokenizer(new ParseReader(new StringReader(line)));
                    try
                    {
                        Parser parser = new Parser(tokens);
                        try
                        {
                            StmtAST stmt = parser.Stmt();
                            if(parser.Tokens.PeekType() != new EoF())
                                ERROR.WriteLine("WARNING: Ignoring tokens: " + parser.Tokens.PeekToken().GetText());
                            
                            object value = stmt.Translate(compiler).Exec(scope);
                            if(value != null)
                                OUT.WriteLine(value.ToString());
                            
                            OUT.Flush();

                        }
                        catch(InternalStorkNetException e)
                        {
                            OUT.Write("INTERNAL ERROR: " + e.Message + "\n");
                            OUT.Write(e.StackTrace);
                        }
                        catch(StorkNetException e)
                        {
                            OUT.Write("ERROR: " + e.Message + "\n");
                        }
                    }
                    finally
                    {
                        tokens.Close();
                    }
                }
            }
            catch (Exception e)
            {
                OUT.WriteLine(e.StackTrace);
            }
        }

        public static string Line()
        {
            string result;

            OUT.Write(">>> "); 
            OUT.Flush();

            int ch = IN.Read();
            if(ch != -1)
            {
                var buffer = new StringBuilder();
                buffer.Append((char) ch);

                for (ch = IN.Read(); ch != -1; ch = IN.Read())
                {
                    if (ch != '\n')
                        buffer.Append((char) ch);
                    else
                    {
                        break;
                    }
                }
                result = buffer.ToString().Trim();
            }
            else
            {
                result = null;
            }

            return result;
        }
    }
}
