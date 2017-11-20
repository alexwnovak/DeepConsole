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

      public void WriteColorTable()
      {
         var originalColor = Console.ForegroundColor;

         for ( int index = 0; index < 16; index++ )
         {
            Console.ForegroundColor = (ConsoleColor) index;
            Console.WriteLine( $"Index {index:D2}");
         }

         Console.ForegroundColor = originalColor;
      }
   }
}
