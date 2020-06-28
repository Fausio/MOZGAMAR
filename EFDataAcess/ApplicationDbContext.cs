using System;
using System.Collections.Generic;
using System.Text;
using System.Data.Entity;
using Domain;

namespace EFDataAcess
{
   public class ApplicationDbContext : DbContext
    {

        public virtual DbSet<CarStatus> CarStatus { get; set; }
        public virtual DbSet<Cart> Cart { get; set; }
        public virtual DbSet<Category> Category { get; set; }
        public virtual DbSet<Member> Member { get; set; }
        public virtual DbSet<MemberRole> MemberRole { get; set; }
        public virtual DbSet<Product> Product { get; set; }
        public virtual DbSet<Role> Role { get; set; }
        public virtual DbSet<ShippingDetails> ShippingDetails { get; set; }
        public virtual DbSet<SlideImage> SlideImage { get; set; }

    }
}
