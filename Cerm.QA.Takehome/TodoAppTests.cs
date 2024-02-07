using Microsoft.Playwright.NUnit;

namespace Cerm.QA.Takehome;


[TestFixture]
public class Tests: PageTest
{
    private const string _baseUrl = "http://localhost:8080";
    
    [Test]
    public async Task Page_Loads()
    {
        await Page.GotoAsync(_baseUrl);
        await Expect(Page.GetByText("Welcome to Todo")).ToBeVisibleAsync();
    }
}