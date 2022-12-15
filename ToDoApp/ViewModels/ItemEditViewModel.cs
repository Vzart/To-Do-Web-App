using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
using ToDoApp.Models;

namespace ToDoApp.ViewModels;


public class ItemEditViewModel
{
    [BindProperty] public ToDoItem Item { get; set; }
    public IEnumerable<ToDoItem> ListItems { get; set; }
    [BindProperty(SupportsGet = true)] public string SearchTerm { get; set; } = ""; 
}