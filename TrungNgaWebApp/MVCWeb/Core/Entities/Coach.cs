using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MVCWeb.Core.Entities
{
    [Table("Coach")]
    public class Coach
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }

    }
}