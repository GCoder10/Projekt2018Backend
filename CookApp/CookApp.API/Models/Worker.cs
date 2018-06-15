using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace CookApp.API.Models
{
    public class Worker
    {
        public ObjectId id { get; set; }
        public string surname { get; set; }
        public string name { get; set; }
        public string city { get; set; }
        public string email { get; set; }
        public string pass { get; set; }
        public long pesel { get; set; }
        public string street { get; set; }
    }
}