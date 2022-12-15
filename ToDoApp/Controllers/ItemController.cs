using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ToDoApp.Repository;
using ToDoApp.ViewModels;

namespace ToDoApp.Controllers;

public class ItemController : Controller
{
    private readonly IToDoRepository _items;

    public ItemController(IToDoRepository items)
    {
        _items = items;
    }

    [HttpGet]
    public IActionResult List()
    {
        var itemViewModel = new ItemEditViewModel();
        itemViewModel.ListItems = _items.GetItemByName(itemViewModel.SearchTerm);
        return View(itemViewModel);
    }

    [HttpGet]
    public IActionResult Edit()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Edit(ItemEditViewModel editViewModel)
    {
        if (!ModelState.IsValid)
        {
            return View();
        }

        if (editViewModel.Item.ItemId > 0)
        {
            _items.Update(editViewModel.Item);
        }
        else
        {
            _items.CreateNewItem(editViewModel.Item);
        }

        _items.Commit();
        return RedirectToPage("./List");
    }
}