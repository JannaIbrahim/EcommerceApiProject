using System;
using System.Collections.Generic;
using System.Text;

namespace ECommerce.DAL.Entities
{
    public class Product : BaseEntity
    {
        public String Name { get; set; }
        public String Description { get; set; }
        public Decimal Price { get; set; }
        public String PictureURL{ get; set; }
        public ProductType ProductType { get; set; }
        public int ProductTypeId { get; set; }
        public ProductBrand ProductBrand { get; set; }
        public int ProductBrandId { get; set; }
    }
}
