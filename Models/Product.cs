namespace WebApp.Models
{
    public class Product
    {
        public int Number { get; set; }
        public string Name { get; set; } = string.Empty; // Inicializar com uma string vazia
        public decimal Price { get; set; }

        public void ChangePrice(decimal newPrice)
        {
            Price = newPrice;
        }
    }
}
