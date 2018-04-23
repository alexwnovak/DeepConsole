using System;
using System.Runtime.InteropServices;

namespace DeepConsole.Core.Interop
{
   public static class NativeMethods
   {
      public const int STD_OUTPUT_HANDLE = -11;

      [DllImport( "kernel32.dll", SetLastError = true )]
      public static extern IntPtr GetStdHandle( int nStdHandle );

      [DllImport( "kernel32.dll", SetLastError = true )]
      public static extern bool GetConsoleScreenBufferInfoEx(
         IntPtr hConsoleOutput,
         ref CONSOLE_SCREEN_BUFFER_INFO_EX ConsoleScreenBufferInfo
      );

      [DllImport( "kernel32.dll", SetLastError = true )]
      public static extern bool SetConsoleScreenBufferInfoEx(
         IntPtr hConsoleOutput,
         ref CONSOLE_SCREEN_BUFFER_INFO_EX consoleScreenBufferInfoEx
      );

      [DllImport( "kernel32.dll", SetLastError = true )]
      public static extern bool SetCurrentConsoleFontEx(
         IntPtr hConsoleOutput,
         bool maximumWindow,
         CONSOLE_FONT_INFO_EX ConsoleCurrentFontEx
      );

      [DllImport( "kernel32.dll", CharSet = CharSet.Unicode, SetLastError = true )]
      public static extern bool GetCurrentConsoleFontEx(
         IntPtr hConsoleOutput,
         bool bMaximumWindow,
         [In, Out] CONSOLE_FONT_INFO_EX lpConsoleCurrentFont );
   }
}
