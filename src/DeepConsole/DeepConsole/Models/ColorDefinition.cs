using System.Drawing;

namespace DeepConsole.Models
{
   public struct ColorDefinition
   {
      public int Index
      {
         get;
      }

      public Color Color
      {
         get;
      }

      public ColorDefinition( int index, Color color )
      {
         Index = index;
         Color = color;
      }
   }
}
