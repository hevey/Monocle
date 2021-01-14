using System;
using System.ComponentModel.DataAnnotations;
using LiteDB;

namespace Monocle.Shared.Models
{
    public class Contact
    {
        [BsonId] public int? Id { get; set; }
        [Required] public DateTime? SubmissionTime { get; set; }
        [Required] public string? Message { get; set; }
    }
}