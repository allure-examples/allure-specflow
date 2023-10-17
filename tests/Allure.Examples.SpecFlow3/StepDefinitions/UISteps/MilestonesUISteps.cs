using TechTalk.SpecFlow;

namespace Allure.Examples.SpecFlow3.StepDefinitions.UISteps;

[Binding]
[Scope(Feature = "Milestones UI")]
public class MilestonesUISteps : UIStepsBase
{
    protected override async Task RollbackChanges()
    {
        await Step(
            "Clear milestones",
            async () => await Task.CompletedTask
        );
    }

    [When("I open milestones page")]
    public async Task OpenMilestonesPage() => await Task.CompletedTask;

    [When("I create milestone with title \"(.*)\"")]
    public async Task CreateMilestone(string title) => await Task.CompletedTask;

    [When("I delete milestone with title \"(.*)\"")]
    public async Task DeleteMilestone(string title) => await Task.CompletedTask;

    [Then("I should see milestone with title \"(.*)\"")]
    public async Task AssertMilestone(string title) => await Task.CompletedTask;

    [Then("I should not see milestone with title \"(.*)\"")]
    public async Task AssertNoMilestone(string title) => await Task.CompletedTask;
}
