using System.Text.Json;
using WebApp.Models;

namespace WebApp.Services
{
    public static class DataStore
    {
        private static string jsonFileName = "data.json";
        public static List<Category> Categories { get; set; } = new List<Category>();

        public static void LoadData()
        {
            if (File.Exists(jsonFileName))
            {
                string json = File.ReadAllText(jsonFileName);
                Categories = JsonSerializer.Deserialize<List<Category>>(json) ?? new List<Category>();
            }
        }

        public static void SaveData()
        {
            string json = JsonSerializer.Serialize(Categories, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(jsonFileName, json);
        }
    }
}
