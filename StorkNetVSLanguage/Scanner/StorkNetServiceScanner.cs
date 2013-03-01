using Microsoft.VisualStudio.Package;
using Microsoft.VisualStudio.TextManager.Interop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NateGreenwood.StorkNetVSLanguage
{
    public class StorkNetServiceScanner : IScanner
    {
        private string  _line;
        private int     _offset;
        private string  _source;

        public StorkNetServiceScanner()
        {
            int breakpoint = 0;
        }

        private bool GetNextToken(int startIndex, TokenInfo tokenInfo, ref int state)
        {
            bool bFoundToken = false;
            int endIndex = -1;
            int index = startIndex;
            if (index < _source.Length)
            {
                if (state == (int)ParseState.InQuotes)
                {
                    // Find end quote. If found, set state to InText
                    // and return the quoted string as a single token.
                    // Otherwise, return the string to the end of the line
                    // and keep the same state.

                }
                else if (state == (int)ParseState.InComment)
                {
                    // Find end of comment. If found, set state to InText
                    // and return the comment as a single token.
                    // Otherwise, return the comment to the end of the line
                    // and keep the same state.
                }
                else
                {
                    // Parse the token starting at index, returning the
                    // token's start and end index in tokenInfo, along with
                    // the token's type and color to use.
                    // If the token is a quoted string and the string continues
                    // on the next line, set state to InQuotes.
                    // If the token is a comment and the comment continues
                    // on the next line, set state to InComment.

                    string token = _source.Substring(startIndex, _source.Length);
                    if (token == "int")
                    {

                        tokenInfo.StartIndex = startIndex;
                        tokenInfo.EndIndex = 2;
                        tokenInfo.Color = TokenColor.Keyword;

                        bFoundToken = true;
                    }
                }
            }
            return bFoundToken;
        }

        #region Implementation of IScanner

        public void SetSource(string source, int offset)
        {
            _offset = offset;
            _source = source;
        }

        public bool ScanTokenAndProvideInfoAboutIt(TokenInfo tokenInfo, ref int state)
        {
            bool found = false;
            if(tokenInfo != null)
            {
                found = GetNextToken(_offset, tokenInfo, ref state);
                if(found)
                {
                    _offset = tokenInfo.EndIndex + 1;
                }
            }

            return found;
        }

        #endregion

        private enum ParseState
        {
            InText = 0,
            InQuotes = 1,
            InComment = 2
        }
    }
}
