using System.Drawing;
using System.Linq;
using DeepConsole.Adapters;
using DeepConsole.Controllers;
using DeepConsole.Core;
using DeepConsole.Models;
using FluentAssertions;
using Xunit;
using NanoBuilder;
using Moq;

namespace DeepConsole.UnitTests.Controllers
{
   public class ConsoleControllerTests
   {
      [Fact]
      public void SetColor_SettingColor_ControllerUsesConsoleModifier()
      {
         const int index = 123;
         var color = Color.Red;

         var consoleModifierMock = new Mock<IConsoleModifier>();

         var controller = ObjectBuilder.For<ConsoleController>()
            .With( consoleModifierMock.Object )
            .Build();

         controller.SetColor( index, color );

         consoleModifierMock.Verify( cm => cm.SetColor( index, color ), Times.Once() );
      }

      [Fact]
      public void GetColor_RetrievingColor_UsesTheConsoleModifier()
      {
         const int index = 123;
         var color = Color.Red;

         var consoleModifierMock = new Mock<IConsoleModifier>();
         consoleModifierMock.Setup( cm => cm.GetColor( index ) ).Returns( color );

         var controller = ObjectBuilder.For<ConsoleController>()
            .With( consoleModifierMock.Object )
            .Build();

         var actualColor = controller.GetColor( index );

         actualColor.Should().Be( color );
      }

      [Fact]
      public void SetColorPalette_PaletteContainsOneColorMapping_MappingIsSentToModifier()
      {
         const string filePath = "DoesntMatter";
         var colorPalette = new ColorPalette();
         colorPalette.Add( new ColorDefinition( 5, Color.Red ) );

         var consoleModifierMock = new Mock<IConsoleModifier>();

         var fileSystemMock = new Mock<IJsonReader>();
         fileSystemMock.Setup( fs => fs.ReadAllText<ColorPalette>( filePath ) ).Returns( colorPalette );

         var controller = ObjectBuilder.For<ConsoleController>()
            .With( consoleModifierMock.Object )
            .With( fileSystemMock.Object )
            .Build();

         controller.SetColorPalette( filePath );

         consoleModifierMock.Verify( cm => cm.SetColors(
            It.Is<int[]>( i => i.Length == 1 && i.Contains( 5 ) ),
            It.Is<Color[]>( i => i.Length == 1 && i.Contains( Color.Red ) ) ) );
      }
   }
}
