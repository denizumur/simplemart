using SimpleMart.Application.Interfaces;
using SimpleMart.Domain.Entities;
using SimpleMart.Domain.Interfaces;

namespace SimpleMart.Application.Services;

public class CategoryService : ICategoryService
{
    private readonly IUnitOfWork _unitOfWork;

    public CategoryService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<List<Category>> GetAllAsync() => await _unitOfWork.Categories.GetAllAsync();

    public async Task<Category?> GetByIdAsync(int id) => await _unitOfWork.Categories.GetByIdAsync(id);

    public async Task AddAsync(Category category)
    {
        await _unitOfWork.Categories.AddAsync(category);
        await _unitOfWork.SaveChangesAsync();
    }

    public async Task UpdateAsync(Category category)
    {
        _unitOfWork.Categories.Update(category);
        await _unitOfWork.SaveChangesAsync();
    }

    public async Task DeleteAsync(int id)
    {
        var category = await _unitOfWork.Categories.GetByIdAsync(id);
        if (category is not null)
        {
            _unitOfWork.Categories.Delete(category);
            await _unitOfWork.SaveChangesAsync();
        }
    }
}
