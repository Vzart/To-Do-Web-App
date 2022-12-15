using ToDoApp.Models;

namespace ToDoApp.Repository;

public interface IToDoRepository
{
    IEnumerable<ToDoItem> GetItemByName(string name);
    ToDoItem GetById(int id);
    ToDoItem CreateNewItem(ToDoItem newItem);
    ToDoItem Update(ToDoItem updateItem);
    int Commit();
}