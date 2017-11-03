using System.Drawing;
using DeepConsole.Controllers;
using DeepConsole.Core;
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
   }
}
