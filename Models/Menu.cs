using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace RestaurantManagement.Models
{
    public class Menu
    {
        [Key]
        public int MId { get; set; }
        [Required]
        [Column (TypeName = "nvarchar(30)")]
        public string dish_Name { get; set; }
        [Required]
        [Column(TypeName = "nvarchar(100)")]

        public string dish_Detail { get; set; }
        [Required]
        [Column(TypeName = "nvarchar(5)")]

        public int Price { get; set; }
            

    }
}
