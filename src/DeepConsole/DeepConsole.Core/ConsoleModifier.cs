﻿using System.Drawing;
using System.Runtime.InteropServices;
using DeepConsole.Core.Interop;

namespace DeepConsole.Core
{
   public class ConsoleModifier : IConsoleModifier
   {
      public Color GetColor( int index )
      {
         var stdout = NativeMethods.GetStdHandle( NativeMethods.STD_OUTPUT_HANDLE );

         var bufferInfo = new CONSOLE_SCREEN_BUFFER_INFO_EX();
         bufferInfo.cbSize = Marshal.SizeOf( bufferInfo );

         NativeMethods.GetConsoleScreenBufferInfoEx( stdout, ref bufferInfo );

         var tableColor = bufferInfo.ColorTable[index];
         return Color.FromArgb( tableColor.R, tableColor.G, tableColor.B );
      }

      public void SetColor( int index, Color color )
      {
         var stdout = NativeMethods.GetStdHandle( NativeMethods.STD_OUTPUT_HANDLE );

         var bufferInfo = new CONSOLE_SCREEN_BUFFER_INFO_EX();
         bufferInfo.cbSize = Marshal.SizeOf( bufferInfo );

         NativeMethods.GetConsoleScreenBufferInfoEx( stdout, ref bufferInfo );

         // For some reason, each call decrements the srWindow.Bottom field, which causes
         // the window to shrink with each call. Setting all colors can dramatically shrink
         // it, so we pre-increment the Bottom to accommodate this behavior (total hack)
         bufferInfo.srWindow.Bottom++;

         bufferInfo.ColorTable[index] = new COLORREF
         {
            R = color.R,
            G = color.G,
            B = color.B
         };

         NativeMethods.SetConsoleScreenBufferInfoEx( stdout, ref bufferInfo );
      }
   }
}
