using BookStoreApi.Models;
using BookStoreApi.Services;
using Microsoft.AspNetCore.Mvc;

namespace BookStoreApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ShoppingListController : ControllerBase
{
    private readonly ShoppingListService _shoppinglistService;

    public ShoppingListController(ShoppingListService shoppinglistService) =>
        _shoppinglistService = shoppinglistService;

    [HttpGet]
    public async Task<List<ShoppingList>> Get()
    {
        return await _shoppinglistService.GetAsync();
    }

    [HttpGet("{id:length(24)}")]
    public async Task<ActionResult<ShoppingList>> Get(string id)
    {
        var shoppinglist = await _shoppinglistService.GetAsync(id);

        if (shoppinglist is null)
        {
            return NotFound();
        }

        return shoppinglist;
    }

    [HttpPost]
    public async Task<IActionResult> Post(ShoppingList newShoppingList)
    {
        await _shoppinglistService.CreateAsync(newShoppingList);

        return CreatedAtAction(nameof(Get), new { id = newShoppingList.Id }, newShoppingList);
    }

    [HttpPut("{id:length(24)}")]
    public async Task<IActionResult> Update(string id, ShoppingList updatedShoppingList)
    {
        var shoppinglist = await _shoppinglistService.GetAsync(id);

        if (shoppinglist is null)
        {
            return NotFound();
        }

        updatedShoppingList.Id = shoppinglist.Id;

        await _shoppinglistService.UpdateAsync(id, updatedShoppingList);

        return NoContent();
    }

    [HttpDelete("{id:length(24)}")]
    public async Task<IActionResult> Delete(string id)
    {
        var shoppinglist = await _shoppinglistService.GetAsync(id);

        if (shoppinglist is null)
        {
            return NotFound();
        }

        await _shoppinglistService.RemoveAsync(id);

        return NoContent();
    }
}