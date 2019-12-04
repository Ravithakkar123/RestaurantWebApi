using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace RestaurantManagement.Models
{
    public class CustomerData
    {
        [Key]
        public int CId { get; set; }
        [Required]
        [Column(TypeName = "nvarchar(30)")]
        public string Cname { get; set; }
        
       
    }
}
