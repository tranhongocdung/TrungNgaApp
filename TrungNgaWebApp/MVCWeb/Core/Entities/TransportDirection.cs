using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MVCWeb.Core.Entities
{
    [Table("TransportDirection")]
    public class TransportDirection
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }

    }
}