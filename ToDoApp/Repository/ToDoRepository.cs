using Microsoft.EntityFrameworkCore;
using ToDoApp.Models;

namespace ToDoApp.Repository;

public class ToDoRepository : IToDoRepository
{
    private readonly AppDbContext _db;

    public ToDoRepository(AppDbContext items)
    {
        _db = items;
    }
    
    public IEnumerable<ToDoItem> GetItemByName(string name)
    {
        if (string.IsNullOrEmpty(name)) return _db.ToDoItems;
        return _db.ToDoItems.Where(x => x.Name.ToLower().Contains(name.ToLower()));
    }

    public ToDoItem GetById(int id)
    {
        return _db.ToDoItems.Find(id);
    }

    public void CreateNewItem(ToDoItem newItem)
    {
        _db.Add(newItem);
    }

    public void Update(ToDoItem updateItem)
    {
        var entry = _db.Entry(updateItem);
        entry.State = EntityState.Modified;
    }

    public void Delete(int id)
    {
        var item = GetById(id);
        if (item is not null)
        {
            _db.Remove(item);
        }
    }
    public int Commit()
    {
        return _db.SaveChanges();
    }
}