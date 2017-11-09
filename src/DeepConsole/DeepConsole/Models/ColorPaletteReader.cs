using System.Drawing;
using System.Linq;
using Newtonsoft.Json.Linq;

namespace DeepConsole.Models
{
   public class ColorPaletteReader
   {
      public ColorPalette FromJson( string json )
      {
         JObject jsonObject = JObject.Parse( json );

         var colorConverter = new ColorConverter();

         var indices = jsonObject["colors"].Select( c => (int) c["index"] ).ToArray();
         var colors = jsonObject["colors"].Select( c => (Color) colorConverter.ConvertFromString( (string) c["color"] ) ).ToArray();

         var colorPalette = new ColorPalette();

         for ( int index = 0; index < indices.Length; index++ )
         {
            var colorDefinition = new ColorDefinition( indices[index], colors[index] );
            colorPalette.Add( colorDefinition );
         }

         return colorPalette;
      }
   }
}
