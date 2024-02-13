using Microsoft.Playwright.NUnit;

namespace Cerm.QA.Takehome;

[TestFixture]
public class D_A_SetTaskStatusToMarkedAndUnmarked : PageTest
{
    [Test]
    public async Task SetTaskStatusToMarkedAndUnmarked()
    {
        Console.WriteLine("Test suite : Launching mark/unmark tasks as done checks");
        Console.WriteLine("");

        var page = new AppPage(Page);
        await page.GotoAsync();

        Console.WriteLine("     Test case : Check first task marked as done");

        var item = AppPage.insertedItems[0];
        await page.SetTaskStatus(item, AppPage.TaskStatus.complete);

        await Expect(Page).ToHaveURLAsync(SetUp.setCompleteUrl);

        var actualStatus = await page.GetActualItemStatus(item);
        Assert.That(actualStatus, Is.EqualTo(AppPage.TaskStatus.complete));

        Console.WriteLine("");
        Console.WriteLine("     Test case : Check first task unmarked as done");
        await page.SetTaskStatus(item, AppPage.TaskStatus.uncomplete);

        await Expect(Page).ToHaveURLAsync(SetUp.setUncompleteUrl);

        actualStatus = await page.GetActualItemStatus(item);
        Assert.That(actualStatus, Is.EqualTo(AppPage.TaskStatus.uncomplete));

        await page.SetTaskStatus(item, AppPage.TaskStatus.complete);
    }
}