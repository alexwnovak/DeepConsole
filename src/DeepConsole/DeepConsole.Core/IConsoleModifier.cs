using System.Drawing;

namespace DeepConsole.Core
{
   public interface IConsoleModifier
   {
      Color GetColor( int index );
      void SetColor( int index, Color color );
   }
}
