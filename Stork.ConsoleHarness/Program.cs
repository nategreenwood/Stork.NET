namespace Stork.ConsoleHarness
{
    using System;
    using System.IO;
    using NET.Core.IO;
    using NET.Core.Parse;

    class Program
    {
        static void Main(string[] args)
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
    }
}
