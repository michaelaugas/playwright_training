using Microsoft.Playwright.NUnit;

namespace Cerm.QA.Takehome;

[TestFixture]
public class B_A_CreateTaskValidWord : PageTest
{
    [Test]
    public async Task AddValidWordTitles()
    {
        Console.WriteLine("Test suite : Launching create task checks");
        Console.WriteLine("");

        var page = new AppPage(Page);
        await page.GotoAsync();

        Console.WriteLine("     Test case : Add a first valid task title word");

        var item1Added = await page.FillInTask(TestDataSet.validItem1);
        await Expect(Page).ToHaveURLAsync(SetUp.createUrl);
        Assert.That(item1Added, Is.EqualTo(true));
                
        Console.WriteLine("");
        Console.WriteLine("     Test case : Add a second valid task title word");

        var item2Added = await page.FillInTask(TestDataSet.validItem2, AppPage.CreateMethod.clickBtn);
        await Expect(page.errorAlert).Not.ToBeVisibleAsync();
        Assert.That(item2Added, Is.EqualTo(true));
    }
}

[TestFixture]
public class B_B_CreateTaskValidLongWord : PageTest
{
    [Test]
    public async Task AddValidLongWordTitle()
    {
        var page = new AppPage(Page);
        await page.GotoAsync();

        Console.WriteLine("     Test case : Add a valid long task title word");
        var item3Added = await page.FillInTask(TestDataSet.validLongItem, AppPage.CreateMethod.clickBtn);
        await Expect(page.errorAlert).Not.ToBeVisibleAsync();
        Assert.That(item3Added, Is.EqualTo(true));
    }
}

[TestFixture]
public class B_C_CreateTaskValidShortText : PageTest
{
    [Test]
    public async Task AddValidShortTextTitle()
    {
        var page = new AppPage(Page);
        await page.GotoAsync();

        Console.WriteLine("     Test case : Add a valid short task title text");
        var item4Added = await page.FillInTask(TestDataSet.validShortText, AppPage.CreateMethod.clickBtn);
        await Expect(page.errorAlert).Not.ToBeVisibleAsync();
        Assert.That(item4Added, Is.EqualTo(true));
    }
}

[TestFixture]
public class B_D_CreateTaskValidLongText : PageTest
{
    [Test]
    public async Task AddValidLongTextTitle()
    {
        var page = new AppPage(Page);
        await page.GotoAsync();

        Console.WriteLine("     Test case : Add a valid long task title text");
        var item5Added = await page.FillInTask(TestDataSet.validLongText, AppPage.CreateMethod.clickBtn);
        await Expect(page.errorAlert).Not.ToBeVisibleAsync();
        Assert.That(item5Added, Is.EqualTo(true));
    }
}

[TestFixture]
public class B_E_CreateTaskValidTrickyText : PageTest
{
    [Test]
    public async Task AddValidTrickyTextTitle()
    {
        var page = new AppPage(Page);
        await page.GotoAsync();

        Console.WriteLine("     Test case : Add a valid tricky task title text");
        var item6Added = await page.FillInTask(TestDataSet.validTrickyItem, AppPage.CreateMethod.clickBtn);
        await Expect(page.errorAlert).Not.ToBeVisibleAsync();
        Assert.That(item6Added, Is.EqualTo(true));
    }
}

[TestFixture]
public class B_F_CreateTaskInValidEmptyTitle : PageTest
{
    [Test]
    public async Task AddInValidEmptyTitle()
    {
        var page = new AppPage(Page);
        await page.GotoAsync();

        Console.WriteLine("     Test case : Add an empty task title string");
        var item7Added = await page.FillInTask(TestDataSet.invalidItem1, AppPage.CreateMethod.clickBtn);
        await Expect(page.errorAlert).ToBeVisibleAsync();
        await Expect(page.errorAlertMsg).ToHaveTextAsync("Something"); // Implement the assertion after bugfix
        Assert.That(item7Added, Is.EqualTo(false));
    }
}

[TestFixture]
public class B_F_CreateTaskInValidSpacesTitle : PageTest
{
    [Test]
    public async Task AddInValidSpacesTitle()
    {
        var page = new AppPage(Page);
        await page.GotoAsync();

        Console.WriteLine("     Test case : Add an 'only spaces' task title string");
        var item8Added = await page.FillInTask(TestDataSet.invalidItem2, AppPage.CreateMethod.clickBtn);
        await Expect(page.errorAlert).ToBeVisibleAsync();
        await Expect(page.errorAlertMsg).ToHaveTextAsync("Something"); // Implement the assertion after bugfix
        Assert.That(item8Added, Is.EqualTo(false));
    }
}