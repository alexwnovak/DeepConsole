using System.Drawing;

namespace DeepConsole.Core
{
   public interface IConsoleModifier
   {
      void SetColor( int index, Color color );
   }
}
