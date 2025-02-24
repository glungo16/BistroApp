using Bistro.Common;
using Bistro.WASMView.Pages;
using Bunit;

namespace Bistro.UnitTest.WASMViewTests;

public class CounterTests
{
	[Fact]
	public void CounterShouldIncrementWhenClicked()
	{
		// Arrange
		using var ctx = new TestContext();
		var rc = ctx.RenderComponent<Counter>();

		// Act
		rc.Find(Constants.Button).Click();

		// Assert
		var counterDisplay = rc.Find(Constants.Paragraph).TextContent;
		counterDisplay.MarkupMatches("Current count: 1");
	}
}
