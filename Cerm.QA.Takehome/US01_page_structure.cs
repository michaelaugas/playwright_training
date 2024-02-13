using Microsoft.Playwright.NUnit;

namespace Cerm.QA.Takehome;

[TestFixture]
public class A_A_PageHeaderChecks : PageTest
{
    [Test]
    public async Task PageHeaderIsDisplayedAsExpected()
    {
        Console.WriteLine("Test suite : Launching page structure checks");
        Console.WriteLine("");
        Console.WriteLine("     Test case : page header check");

        var page = new AppPage(Page);
        await page.GotoAsync();
        await Expect(Page).ToHaveURLAsync(SetUp.baseUrl);

        await Expect(page.header).ToBeVisibleAsync();
        await Expect(page.homeBtn).ToBeVisibleAsync();
        await Expect(page.toggleMenuBtn).Not.ToBeVisibleAsync();
    }
}

[TestFixture]
public class A_B_PageTitleChecks : PageTest
{
    [Test]
    public async Task PageTitleIsDisplayedAsExpected()
    {
        Console.WriteLine("     Test case : page title check");

        var page = new AppPage(Page);
        await page.GotoAsync();

        await Expect(page.mainTitle).ToBeVisibleAsync();
    }
}

[TestFixture]
public class A_C_PageSubTitleChecks : PageTest
{
    [Test]
    public async Task PageSubTitleIsDisplayedAsExpected()
    {
        Console.WriteLine("     Test case : page subtitle check");

        var page = new AppPage(Page);
        await page.GotoAsync();

        await Expect(page.subTitle).ToBeVisibleAsync();
    }
}

[TestFixture]
public class A_D_CreateTaskInputChecks : PageTest
{
    [Test]
    public async Task CreateTaskInputIsDisplayedAsExpected()
    {
        Console.WriteLine("     Test case : create task input check");

        var page = new AppPage(Page);
        await page.GotoAsync();

        await Expect(page.taskTitleInput).ToBeVisibleAsync();
    }
}

[TestFixture]
public class A_E_CreateTaskBtnChecks : PageTest
{
    [Test]
    public async Task CreateTaskBtnIsDisplayedAsExpected()
    {
        Console.WriteLine("     Test case : create button check");

        var page = new AppPage(Page);
        await page.GotoAsync();

        await Expect(page.createBtn).ToBeVisibleAsync();
    }
}

[TestFixture]
public class A_F_TasksTableTitleChecks : PageTest
{
    [Test]
    public async Task TasksTableTitleIsDisplayedAsExpected()
    {
        Console.WriteLine("     Test case : tasks table title check");

        var page = new AppPage(Page);
        await page.GotoAsync();

        await Expect(page.tasksTableTitle).ToBeVisibleAsync();
    }
}

[TestFixture]
public class A_G_TasksTableChecks : PageTest
{
    [Test]
    public async Task TasksTableIsDisplayedAsExpected()
    {
        Console.WriteLine("     Test case : task table check");

        var page = new AppPage(Page);
        await page.GotoAsync();

        await Expect(page.tasksTable).ToBeVisibleAsync();
    }
}

[TestFixture]
public class A_H_TasksTableHeadersChecks : PageTest
{
    [Test]
    public async Task TasksTableHeadersIsDisplayedAsExpected()
    {
        Console.WriteLine("     Test case : task table headers check");

        var page = new AppPage(Page);
        await page.GotoAsync();

        await Expect(page.tasksTableHeaderRow).ToBeVisibleAsync();
        await Expect(page.tasksTableHeaderTitleCell).ToBeVisibleAsync();
        await Expect(page.tasksTableHeaderDoneCell).ToBeVisibleAsync();
        await Expect(page.tasksTableHeaderActionsCell).ToBeVisibleAsync();
    }
}

[TestFixture]
public class A_I_TasksTableBodyChecks : PageTest
{
    [Test]
    public async Task TasksTableBodyIsDisplayedAsExpected()
    {
        Console.WriteLine("     Test case : Check table body");

        var page = new AppPage(Page);
        await page.GotoAsync();

        await Expect(page.tasksTableBody).ToBeEmptyAsync();
    }
}

[TestFixture]
public class A_J_PageFooterChecks : PageTest
{
    [Test]
    public async Task PageFooterIsDisplayedAsExpected()
    {
        Console.WriteLine("     Test case : Check page footer");

        var page = new AppPage(Page);
        await page.GotoAsync();

        await Expect(page.footer).ToBeVisibleAsync();
        await Expect(page.footerCopyright).ToBeVisibleAsync();
    }
}