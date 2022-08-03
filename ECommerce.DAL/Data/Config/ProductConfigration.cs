using ECommerce.DAL.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace ECommerce.DAL.Data.Config
{
    class ProductConfigration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.Property(P => P.Name).IsRequired().HasMaxLength(100);
            builder.Property(P => P.Description).IsRequired();
            builder.Property(P => P.Price).HasColumnType("decimal(18,2)");
            builder.Property(P => P.PictureURL).IsRequired();
            //builder.HasOne(P => P.ProductBrand).WithMany()
            //    .HasForeignKey(P => P.ProductBrandId);
            //builder.HasOne(P => P.ProductType).WithMany()
            //    .HasForeignKey(P => P.ProductTypeId);
        }
    }
}
