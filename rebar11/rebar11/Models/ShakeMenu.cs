using System;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.ComponentModel.DataAnnotations;

namespace rebar11.Models
{
    [BsonIgnoreExtraElements]
    public class ShakeMenu
    {
        [Required]
        [BsonId]
        [BsonRepresentation(BsonType.String)]
        public Guid ShakeID { get; set; }

        [Required]
        [BsonElement("ShakeName")]
        public string ShakeName { get; set; }

        [Required]
        [BsonElement("ShakeDescription")]
        public string ShakeDescription { get; set; }

        [Required]
        [BsonElement("ShakeSizeL")]
        public double ShakeSizeL { get; set; }

        [Required]
        [BsonElement("ShakeSizeM")]
        public double ShakeSizeM { get; set; }

        [Required]
        [BsonElement("ShakeSizeS")]
        public double ShakeSizeS { get; set; }
    }
}
