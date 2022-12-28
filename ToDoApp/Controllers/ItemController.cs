using Microsoft.AspNetCore.Mvc;
using ToDoApp.Models;
using ToDoApp.Models.ViewModels;
using ToDoApp.Repository;

namespace ToDoApp.Controllers;

public class ItemController : Controller
{
    private readonly IToDoRepository _repo;

    public ItemController(IToDoRepository repo)
    {
        _repo = repo;
    }

    [HttpGet]
    public IActionResult List(string searchTerm)
    {
        searchTerm ??= "";
        var items = _repo.GetItemByName(searchTerm);
        var model = new ItemListViewModel { Items = items };
        return View(model);
    }

    [HttpGet]
    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Create(ToDoItem item)
    {
        _repo.CreateNewItem(item);
        _repo.Commit();
        return RedirectToAction("List");
    }

    [HttpGet]
    public IActionResult Edit(int id)
    {
        var model = _repo.GetById(id);
        if (model is null)
        {
            return View();
        }
        return View(model);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Edit(ToDoItem item)
    {
        _repo.Update(item);
        _repo.Commit();
        return RedirectToAction("List");
    }

    [HttpGet]
    public IActionResult Delete(int id)
    {
        var model = _repo.GetById(id);
        if (model is null)
        {
            return View();
        }

        return View(model);
    }

    [HttpPost]
    public IActionResult Delete(ToDoItem item)
    {
        _repo.Delete(item.ItemId);
        _repo.Commit();
        return RedirectToAction("List");
    }

}