using Microsoft.AspNetCore.Mvc;
using SimpleMart.Application.Interfaces;
using SimpleMart.Domain.Entities;

namespace SimpleMart.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProductsController : ControllerBase
{
    private readonly IProductService _service;

    public ProductsController(IProductService service)
    {
        _service = service;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll() => Ok(await _service.GetAllAsync());

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var product = await _service.GetByIdAsync(id);
        return product is not null ? Ok(product) : NotFound();
    }

    [HttpPost]
    public async Task<IActionResult> Add(Product product)
    {
        await _service.AddAsync(product);
        return Ok();
    }

    [HttpPut]
    public async Task<IActionResult> Update(Product product)
    {
        await _service.UpdateAsync(product);
        return Ok();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        await _service.DeleteAsync(id);
        return Ok();
    }
}
