using System.Management.Automation;
using DeepConsole.Controllers;
using DeepConsole.Core;

namespace DeepConsole.Cmdlets
{
   [Cmdlet( "Write", "ColorTable" )]
   public class WriteColorTable : PSCmdlet
   {
      protected override void ProcessRecord()
      {
         var controller = new ConsoleController( new ConsoleModifier() );
         controller.WriteColorTable();
      }
   }
}
