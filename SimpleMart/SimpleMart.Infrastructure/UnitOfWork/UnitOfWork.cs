using SimpleMart.Domain.Interfaces;
using SimpleMart.Infrastructure.Context;
using SimpleMart.Infrastructure.Repositories;

namespace SimpleMart.Infrastructure.UnitOfWork;

public class UnitOfWork : IUnitOfWork
{
    private readonly AppDbContext _context;

    public IProductRepository Products { get; }
    public ICategoryRepository Categories { get; }

    public UnitOfWork(AppDbContext context)
    {
        _context = context;
        Products = new ProductRepository(context);
        Categories = new CategoryRepository(context);
    }

    public async Task<int> SaveChangesAsync() => await _context.SaveChangesAsync();
}
