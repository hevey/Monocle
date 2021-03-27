using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using LiteDB;

namespace Monocle.Shared.Models
{
    public class Schema
    {
        [BsonId] public int Id { get; set; }
        [Required] public string Name { get; set; }
        [Required] public List<Field> Fields { get; set; }
        [Required] public int Version { get; set; }
    }
}