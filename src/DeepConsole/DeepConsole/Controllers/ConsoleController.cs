using System.Drawing;
using System.Linq;
using DeepConsole.Adapters;
using DeepConsole.Core;
using DeepConsole.Models;

namespace DeepConsole.Controllers
{
   public class ConsoleController
   {
      private readonly IConsoleModifier _consoleModifier;
      private readonly IJsonReader _jsonReader;

      public ConsoleController( IConsoleModifier consoleModifier, IJsonReader jsonReader )
      {
         _consoleModifier = consoleModifier;
         _jsonReader = jsonReader;
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
         var colorPalette = _jsonReader.ReadAllText<ColorPalette>( paletteFilePath );

         var indices = colorPalette.ColorDefinitions.Select( cd => cd.Index ).ToArray();
         var colors = colorPalette.ColorDefinitions.Select( cd => cd.Color ).ToArray();

         _consoleModifier.SetColors( indices, colors );
      }
   }
}
