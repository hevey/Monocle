using System;

namespace Monocle.Shared.Models
{
    public class Field
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public FieldType FieldType { get; set; }
        public bool Required { get; set; }
    }
}