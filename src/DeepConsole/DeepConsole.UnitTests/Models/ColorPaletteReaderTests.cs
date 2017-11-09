using System.Drawing;
using Xunit;
using FluentAssertions;
using DeepConsole.Models;

namespace DeepConsole.UnitTests.Models
{
   public class ColorPaletteReaderTests
   {
      [Fact]
      public void FromJson_ContainsOneColorDefinition_DefinitionIsRead()
      {
         const string json = "{ \"colors\": [ { index: 7, color: \"0,255,0\" } ] }";

         var colorPaletteReader = new ColorPaletteReader();

         var colorPalette = colorPaletteReader.FromJson( json );

         colorPalette.ColorDefinitions
            .Should()
            .HaveCount( 1 )
            .And
            .Contain( cd => cd.Index == 7 && cd.Color == Color.Lime );
      }

      [Fact]
      public void FromJson_ContainsTwoColorDefinitions_DefinitionsAreRead()
      {
         const string json = "{ \"colors\": [ { index: 0, color: \"0,0,0\" }, { index: 7, color: \"255,0,0\" } ] }";

         var colorPaletteReader = new ColorPaletteReader();

         var colorPalette = colorPaletteReader.FromJson( json );

         colorPalette.ColorDefinitions
            .Should()
            .HaveCount( 2 )
            .And
            .Contain( cd => cd.Index == 0 && cd.Color == Color.Black )
            .And
            .Contain( cd => cd.Index == 7 && cd.Color == Color.Red );
      }
   }
}
