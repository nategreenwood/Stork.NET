using System;
using System.Diagnostics;
using System.Globalization;
using System.Runtime.InteropServices;
using System.ComponentModel.Design;
using Microsoft.Win32;
using Microsoft.VisualStudio;
using Microsoft.VisualStudio.Shell.Interop;
using Microsoft.VisualStudio.OLE.Interop;
using Microsoft.VisualStudio.Shell;
using Microsoft.VisualStudio;
using Microsoft.VisualStudio.Package;
using Microsoft.VisualStudio.TextManager.Interop;

namespace NateGreenwood.StorkNetLanguageService
{
    /// <summary>
    /// This is the class that implements the package exposed by this assembly.
    ///
    /// The minimum requirement for a class to be considered a valid package for Visual Studio
    /// is to implement the IVsPackage interface and register itself with the shell.
    /// This package uses the helper classes defined inside the Managed Package Framework (MPF)
    /// to do it: it derives from the Package class that provides the implementation of the 
    /// IVsPackage interface and uses the registration attributes defined in the framework to 
    /// register itself and its components with the shell.
    /// </summary>
    // This attribute tells the PkgDef creation utility (CreatePkgDef.exe) that this class is
    // a package.
    [PackageRegistration(UseManagedResourcesOnly = true)]
    // This attribute is used to register the information needed to show this package
    // in the Help/About dialog of Visual Studio.
    [InstalledProductRegistration("#110", "#112", "1.0", IconResourceID = 400)]
    // This attribute is needed to let the shell know that this package exposes some menus.
    [ProvideMenuResource("Menus.ctmenu", 1)]
    [Guid(GuidList.guidStorkNetLanguageServicePkgString)]

    [ProvideService(typeof(StorkNetLanguageService), ServiceName = "StorkNet Language Service")]
    [ProvideLanguageService(typeof(StorkNetLanguageService),
        "StorkNet Language Service",
        106,
        CodeSense = true,
        RequestStockColors = false,
        EnableCommenting = true,
        EnableAsyncCompletion = true)]
    [ProvideLanguageExtension(typeof(StorkNetLanguageService), ".stork")]
    [ProvideLanguageCodeExpansion(typeof(StorkNetLanguageService),
        "StorkNet",
        106,
        "stork",
        @"%InstallRoot%\StorkNet\SnippetsIndex.xml", // Path to snippets index
        SearchPaths = @"%InstallRoot%\StorkNet\Snippets\%LCID%\Snippets\;" +
                           @"%TestDocs%\Code Snippets\StorkNet\Test Code Snippets")]
    //todo: Add optons page to IDE Options editor
    // Must get this working:
    // [ProvideLanguageEditorOptionAttribute(
    //"Test Language",  // Registry key name for language
    //"Options",      // Registry key name for property page
    //"#242",         // Localized name of property page
    //OptionPageGuid = "{A2FE74E1-FFFF-3311-4342-123052450768}"  // GUID of property page
    //)]
    public sealed class StorkNetLanguageServicePackage : Package, IOleComponent
    {
        #region Ctors

        /// <summary>
        /// Default constructor of the package.
        /// Inside this method you can place any initialization code that does not require 
        /// any Visual Studio service because at this point the package object is created but 
        /// not sited yet inside Visual Studio environment. The place to do all the other 
        /// initialization is the Initialize method.
        /// </summary>
        public StorkNetLanguageServicePackage()
        {
            Debug.WriteLine(string.Format(CultureInfo.CurrentCulture, "Entering constructor for: {0}", this.ToString()));
        }

        #endregion

        /////////////////////////////////////////////////////////////////////////////
        // Overridden Package Implementation
        #region Package Members

