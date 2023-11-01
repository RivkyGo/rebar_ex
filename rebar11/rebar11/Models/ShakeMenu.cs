using System;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace rebar11.Models
{
    [BsonIgnoreExtraElements]
    public class ShakeMenu
    {
        [BsonId]
        [BsonRepresentation(BsonType.String)]
        public Guid ShakeID { get; set; }

        [BsonElement("ShakeName")]
        public string ShakeName { get; set; }

        [BsonElement("ShakeDescription")]
        public string ShakeDescription { get; set; }

        [BsonElement("ShakeSizeL")]
        public double ShakeSizeL { get; set; }

        [BsonElement("ShakeSizeM")]
        public double ShakeSizeM { get; set; }

        [BsonElement("ShakeSizeS")]
        public double ShakeSizeS { get; set; }
    }
}
