using System;
using System.ComponentModel.DataAnnotations;
using LiteDB;

namespace Monocle.Models
{
    public class Contact
    {
        [BsonId] public int? Id { get; set; }
        [Required] public DateTime? SentTime { get; set; }
        [Required] public string? Message { get; set; }
    }
}