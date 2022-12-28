using ToDoApp.Models;

namespace ToDoApp.Repository;

public interface IToDoRepository
{
    IEnumerable<ToDoItem> GetItemByName(string name);
    ToDoItem GetById(int id);
    void CreateNewItem(ToDoItem newItem);
    void Update(ToDoItem updateItem);
    void Delete(int id);
    int Commit();
}