using WebApp.Models;

namespace WebApp.Services
{
    public static class CategoryService
    {
        public static List<Category> GetAllCategories() => DataStore.Categories;

        public static void AddCategory(string name)
        {
            Category category = new Category
            {
                Number = DataStore.Categories.Count + 1,
                Name = name
            };
            DataStore.Categories.Add(category);
        }

        public static bool RemoveCategory(int categoryNumber)
        {
            var category = DataStore.Categories.FirstOrDefault(c => c.Number == categoryNumber);
            if (category != null)
            {
                DataStore.Categories.Remove(category);
                return true;
            }
            return false;
        }
    }
}
