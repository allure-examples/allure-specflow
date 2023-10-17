using TechTalk.SpecFlow;

namespace Allure.Examples.SpecFlow3.StepDefinitions.UISteps;

[Binding]
[Scope(Feature = "Labels UI")]
public class LabelsUISteps : UIStepsBase
{
    protected override async Task RollbackChanges()
    {
        await Step(
            "Clear labels",
            async () => await Task.CompletedTask
        );
    }

    [When("I open labels page")]
    public async Task OpenLabelsPage()
    {
        await this.MaybeThrowElementNotFoundException();
    }

    [When("I create label with title \"(.*)\"")]
    public async Task CreateLabel(string labelTitle)
    {
        await this.MaybeThrowElementNotFoundException();
    }

    [When("I open issue with id (.*)")]
    public async Task OpenIssuePage(int issueId)
    {
        await this.MaybeThrowElementNotFoundException();
    }

    [When("I add label with title \"(.*)\" to issue")]
    public async Task AddLabelToIssue(string labelTitle)
    {
        await this.MaybeThrowElementNotFoundException();
    }

    [When("I filter issue by label title \"(.*)\"")]
    public async Task FilterIssuesByLabel(string labelTitle)
    {
        await this.MaybeThrowElementNotFoundException();
    }

    [When("I delete label with title \"(.*)\"")]
    public async Task DeleteLabel(string labelTitle)
    {
        await this.MaybeThrowElementNotFoundException();
    }

    [Then("I should see label with title \"(.*)\"")]
    public async Task AssertLabel(string labelTitle) => await Task.CompletedTask;

    [Then("I should see issue with label title \"(.*)\"")]
    public async Task AssertIssueWithLabel(string labelTitle)
    {
        await this.MaybeThrowAssertionException(
            $"No issue in list filtered by {labelTitle} label"
        );
    }

    [Then("I should not see label with title \"(.*)\"")]
    public async Task AssertNoLabel(string labelTitle)
    {
        await this.MaybeThrowAssertionException(
            $"Label {labelTitle} still exists"
        );
    }
}
