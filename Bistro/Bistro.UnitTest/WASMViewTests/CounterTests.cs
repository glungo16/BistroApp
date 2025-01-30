using Bistro.WASMView.Pages;
using Bunit;

namespace Bistro.UnitTest.WASMViewTests
{
    public class CounterTests
    {
        [Fact]
        public void CounterShouldIncrementWhenClicked()
        {
            // Arrange

            using var ctx = new TestContext();
            var rc = ctx.RenderComponent<Counter>();
            

            // Act

            rc.Find("button").Click();


            // Assert
            var counterDisplay = rc.Find("p").TextContent;
            counterDisplay.MarkupMatches("Current count: 1");
        }
    }
}