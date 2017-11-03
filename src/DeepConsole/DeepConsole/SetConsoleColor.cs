using System.Drawing;
using System.Management.Automation;
using System.Runtime.InteropServices;
using DeepConsole.Native;

namespace DeepConsole
{
   [Cmdlet( VerbsCommon.Set, "ConsoleColor" )]
   public class SetConsoleColor : PSCmdlet
   {
      [Parameter(
         Mandatory = true,
         Position = 0,
         HelpMessage = "The color index (from 0-15) for the color index to set"
      )]
      public int Index
      {
         get;
         set;
      }

      [Parameter(
         Mandatory = true,
         Position = 1,
         HelpMessage = "The comma-separated RGB values enclosed in double quotes"
      )]
      public Color Color
      {
         get;
         set;
      }

      private static COLORREF ToColorRef( Color color )
      {
         return new COLORREF
         {
            R = color.R,
            G = color.G,
            B = color.B
         };
      }

      protected override void ProcessRecord()
      {
         var stdout = NativeMethods.GetStdHandle( NativeMethods.STD_OUTPUT_HANDLE );

         var bufferInfo = new CONSOLE_SCREEN_BUFFER_INFO_EX();
         bufferInfo.cbSize = Marshal.SizeOf( bufferInfo );

         NativeMethods.GetConsoleScreenBufferInfoEx( stdout, ref bufferInfo );

         bufferInfo.ColorTable[0] = ToColorRef( Color );

         NativeMethods.SetConsoleScreenBufferInfoEx( stdout, ref bufferInfo );
      }
   }
}
