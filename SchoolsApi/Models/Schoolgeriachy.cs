using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;


namespace schoolsapi.models
{
    public class schoolgeriachy
    {
        [BsonId]
        public ObjectId Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string Document { get; set; } = string.Empty;
        public int Age { get; set; }
        public string Address { get; set; } = string.Empty;
        public string Phone { get; set; } = string.Empty;
        public Position Position { get; set; } 

    }
}
