using Microsoft.EntityFrameworkCore;
using SimpleMart.Domain.Entities;
using SimpleMart.Domain.Interfaces;
using SimpleMart.Infrastructure.Context;

namespace SimpleMart.Infrastructure.Repositories;

public class ProductRepository : IProductRepository
{
    private readonly AppDbContext _context;
    public ProductRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task AddAsync(Product product) => await _context.Products.AddAsync(product);

    public void Delete(Product product) => _context.Products.Remove(product);

    public async Task<List<Product>> GetAllAsync() => await _context.Products.Include(p => p.Category).ToListAsync();

    public async Task<Product?> GetByIdAsync(int id) => await _context.Products.Include(p => p.Category).FirstOrDefaultAsync(p => p.Id == id);

    public void Update(Product product) => _context.Products.Update(product);
}
