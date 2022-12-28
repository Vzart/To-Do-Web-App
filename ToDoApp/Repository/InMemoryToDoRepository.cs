using ToDoApp.Models;

namespace ToDoApp.Repository;

public class InMemoryToDoRepository : IToDoRepository
{
    private List<ToDoItem> _items;

    public InMemoryToDoRepository()
    {
        _items = new List<ToDoItem>()
        {
            new ToDoItem()
                { CompletionStatus = true, Description = "abc123", DueDate = DateTime.Now.ToShortDateString(), Name = "Khoa", ItemId = 1 },
            new ToDoItem()
                { CompletionStatus = false, Description = "chien", DueDate = DateTime.Now.ToShortDateString(), Name = "CHien", ItemId = 2 },
        };
    }

    public IEnumerable<ToDoItem> GetItemByName(string name)
    {
        if (string.IsNullOrEmpty(name)) return _items;
        return _items.Where(x => x.Name.ToLower().Contains(name.ToLower()));
    }

    public ToDoItem GetById(int id)
    {
        return _items.SingleOrDefault(x => x.ItemId == id);
    }

    public void CreateNewItem(ToDoItem newItem)
    {
        newItem.ItemId = _items.Max(x => x.ItemId) + 1;

        _items.Add(newItem);
    }

    public void Update(ToDoItem updateItem)
    {
        var item = GetById(updateItem.ItemId);

        item.Name = updateItem.Name;
        item.Description = updateItem.Description;
        item.DueDate = updateItem.DueDate;
        item.CompletionStatus = updateItem.CompletionStatus;
    }

    public void Delete(int id)
    {
        var item = GetById(id);
        if (item is not null)
        {
            _items.Remove(item);
        }
    }

    public int Commit()
    {
        return 0;
    }
}