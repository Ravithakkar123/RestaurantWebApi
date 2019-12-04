using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace RestaurantManagement.Models
{
    public class OrderData
    {
        [Key]
        public int OrderId { get; set; }
        [Required]
        [Column(TypeName = "nvarchar(5)")]
        public int OrderNo { get; set; }
        [Required]
        [Column(TypeName = "nvarchar(5)")]

        public int CustomerId { get; set; }
        [Required]
        [Column(TypeName = "nvarchar(5)")]

        public int PaymentMethod { get; set; }
        [Required]
        [Column(TypeName = "nvarchar(5)")]

        public int TotalAmount { get; set; }
    }
}
