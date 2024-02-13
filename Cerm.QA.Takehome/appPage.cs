using Microsoft.Playwright;

namespace Cerm.QA.Takehome;

public class AppPage
{
  private readonly IPage _page;
  public readonly ILocator header;
  public readonly ILocator homeBtn;
  public readonly ILocator toggleMenuBtn;
  public readonly ILocator mainTitle;
  public readonly ILocator subTitle;
  public readonly ILocator taskTitleInput;
  public readonly ILocator createBtn;
  public readonly ILocator errorAlert;
  public readonly ILocator errorAlertMsg;
  public readonly ILocator tasksTableTitle;
  public readonly ILocator tasksTable;
  public readonly ILocator tasksTableHeader;
  public readonly ILocator tasksTableHeaderRow;
  public readonly ILocator tasksTableHeaderTitleCell;
  public readonly ILocator tasksTableHeaderDoneCell;
  public readonly ILocator tasksTableHeaderActionsCell;
  public readonly ILocator tasksTableBody;
  public readonly ILocator tasksTableBodyRows;
  public readonly ILocator footer;
  public readonly ILocator footerCopyright;
  public static readonly  List<Item> insertedItems = [];

  public enum TaskStatus
  {
    complete,
    uncomplete
  }

  public enum CreateMethod
  {
    clickBtn,
    pressEnter
  }

  private readonly string completeIcon = "✅";
  private readonly string uncompleteIcon = "❌";

  private readonly string removeIcon = "🗑️";

  public AppPage(IPage page)
  {
    _page = page;

    // header section
    header = _page.GetByRole(AriaRole.Navigation);
    homeBtn = header.GetByRole(AriaRole.Link, new() { Name = "Todo.Web" });
    toggleMenuBtn = header.GetByLabel("Toggle navigation");

    // create task section
    mainTitle = _page.GetByRole(AriaRole.Heading, new() { Name = "Welcome to Todo" });
    subTitle = _page.GetByText("Get started by creating a new");
    taskTitleInput = _page.GetByRole(AriaRole.Textbox);
    createBtn = _page.GetByRole(AriaRole.Button, new() { Name = "Create!" });
    errorAlert = _page.GetByRole(AriaRole.Alert);
    errorAlertMsg = errorAlert.Locator("css=p");

    // view tasks section
    tasksTableTitle = _page.GetByRole(AriaRole.Heading, new() { Name = "Tasks" });
    tasksTable = _page.Locator("css=table");

    tasksTableHeader = tasksTable.Locator("css=thead");
    tasksTableHeaderRow = tasksTableHeader.Locator("css=tr");
    tasksTableHeaderTitleCell = tasksTableHeaderRow.GetByRole(AriaRole.Cell, new() { Name = "Title" });
    tasksTableHeaderDoneCell = tasksTableHeaderRow.GetByRole(AriaRole.Cell, new() { Name = "Done?" });
    tasksTableHeaderActionsCell = tasksTableHeaderRow.GetByRole(AriaRole.Cell, new() { Name = "Actions" });

    tasksTableBody = tasksTable.Locator("css=tbody");
    tasksTableBodyRows = tasksTableBody.Locator("css=tr");

    // footer section
    footer = _page.GetByRole(AriaRole.Contentinfo);
    footerCopyright = footer.GetByText("© 2024 - Todo.Web");
  }

  public async Task GotoAsync()
  {
    await _page.GotoAsync(SetUp.baseUrl);
  }

  public async Task<List<string>> GetTableBodyRowsTitles() {
    List<string> rowsItemsTitles = [];
    var rowCount = await tasksTableBodyRows.CountAsync();

    for (var i = 0; i < rowCount; i++) {
      var title = await tasksTableBodyRows.Nth(i).Locator("css=td:nth-child(1)").InnerTextAsync();
      rowsItemsTitles.Add(title);
    }

    return rowsItemsTitles;
  }

  public ILocator GetTableBodyRow(Item item)
  {
    var row = tasksTableBodyRows.Filter(new() { Has = _page.GetByRole(AriaRole.Cell, new() { Name = item.Title }) });
    return row;
  }

  public async Task RemoveTask(Item item)
  {
    await GetTableBodyRow(item).GetByText(removeIcon).ClickAsync();
    insertedItems.Remove(item);
  }

  public ILocator GetStatusBtn(Item item)
  {
    return GetTableBodyRow(item).Locator("css=td:nth-child(2) button");
  }

  public async Task<string> GetItemIconStatus(Item item)
  {
    return await GetStatusBtn(item).InnerTextAsync();
  }

  public async Task<TaskStatus> GetActualItemStatus(Item item)
  {
    var itemIconStatus = await GetItemIconStatus(item);
    if (itemIconStatus == uncompleteIcon)
    {
      return TaskStatus.uncomplete;
    }
    else if (itemIconStatus == completeIcon)
    {
      return TaskStatus.complete;
    }
    else
    {
      throw new InvalidOperationException("Problem with the status icon displayed by the app");
    }
  }

  public async Task SetTaskStatus(Item item, TaskStatus status)
  {
    var actualStatus = await GetActualItemStatus(item);
    if (actualStatus != status) {
      await GetStatusBtn(item).ClickAsync();
      var itemIndex = insertedItems.FindIndex(x => x.Title == item.Title);
      Item tempItem = insertedItems[itemIndex];
      tempItem.Complete = status;
      insertedItems[itemIndex] = tempItem;
    }
  }

  public async Task<bool> FillInTask(Item item, CreateMethod method = CreateMethod.pressEnter)
  {
    
        var itemTitle = item.Title;
        await taskTitleInput.FillAsync(itemTitle);
        if (method == CreateMethod.clickBtn) {
        await createBtn.ClickAsync();
        } else {
          await taskTitleInput.PressAsync("Enter");
        }

        var taskIsCreated = await GetTableBodyRow(item).IsVisibleAsync();
        if (taskIsCreated) insertedItems.Add(item);

        return taskIsCreated;
  }

  public PageViewportSizeResult GetViewportSize() {
    var viewportSize = _page.ViewportSize;

    return viewportSize;
  }

  public async Task<int> GetElementWidth(ILocator element) {
    var box = await element.BoundingBoxAsync();

    return (int)Math.Floor(box.Width);
  }

  public async Task<bool> IsInsidePageWidthLimmit(ILocator element) {
        var viewportWidth = GetViewportSize().Width;

        int containerMaxWidth;
        if (viewportWidth >= 1400)
        {
            containerMaxWidth = 1320;
        }
        else if (viewportWidth >= 1200 && viewportWidth < 1400)
        {
            containerMaxWidth = 1140;
        }
        else if (viewportWidth >= 992 && viewportWidth < 1200)
        {
            containerMaxWidth = 960;
        }
        else if (viewportWidth >= 768 && viewportWidth < 992)
        {
            containerMaxWidth = 720;
        }
        else if (viewportWidth >= 576 && viewportWidth < 768)
        {
            containerMaxWidth = 540;
        }
        else
        {
            containerMaxWidth = viewportWidth;
        }

        var elementWidth = await GetElementWidth(element);

    return elementWidth <= containerMaxWidth;
  }
}