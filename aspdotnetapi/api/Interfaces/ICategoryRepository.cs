using aspdotnetapi.api.Models;

namespace aspdotnetapi.api.Interfaces
{
    public interface ICategoryRepository
    {
        ICollection<Category> GetCategories();
        bool HasCategory(int id);
        Category GetCategory(int id);
        bool Save();
        bool Create(Category category);
        bool Update(Category category);
        bool Delete(int id);
    }
}
