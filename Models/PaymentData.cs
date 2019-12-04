using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace RestaurantManagement.Models
{
    public class PaymentData
    {
        [Key]
        public int PId { get; set; }
        [Required]
        [Column (TypeName = "nvarchar(100)")]
        public string CardOwnerName { get; set; }
        [Required]
        [Column(TypeName = "nvarchar(16)")]

        public string CardNumber { get; set; }
        [Required]
        [Column(TypeName = "nvarchar(5)")]

        public string Exp { get; set; }
        [Required]
        [Column(TypeName = "nvarchar(3)")]

        public string CVV { get; set; }

    }

}
