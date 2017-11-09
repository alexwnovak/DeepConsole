using System.Management.Automation;
using DeepConsole.Controllers;
using DeepConsole.Core;

namespace DeepConsole.Cmdlets
{
   [Cmdlet( VerbsCommon.Set, "ConsolePalette" )]
   public class SetConsolePalette : PSCmdlet
   {
      [Parameter(
         Mandatory = true,
         Position = 0,
         HelpMessage = "The JSON file that describes the color palette"
      )]
      public string PaletteFilePath
      {
         get;
         set;
      }

      protected override void ProcessRecord()
      {
         var controller = new ConsoleController( new ConsoleModifier() );
         controller.SetConsolePalette( PaletteFilePath );
      }
   }
}
