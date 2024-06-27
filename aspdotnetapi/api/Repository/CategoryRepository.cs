using aspdotnetapi.api.Data;
using aspdotnetapi.api.Interfaces;
using aspdotnetapi.api.Models;

namespace aspdotnetapi.api.Repository
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly DataContext context;
        public CategoryRepository(DataContext context)
        {
            this.context = context;
        }
        public ICollection<Category> GetCategories()
        {
            return context.Categories.OrderBy(p => p.Id).ToList();
        }

        public bool HasCategory(int id)
        {
            return context.Categories.Any(c => c.Id == id);
        }

        public Category GetCategory(int id)
        {
            return context.Categories.Where(c => c.Id == id).FirstOrDefault();
        }

        public bool Save()
        {
            var saved = context.SaveChanges();
            return saved > 0 ? true : false;
        }

        public bool Create(Category category)
        {
            context.Add(category);
            return Save();
        }

        public bool Update(Category category)
        {
            context.Update(category);
            return Save();
        }

        public bool Delete(int id)
        {
            Category category = new Category();
            category.Id = id;   
            context.Remove(category);
            return Save();
        }
    }
}
