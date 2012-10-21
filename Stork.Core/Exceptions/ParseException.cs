using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Stork.NET.Core.Exceptions
{
    [Serializable]
    public class ParseException : Exception
    {
        public ParseException(string textString)
            : base(textString)
        {

        }

        public ParseException(string textString, int offset)
            : base(textString)
        {
            
        }
    }
}
