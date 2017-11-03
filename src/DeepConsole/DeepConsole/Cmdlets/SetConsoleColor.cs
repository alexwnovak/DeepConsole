using System.Drawing;
using System.Management.Automation;
using DeepConsole.Core;

namespace DeepConsole.Cmdlets
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

      protected override void ProcessRecord()
      {
         var consoleAttributes = new ConsoleModifier();
         consoleAttributes.SetColor( Index, Color );
      }
   }
}