        /// <summary>
        /// Initialization of the package; this method is called right after the package is sited, so this is the place
        /// where you can put all the initialization code that rely on services provided by VisualStudio.
        /// </summary>
        protected override void Initialize()
        {
            Debug.WriteLine (string.Format(CultureInfo.CurrentCulture, "Entering Initialize() of: {0}", this.ToString()));
            base.Initialize();

            // Add our command handlers for menu (commands must exist in the .vsct file)
            OleMenuCommandService mcs = GetService(typeof(IMenuCommandService)) as OleMenuCommandService;
            if ( null != mcs )
            {
                // Create the command for the menu item.
                CommandID menuCommandID = new CommandID(GuidList.guidStorkNetLanguageServiceCmdSet, (int)PkgCmdIDList.cmdidInsertSnippet);
                MenuCommand menuItem = new MenuCommand(MenuItemCallback, menuCommandID );
                mcs.AddCommand( menuItem );
            }

            //**********************************************************************************
            // LANGUAGE SERVICE INTEGRATION SHIT
            // http://msdn.microsoft.com/en-us/library/bb166498.aspx
            
            // Proffer the service
            IServiceContainer serviceContainer = this as IServiceContainer;
            StorkNetLanguageService languageService = new StorkNetLanguageService();

            languageService.SetSite(this);
            serviceContainer.AddService(typeof (StorkNetLanguageService), languageService, true);
            
            // Register a timer to call our langauge service during idle periods.

        }

        #endregion

        #region MenuItem Callback

        /// <summary>
        /// This function is the callback used to execute a command when the a menu item is clicked.
        /// See the Initialize method to see how the menu item is associated to this function using
        /// the OleMenuCommandService service and the MenuCommand class.
        /// </summary>
        private void MenuItemCallback(object sender, EventArgs e)
        {
            // Show a Message Box to prove we were here
            IVsUIShell uiShell = (IVsUIShell)GetService(typeof(SVsUIShell));
            Guid clsid = Guid.Empty;
            int result;
            Microsoft.VisualStudio.ErrorHandler.ThrowOnFailure(uiShell.ShowMessageBox(
                       0,
                       ref clsid,
                       "StorkNetLanguageService",
                       string.Format(CultureInfo.CurrentCulture, "Inside {0}.MenuItemCallback()", this.ToString()),
                       string.Empty,
                       0,
                       OLEMSGBUTTON.OLEMSGBUTTON_OK,
                       OLEMSGDEFBUTTON.OLEMSGDEFBUTTON_FIRST,
                       OLEMSGICON.OLEMSGICON_INFO,
                       0,        // false
                       out result));
        }

        #endregion

        /////////////////////////////////////////////////////////////////////////////
        // Overridden IOleCommand Implementation

        #region IOleComponent Overrides

        public int FContinueMessageLoop(uint uReason, IntPtr pvLoopData, MSG[] pMsgPeeked)
        {
            return 1;
        }

        public int FDoIdle(uint grfidlef)
        {
            // Only override needed for language service needs
            bool periodic = (grfidlef & (uint) _OLEIDLEF.oleidlefPeriodic) != 0;
            LanguageService svc = GetService(typeof (StorkNetLanguageService)) as LanguageService;

            if(svc != null)
            {
                svc.OnIdle(periodic);
            }

            return 0;
        }

        public int FPreTranslateMessage(MSG[] pMsg)
        {
            return 0;
        }

        public int FQueryTerminate(int fPromptUser)
        {
            return 1;
        }

        public int FReserved1(uint dwReserved, uint message, IntPtr wParam, IntPtr lParam)
        {
            throw new NotImplementedException();
        }

        public IntPtr HwndGetWindow(uint dwWhich, uint dwReserved)
        {
            return IntPtr.Zero;
        }

        public void OnActivationChange(IOleComponent pic, int fSameComponent, OLECRINFO[] pcrinfo, int fHostIsActivating, OLECHOSTINFO[] pchostinfo, uint dwReserved)
        {
        }

        public void OnAppActivate(int fActive, uint dwOtherThreadID)
        {
        }

        public void OnEnterState(uint uStateID, int fEnter)
        {
        }

        public void OnLoseActivation()
        {
        }

        public void Terminate()
        {
        }

        #endregion
    }
}
