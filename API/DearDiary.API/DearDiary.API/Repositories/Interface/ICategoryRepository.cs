using DearDiary.API.Models.Domain;

namespace DearDiary.API.Repositories.Interface
{
    public interface ICategoryRepository
    {
        Task<Category> CreateAsync(Category category);
    }
}
