using System;
using System.Runtime.InteropServices;

namespace DeepConsole.Native
{
   internal static class NativeMethods
   {
      public const int STD_OUTPUT_HANDLE = -11;

      [DllImport( "kernel32.dll", SetLastError = true )]
      public static extern IntPtr GetStdHandle( int nStdHandle );

      [DllImport( "kernel32.dll", SetLastError = true )]
      public static extern bool GetConsoleScreenBufferInfoEx(
         IntPtr hConsoleOutput,
         ref CONSOLE_SCREEN_BUFFER_INFO_EX ConsoleScreenBufferInfo
      );
   }
}
