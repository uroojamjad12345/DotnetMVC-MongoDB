using MongoDB.Bson.Serialization.Attributes;

namespace MongoDBCRUD.Models
{
    public class MobileDeviceEntity
    {
        [BsonId]
        [BsonRepresentation(MongoDB.Bson.BsonType.ObjectId)]
        public string _id { get; set; }
        public string Name { get; set; }
        public string Company { get; set; }
        public string Color { get; set; }
        public string Cost { get; set; }

    }
}
