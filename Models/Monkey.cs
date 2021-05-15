using System;
using PostgresCRUD.Models;
using Microsoft.EntityFrameworkCore; 
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PostgresCRUD.Models
{
    public class Monkey
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [JsonProperty("_id")]
        [Column("id")]
        public string Id { get; set; }

        [Column("name")]
        public string Name { get; set; }

        [Column("age")]
        public int Age { get; set; }

        [Column("weight")]
        public int Weight { get; set; }

        [Column("eyecolor")]
        public string EyeColor { get; set; }

        [Column("species")]
        public string Species { get; set; }

        [DataType(DataType.DateTime)]
        [JsonConverter(typeof(JsonDateTimeConverter))]
        [Column("registered")]
        public DateTime Registered { get; set; }

        [Column("favoritefruit")]
        public string FavoriteFruit { get; set; }
    }
}
