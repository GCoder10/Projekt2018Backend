namespace CookApp.API.Models
{
    public class Recipe
    {
        public int Id { get; set; }
        public string name { get; set; }
        public string time { get; set; }
        public string lvl { get; set; }
        public string quality { get; set; }
        public string description { get; set; }
        public string rate { get; set; }

    }
}