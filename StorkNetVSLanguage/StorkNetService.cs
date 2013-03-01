using Microsoft.VisualStudio;
using Microsoft.VisualStudio.Package;
using Microsoft.VisualStudio.TextManager.Interop;
using Microsoft.VisualStudio.OLE.Interop;

namespace NateGreenwood.StorkNetVSLanguage
{
    class StorkNetService : LanguageService
    {
        #region Overrides of LanguageService

        public override LanguagePreferences GetLanguagePreferences()
        {
            return new LanguagePreferences();
        }

        public override IScanner GetScanner(IVsTextLines buffer)
        {
            var scanner = new StorkNetServiceScanner();

            return scanner;
        }

        public override AuthoringScope ParseSource(ParseRequest req)
        {
            throw new System.NotImplementedException();
        }

        public override string GetFormatFilterList()
        {
            throw new System.NotImplementedException();
        }

        public override string Name
        {
            get { return "StorkNet"; }
        }

        #endregion
    }
}
