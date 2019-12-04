using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace RestaurantManagement.Models
{
    public class OrderItemData
    {
        [Key]
        public int OrderItemId { get; set; }
        [Required]
        [Column(TypeName = "nvarchar(5)")]
        public int OrderId{ get; set; }
        [Required]
        [Column(TypeName = "nvarchar(5)")]

        public int ItemId{ get; set; }
        [Required]
        [Column(TypeName = "nvarchar(5)")]

        public int Quantity { get; set; }
    }
}
