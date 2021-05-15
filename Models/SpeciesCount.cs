using System;
using PostgresCRUD.Models;
using Microsoft.EntityFrameworkCore; 
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PostgresCRUD.Models
{
    public class SpeciesCount
    {
        [JsonProperty("species")]
        public string Species { get; set; }

        [JsonProperty("count")]
        public int Count { get; set; }
    }
}
