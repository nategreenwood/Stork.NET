// Guids.cs
// MUST match guids.h
using System;

namespace NateGreenwood.StorkNetLanguageService
{
    static class GuidList
    {
        public const string guidStorkNetLanguageServicePkgString = "cc60f41f-9fe1-49f7-810d-f57e0d2a46c6";
        public const string guidStorkNetLanguageServiceCmdSetString = "b57e5795-4e17-414e-b183-bdb569b1ae21";

        public static readonly Guid guidStorkNetLanguageServiceCmdSet = new Guid(guidStorkNetLanguageServiceCmdSetString);
    };
}