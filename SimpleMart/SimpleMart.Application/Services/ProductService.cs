using SimpleMart.Application.Interfaces;
using SimpleMart.Domain.Entities;
using SimpleMart.Domain.Interfaces;

namespace SimpleMart.Application.Services;

public class ProductService : IProductService
{
    private readonly IUnitOfWork _unitOfWork;

    public ProductService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<List<Product>> GetAllAsync() => await _unitOfWork.Products.GetAllAsync();

    public async Task<Product?> GetByIdAsync(int id) => await _unitOfWork.Products.GetByIdAsync(id);

    public async Task AddAsync(Product product)
    {
        await _unitOfWork.Products.AddAsync(product);
        await _unitOfWork.SaveChangesAsync();
    }

    public async Task UpdateAsync(Product product)
    {
        _unitOfWork.Products.Update(product);
        await _unitOfWork.SaveChangesAsync();
    }

    public async Task DeleteAsync(int id)
    {
        var product = await _unitOfWork.Products.GetByIdAsync(id);
        if (product is not null)
        {
            _unitOfWork.Products.Delete(product);
            await _unitOfWork.SaveChangesAsync();
        }
    }
}
