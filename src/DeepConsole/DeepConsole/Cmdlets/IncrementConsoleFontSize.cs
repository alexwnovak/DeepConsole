﻿using System.Management.Automation;
using DeepConsole.Core.Interop;

namespace DeepConsole.Cmdlets
{
   [Cmdlet( "Increment", "ConsoleFontSize" )]
   public class IncrementConsoleFontSize : PSCmdlet
   {
      protected override void ProcessRecord()
      {
         var stdout = NativeMethods.GetStdHandle( NativeMethods.STD_OUTPUT_HANDLE );

         var bufferInfo = new CONSOLE_FONT_INFO_EX();

         NativeMethods.GetCurrentConsoleFontEx( stdout, false, bufferInfo );

         bufferInfo.FontHeight++;
         NativeMethods.SetCurrentConsoleFontEx( stdout, false, bufferInfo );
      }
   }
}
