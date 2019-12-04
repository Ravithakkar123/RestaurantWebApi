﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace RestaurantManagement.Models
{
    public class ItemData
    {
        [Key]
        public int ItemId { get; set; }
        [Required]
        [Column(TypeName = "nvarchar(30)")]
        public string Name { get; set; }
        [Required]
        [Column(TypeName = "nvarchar(100)")]

        public int Price { get; set; }
      
       
    }
}
