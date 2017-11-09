using System;
using System.Drawing;
using DeepConsole.Core;

namespace DeepConsole.Controllers
{
   public class ConsoleController
   {
      private readonly IConsoleModifier _consoleModifier;

      public ConsoleController( IConsoleModifier consoleModifier )
      {
         _consoleModifier = consoleModifier;
      }

      public void SetColor( int index, Color color )
      {
         _consoleModifier.SetColor( index, color );
      }

      public Color GetColor( int index )
      {
         return _consoleModifier.GetColor( index );
      }

      public void SetColorPalette( string paletteFilePath )
      {
         throw new NotImplementedException();
      }
   }
}
