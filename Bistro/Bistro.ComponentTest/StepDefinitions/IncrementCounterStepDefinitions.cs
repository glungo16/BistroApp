using Bistro.Common;
using Bistro.WASMView.Pages;
using Bunit;

namespace Bistro.ComponentTest.StepDefinitions;

[Binding]
public class IncrementCounterStepDefinitions
{
	private TestContext ctx;
	private IRenderedComponent<Counter> rc;

	[Given("a counter object is initialized")]
	public void GivenACounterObjectIsInitialized()
	{
		ctx = new TestContext();
		rc = ctx.RenderComponent<Counter>();
	}

	[When("the counter button is clicked {int} times")]
	public void WhenTheCounterButtonIsClickedTimes(int numberOfClicks)
	{
		for (var i = 0; i < numberOfClicks; i++)
		{
			rc.Find(Constants.Button).Click();
		}
	}

	[Then("the current counter should be {int}")]
	public void ThenTheCurrentCounterShouldBe(int expectedValue)
	{
		var counterDisplay = rc.Find(Constants.Paragraph).TextContent;
		counterDisplay.MarkupMatches($"Current count: {expectedValue}");
	}

	[AfterScenario]
	public void DisposeComponents()
	{
		ctx.DisposeComponents();
	}
}
