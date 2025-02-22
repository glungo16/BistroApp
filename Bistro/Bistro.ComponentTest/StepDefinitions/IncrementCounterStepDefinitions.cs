using System;
using AngleSharp.Css.Values;
using Bistro.Common;
using Bistro.WASMView.Pages;
using Bunit;
using Reqnroll;

namespace Bistro.ComponentTest.StepDefinitions
{
    [Binding]
    public class IncrementCounterStepDefinitions
    {
        TestContext ctx;
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
            for (int i = 0; i < numberOfClicks; i++)
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
}
