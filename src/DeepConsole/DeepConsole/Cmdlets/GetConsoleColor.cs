using System.Management.Automation;
using DeepConsole.Core;

namespace DeepConsole.Cmdlets
{
   [Cmdlet( VerbsCommon.Get, "ConsoleColor" )]
   public class GetConsoleColor : PSCmdlet
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

      protected override void ProcessRecord()
      {
         var consoleModifier = new ConsoleModifier();

         var color = consoleModifier.GetColor( Index );

         WriteObject( color );
      }
   }
}
