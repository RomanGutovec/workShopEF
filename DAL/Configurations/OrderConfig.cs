using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Configurations
{
    public class OrderConfig : EntityTypeConfiguration<Order>
    {
        public OrderConfig()
        {
            this.ToTable("tbl_orders").HasKey(order => order.Id);
            this.Property(order => order.Id).HasColumnName("cln_order_id");
            this.Property(order => order.Date).HasColumnName("cln_order_date");
            //this.HasMany(o => o.Items)
            //    .WithMany(i => i.Orders)
            //    .Map(m => m.ToTable("tbl_order_items")
            //    .MapLeftKey("cln_order_id")
            //    .MapRightKey("cln_item_id"));
            this.HasMany(orderItem => orderItem.OrderItems)
                .WithRequired(orderItem => orderItem.Order)
                .HasForeignKey(orderItem => orderItem.OrderId);
        }
    }
}
