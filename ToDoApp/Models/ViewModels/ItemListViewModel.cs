using Microsoft.AspNetCore.Mvc;

namespace ToDoApp.Models.ViewModels;

public class ItemListViewModel
{
    public IEnumerable<ToDoItem> Items { get; set; }
    [BindProperty]
    public string? SearchTerm { get; set; } = default;
}