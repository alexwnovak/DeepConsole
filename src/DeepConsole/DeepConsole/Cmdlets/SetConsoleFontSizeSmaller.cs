using System.Management.Automation;
using DeepConsole.Core.Interop;

namespace DeepConsole.Cmdlets
{
   [Cmdlet( VerbsCommon.Set, "ConsoleFontSizeSmaller" )]
   public class SetConsoleFontSizeSmaller : PSCmdlet
   {
      protected override void ProcessRecord()
      {
         var stdout = NativeMethods.GetStdHandle( NativeMethods.STD_OUTPUT_HANDLE );

         var bufferInfo = new CONSOLE_FONT_INFO_EX();

         NativeMethods.GetCurrentConsoleFontEx( stdout, false, bufferInfo );

         bufferInfo.FontHeight--;
         NativeMethods.SetCurrentConsoleFontEx( stdout, false, bufferInfo );
      }
   }
}
