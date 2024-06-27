using aspdotnetapi.api.Data;
using aspdotnetapi.api.Models;
using System.Xml.Linq;

namespace aspdotnetapi
{
    public class Seed
    {
        private readonly DataContext dataContext;
        public Seed(DataContext context)
        {
            this.dataContext = context;
        }

        public void SeedDataContext()
        {
            if (!dataContext.Categories.Any())
            {
                var categories = new List<Category>()
                {
                    new Category()
                    {
                        Name = "Drink"
                    }
                };
                dataContext.Categories.AddRange(categories);
                dataContext.SaveChanges();
            };
        }
    }
}
