using Microsoft.Playwright.NUnit;

namespace Cerm.QA.Takehome;

[TestFixture]
public class C_A_TasksTableDisplay : PageTest
{
    [Test]
    public async Task TasksTableDisplay()
    {
        Console.WriteLine("Test suite : Launching view table tasks checks");
        Console.WriteLine("");

        var page = new AppPage(Page);
        await page.GotoAsync();

        Console.WriteLine("     Test case : Check tasks table is displayedwith correct width");
        var hasCorrectWidth = await page.IsInsidePageWidthLimmit(page.tasksTable);

        Assert.That(hasCorrectWidth, Is.EqualTo(true));
    }
}

[TestFixture]
public class C_B_ViewCreatedTasksStatus : PageTest
{
    [Test]
    public async Task ViewCreatedTasksStatus()
    {
        var page = new AppPage(Page);
        await page.GotoAsync();

        Console.WriteLine("     Test case : Check tasks table has the expected nr of tasks created");
        Assert.That(await page.tasksTableBodyRows.CountAsync(), Is.EqualTo(AppPage.insertedItems.Count));

        Console.WriteLine("");
        Console.WriteLine("     Test case : Check all tasks are unmarked as done");

        foreach (var item in AppPage.insertedItems)
        {
            var actualStatus = await page.GetActualItemStatus(item);
            Assert.That(actualStatus, Is.EqualTo(AppPage.TaskStatus.uncomplete));
        }
    }
}

[TestFixture]
public class C_C_ViewCreatedTasksOrder : PageTest
{
    [Test]
    public async Task ViewCreatedTasksOrder()
    {
        var page = new AppPage(Page);
        await page.GotoAsync();

        Console.WriteLine("     Test case : Check all tasks are sorted correctly (from first task created to last)");

        var tasksCount = AppPage.insertedItems.Count;
        var actualItemsTitles = await page.GetTableBodyRowsTitles();

        for (var i = 0; i < tasksCount; i++) {
            Assert.That(actualItemsTitles[i], Is.EqualTo(AppPage.insertedItems[i].Title));
        }
    }
}