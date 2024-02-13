namespace Cerm.QA.Takehome;

public class SetUp {
    // public const string baseUrl = "http://localhost:8080/"; // to be used locally
    public const string baseUrl = "http://todo.web-app:8080/"; // to be used via docker-compose
    public const string createUrl = baseUrl + "?handler=AddItem";
    public const string setCompleteUrl = baseUrl + "?handler=complete";
    public const string setUncompleteUrl = baseUrl + "?handler=uncomplete";
    public const string removeUrl = baseUrl + "?handler=delete";
}

public struct Item(string title, AppPage.TaskStatus complete = AppPage.TaskStatus.uncomplete, bool valid = true)
{
    public string Title { get; set; } = title;
    public AppPage.TaskStatus Complete { get; set; } = complete;
    public bool Valid { get; set; } = valid;
}

public static class TestDataSet
{
    public static readonly Item validItem1 = new("item1");
    public static readonly Item validItem2 = new("item2");
    public static readonly Item validLongItem = new("Item5%20%20to%20check%20a%20very%20long%20text%20that%20will%20surely%20be%20more%20than%20the%20maxwidth%20admitted%20by%20the%20css%20definition%20of%20container%20class.");
    public static readonly Item validShortText = new("Item4 - to check some text");
    public static readonly Item validLongText = new("Item5 - to check a very long text that will surely be more than the max-width admitted by the css definition of container class");
    public static readonly Item validTrickyItem = new("   Item6   ");
    public static readonly Item invalidItem1 = new("", AppPage.TaskStatus.uncomplete, false);
    public static readonly Item invalidItem2 = new("   ", AppPage.TaskStatus.uncomplete, false);
}