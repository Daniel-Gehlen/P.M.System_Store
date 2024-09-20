namespace WebApp.Models
{
    public class Category
    {
        public int Number { get; set; }
        public string Name { get; set; } = string.Empty; // Inicializar com uma string vazia
        public List<Product> Products { get; set; } = new List<Product>(); // Inicializar a lista vazia
    }
}
