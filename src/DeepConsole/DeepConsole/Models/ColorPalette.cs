using System.Collections.Generic;

namespace DeepConsole.Models
{
   public class ColorPalette
   {
      private readonly List<ColorDefinition> _colorDefinitions = new List<ColorDefinition>();
      public IReadOnlyCollection<ColorDefinition> ColorDefinitions => _colorDefinitions.AsReadOnly();

      public void Add( ColorDefinition colorDefinition ) => _colorDefinitions.Add( colorDefinition );
   }
}
