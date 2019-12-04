using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestaurantManagement.Models
{
    public class DataContext : DbContext
    {
        public DataContext()
        {
        }

        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }

        public DbSet<PaymentData> paymentDatas { get; set; }
        public DbSet<Menu> menu { get; set; }

        public DbSet<CustomerData> customerData { get; set; } 

        public DbSet<OrderData> orderData { get; set; }

        public DbSet<ItemData> ItemData { get; set; }

        public DbSet<OrderItemData> orderItemData { get; set; }
    }
}
