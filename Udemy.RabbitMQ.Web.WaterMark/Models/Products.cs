using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Udemy.RabbitMQ.Web.WaterMark.Models
{
    public class Products
    {

        [Key]
        public int Id { get; set; }
        [StringLength(100)]
        public string Name { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public string Price { get; set; }
        [Range(0, 100)]
        public int Stock { get; set; }
        [StringLength(100)]
        public string ImageName { get; set; }
    }
}
