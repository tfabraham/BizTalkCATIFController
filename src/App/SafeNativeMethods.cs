// BizTalk CAT Instrumentation Framework Controller
// Copyright (C) 2010-Present Thomas F. Abraham. All Rights Reserved.
// Licensed under the MIT License. See License.txt in the project root.

using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace BizTalkCatInstrumentationController
{
    internal static class SafeNativeMethods
    {
        [DllImport("user32.dll")]
        internal static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);
    }
}
