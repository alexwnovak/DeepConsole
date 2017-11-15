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

         bufferInfo.ColorTable[index] = new COLORREF
         {
            R = color.R,
            G = color.G,
            B = color.B
         };

         NativeMethods.SetConsoleScreenBufferInfoEx( stdout, ref bufferInfo );
      }

      public void SetColors( int[] indices, Color[] colors )
      {
         var stdout = NativeMethods.GetStdHandle( NativeMethods.STD_OUTPUT_HANDLE );

         var bufferInfo = new CONSOLE_SCREEN_BUFFER_INFO_EX();
         bufferInfo.cbSize = Marshal.SizeOf( bufferInfo );

         NativeMethods.GetConsoleScreenBufferInfoEx( stdout, ref bufferInfo );

         for ( int index = 0; index < indices.Length; index++ )
         {
            bufferInfo.ColorTable[indices[index]] = new COLORREF
            {
               R = colors[index].R,
               G = colors[index].G,
               B = colors[index].B
            };
         }

         NativeMethods.SetConsoleScreenBufferInfoEx( stdout, ref bufferInfo );
      }
   }
}
