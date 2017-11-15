using System;
using System.Drawing;
using System.Linq;
using DeepConsole.Core;
using DeepConsole.Models;

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

      public void SetConsolePalette( string paletteFilePath )
      {
         string json = System.IO.File.ReadAllText( paletteFilePath );

         var colorPalette = new ColorPaletteReader().FromJson( json );

         var indices = colorPalette.ColorDefinitions.Select( cd => cd.Index ).ToArray();
         var colors = colorPalette.ColorDefinitions.Select( cd => cd.Color ).ToArray();

         _consoleModifier.SetColors( indices, colors );

         throw new NotImplementedException();
      }
   }
}
