using Microsoft.AspNetCore.Mvc;
using SimpleMart.Application.Interfaces;
using SimpleMart.Domain.Entities;

namespace SimpleMart.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CategoriesController : ControllerBase
{
    private readonly ICategoryService _service;

    public CategoriesController(ICategoryService service)
    {
        _service = service;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll() => Ok(await _service.GetAllAsync());

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var category = await _service.GetByIdAsync(id);
        return category is not null ? Ok(category) : NotFound();
    }

    [HttpPost]
    public async Task<IActionResult> Add(Category category)
    {
        await _service.AddAsync(category);
        return Ok();
    }

    [HttpPut]
    public async Task<IActionResult> Update(Category category)
    {
        await _service.UpdateAsync(category);
        return Ok();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        await _service.DeleteAsync(id);
        return Ok();
    }
}
