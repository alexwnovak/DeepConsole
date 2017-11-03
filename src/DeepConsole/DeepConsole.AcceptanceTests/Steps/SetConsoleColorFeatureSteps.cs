using System;
using System.Drawing;
using TechTalk.SpecFlow;

namespace DeepConsole.AcceptanceTests.Steps
{
   [Binding]
   public class SetConsoleColorFeatureSteps
   {
      [StepArgumentTransformation]
      public Color ColorTransform( string colorString )
      {
         var colorConverter = new ColorConverter();
         return (Color) colorConverter.ConvertFromString( colorString );
      }

      [When( @"I call SetConsoleColor with index (.*) and color (.*)" )]
      public void WhenICallSetConsoleColorWithIndexAndColorRed( int index, Color color )
      {
         ScenarioContext.Current.Pending();
      }

      [Then( @"console color (.*) should be (.*)" )]
      public void ThenConsoleColorShouldBeRed( int index, Color color )
      {
         ScenarioContext.Current.Pending();
      }
   }
}
