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

    public ToDoItem CreateNewItem(ToDoItem newItem)
    {
        _items.Add(newItem);
        return newItem;
    }

    public ToDoItem Update(ToDoItem updateItem)
    {
        var entity = _items.Attach(updateItem);
        entity.State = EntityState.Modified;
        return updateItem;
    }

    public int Commit()
    {
        return _items.SaveChanges();
    }
}