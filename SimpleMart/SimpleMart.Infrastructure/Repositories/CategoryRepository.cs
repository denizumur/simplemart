using Microsoft.EntityFrameworkCore;
using SimpleMart.Domain.Entities;
using SimpleMart.Domain.Interfaces;
using SimpleMart.Infrastructure.Context;

namespace SimpleMart.Infrastructure.Repositories;

public class CategoryRepository : ICategoryRepository
{
    private readonly AppDbContext _context;
    public CategoryRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task AddAsync(Category category) => await _context.Categories.AddAsync(category);

    public void Delete(Category category) => _context.Categories.Remove(category);

    public async Task<List<Category>> GetAllAsync() => await _context.Categories.Include(c => c.Products).ToListAsync();

    public async Task<Category?> GetByIdAsync(int id) => await _context.Categories.Include(c => c.Products).FirstOrDefaultAsync(c => c.Id == id);

    public void Update(Category category) => _context.Categories.Update(category);
}
