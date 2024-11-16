using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
namespace Conservation.WepAPI.Model
{
    public class Conservations { 

        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        public List<int> UserIds { get; set; }
        [BsonRepresentation(BsonType.DateTime)]
        public DateTime CreatedTime { get; set; }
        // public virtual ICollection<User> Members { get; set; }
        //public Conservation()
        //{
        //    Members = new HashSet<User>();
        //}

    }
}
