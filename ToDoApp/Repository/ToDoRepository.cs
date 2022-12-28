using Microsoft.EntityFrameworkCore;
using ToDoApp.Models;

namespace ToDoApp.Repository;

public class ToDoRepository : IToDoRepository
{
    private readonly AppDbContext _items;

    public ToDoRepository(AppDbContext items)
    {
        _items = items;
    }
    
    public IEnumerable<ToDoItem> GetItemByName(string name)
    {
        var query = from td in _items.ToDoItems
            where td.Name.StartsWith(name) || string.IsNullOrEmpty(name)
            orderby td.Name
            select td;

        return query;
    }

    public ToDoItem GetById(int id)
    {
        return _items.ToDoItems.Find(id);
    }

    public void CreateNewItem(ToDoItem newItem)
    {
        _items.Add(newItem);
    }

    public void Update(ToDoItem updateItem)
    {
        throw new NotImplementedException();
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
        return _items.SaveChanges();
    }
}