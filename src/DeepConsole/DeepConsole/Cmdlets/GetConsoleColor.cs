using System.Management.Automation;
using DeepConsole.Controllers;
using DeepConsole.Core;

namespace DeepConsole.Cmdlets
{
   [Cmdlet( VerbsCommon.Get, "ConsoleColor" )]
   public class GetConsoleColor : PSCmdlet
   {
      [Parameter(
         Mandatory = true,
         Position = 0,
         HelpMessage = "The color index (from 0-15) for the color index to get"
      )]
      public int Index
      {
         get;
         set;
      }

      protected override void ProcessRecord()
      {
         var controller = new ConsoleController( new ConsoleModifier() );

         var color = controller.GetColor( Index );

         WriteObject( color );
      }
   }
}
