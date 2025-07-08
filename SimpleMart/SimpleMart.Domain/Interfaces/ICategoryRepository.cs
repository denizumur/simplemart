using SimpleMart.Domain.Entities;

namespace SimpleMart.Domain.Interfaces;

public interface ICategoryRepository
{
    Task<Category?> GetByIdAsync(int id);
    Task<List<Category>> GetAllAsync();
    Task AddAsync(Category category);
    void Update(Category category);
    void Delete(Category category);
}
