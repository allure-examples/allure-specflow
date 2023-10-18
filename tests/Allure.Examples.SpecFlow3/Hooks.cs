using System.Reflection;
using System.Text;
using Allure.Net.Commons;
using TechTalk.SpecFlow;

namespace Allure.Examples.SpecFlow3;

[Binding]
public static class Hooks
{
    const string CATEGORIES_PATH =
        "Allure.Examples.SpecFlow3.Resources.categories.json";
    static readonly Assembly currentAssembly = Assembly.GetExecutingAssembly();

    [AfterTestRun]
    public static async Task CopyCategoriesToAllureDirectory()
    {
        using var stream =
            currentAssembly.GetManifestResourceStream(CATEGORIES_PATH);
        if (stream is null)
        {
            return;
        }

        using var reader = new StreamReader(stream);
        var directory = AllureLifecycle.Instance.AllureConfiguration.Directory;
        if (!Directory.Exists(directory))
        {
            return;
        }
        var outputPath = Path.Combine(directory, "categories.json");
        var content = await reader.ReadToEndAsync();
        await File.WriteAllTextAsync(outputPath, content, Encoding.UTF8);
    }
}
