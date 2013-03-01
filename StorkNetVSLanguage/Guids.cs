// Guids.cs
// MUST match guids.h
using System;

namespace NateGreenwood.StorkNetVSLanguage
{
    static class GuidList
    {
        public const string guidStorkNetVSLanguagePkgString = "b8524a8c-82a2-4cc2-b9e2-ace6d2330298";
        public const string guidStorkNetVSLanguageCmdSetString = "971c0ebc-ac5c-45a2-a042-c8ae684e9678";

        public static readonly Guid guidStorkNetVSLanguageCmdSet = new Guid(guidStorkNetVSLanguageCmdSetString);
    };
}