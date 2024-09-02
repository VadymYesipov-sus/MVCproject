using System.ComponentModel.DataAnnotations;
using System.Reflection.Metadata;

namespace MVCproject.Models
{
    public class Address
    {
        [Key]
        public int Id { get; set; }
        public string Street { get; set; }
        public string State { get; set; }
        public string City { get; set; }

    }
}
