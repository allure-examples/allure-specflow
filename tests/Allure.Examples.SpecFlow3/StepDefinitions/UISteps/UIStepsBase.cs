using TechTalk.SpecFlow;

namespace Allure.Examples.SpecFlow3.StepDefinitions.UISteps;

public abstract class UIStepsBase
{
#nullable disable
    protected Random Random { get; private set; }
#nullable enable

    [BeforeScenario]
    public async Task SetupSession()
    {
        this.Random = new Random();
        await Task.CompletedTask;
    }

    [AfterScenario]
    public async void DisposeSession()
    {
        await Step("Rollback changes", this.RollbackChanges);
    }

    protected virtual async Task RollbackChanges() => await Task.CompletedTask;

    protected async Task MaybeThrowElementNotFoundException()
    {
        if (this.IsTimeToThrowException())
        {
            throw new Exception(
                "Element not found for xpath [//div[@class='something']]"
            );
        }
        await Task.CompletedTask;
    }

    protected async Task MaybeThrowAssertionException(string text)
    {
        if (this.IsTimeToThrowException())
        {
            Assert.That(text, Is.EqualTo("another text"));
        }
        await Task.CompletedTask;
    }

    bool IsTimeToThrowException()
    {
        return this.Random.Next(4) == 0;
    }
}
