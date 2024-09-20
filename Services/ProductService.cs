using WebApp.Models;

namespace WebApp.Services
{
    public static class ProductService
    {
        public static bool AddProduct(int categoryNumber, string productName, decimal productPrice)
        {
            var category = DataStore.Categories.FirstOrDefault(c => c.Number == categoryNumber);
            if (category != null)
            {
                category.Products.Add(new Product
                {
                    Number = category.Products.Count + 1,
                    Name = productName,
                    Price = productPrice
                });
                return true;
            }
            return false;
        }

        public static bool RemoveProduct(int categoryNumber, int productNumber)
        {
            var category = DataStore.Categories.FirstOrDefault(c => c.Number == categoryNumber);
            if (category != null)
            {
                var product = category.Products.FirstOrDefault(p => p.Number == productNumber);
                if (product != null)
                {
                    category.Products.Remove(product);
                    return true;
                }
            }
            return false;
        }

        public static bool ModifyProductPrice(int categoryNumber, int productNumber, decimal newPrice)
        {
            var category = DataStore.Categories.FirstOrDefault(c => c.Number == categoryNumber);
            if (category != null)
            {
                var product = category.Products.FirstOrDefault(p => p.Number == productNumber);
                if (product != null)
                {
                    product.ChangePrice(newPrice);
                    return true;
                }
            }
            return false;
        }
    }
}
