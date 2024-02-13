using Microsoft.Playwright.NUnit;

namespace Cerm.QA.Takehome;

[TestFixture]
public class E_A_RemoveTasks : PageTest
{
    [Test]
    public async Task RemoveTasks()
    {
        Console.WriteLine("Test suite : Launching remove tasks checks");
        Console.WriteLine("");

        var page = new AppPage(Page);
        await page.GotoAsync();

        Console.WriteLine("     Test case : Remove last task added");

        var item = AppPage.insertedItems[^1];
        await page.RemoveTask(item);

        await Expect(Page).ToHaveURLAsync(SetUp.removeUrl);

        var tasksCount = AppPage.insertedItems.Count;
        var actualItemsTitles = await page.GetTableBodyRowsTitles();

        for (var i = 0; i < tasksCount; i++) {
            Assert.That(actualItemsTitles[i], Is.EqualTo(AppPage.insertedItems[i].Title));
        }

        Console.WriteLine("");
        Console.WriteLine("     Test case : Remove all remaining tasks");

        tasksCount = AppPage.insertedItems.Count;
        for (var i = 0; i < tasksCount; i++) {
            item = AppPage.insertedItems[0];
            await page.RemoveTask(item);
        }

        Assert.That(await page.tasksTableBodyRows.CountAsync(), Is.EqualTo(0));  
        await Expect(page.tasksTableBody).ToBeEmptyAsync();
    }
}