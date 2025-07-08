using System.Threading.Tasks;

namespace SimpleMart.Domain.Interfaces
{
    public interface IUnitOfWork
    {
        IProductRepository Products { get; }
        ICategoryRepository Categories { get; }

        Task<int> SaveChangesAsync();
    }
}
