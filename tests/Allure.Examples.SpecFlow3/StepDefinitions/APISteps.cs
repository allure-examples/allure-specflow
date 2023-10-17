using TechTalk.SpecFlow;

namespace Allure.Examples.SpecFlow3.StepDefinitions;

[Binding]
public class APISteps
{
#nullable disable
    Random random;
#nullable enable

    [BeforeScenario]
    public void SetupAPIConnection()
    {
        this.random = random = new();
    }

    [AfterScenario]
    public void DisposeAPIConnection() { }

    [When("I create label with title \"(.*)\" via api")]
    public void CreateLabel(string title)
    {
        Step("POST /repos/:owner/:repo/labels");
    }

    [When("I delete label with title \"(.*)\" via api")]
    public void DeleteLabel(string title)
    {
        var labelId = FindLabelByTitle(title);
        Step($"DELETE /repos/:owner/:repo/labels/{labelId}");
    }

    [Then("I should see label with title \"(.*)\" via api")]
    public void AssertLabel(string title)
    {
        var labelId = FindLabelByTitle(title);
        Step($"GET /repos/:owner/:repo/labels/{labelId}");
    }

    [Then("I should not see label with title \"(.*)\" via api")]
    public void AssertNoLabel(string title)
    {
        _ = FindLabelByTitle(title);
    }

    int FindLabelByTitle(string title)
    {
        Step("GET /repos/:owner/:repo/labels?text=" + title);
        return random.Next(1000);
    }
}
