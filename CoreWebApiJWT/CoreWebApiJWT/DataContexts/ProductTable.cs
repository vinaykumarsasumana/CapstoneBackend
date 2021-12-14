using System;
using System.Collections.Generic;

#nullable disable

namespace CoreWebApiJWT.DataContexts
{
    public partial class ProductTable
    {
        public ProductTable()
        {
            CartTables = new HashSet<CartTable>();
            OrderTables = new HashSet<OrderTable>();
            ProductImages = new HashSet<ProductImage>();
            Wishlists = new HashSet<Wishlist>();
        }

        public int ProductId { get; set; }
        public int? SellerId { get; set; }
        public string ProductBrandName { get; set; }
        public string ProductType { get; set; }
        public string ProductSubType { get; set; }
        public string ProductName { get; set; }
        public int ProductPrice { get; set; }
        public int? ProductQuantity { get; set; }
        public string DeliveryTime { get; set; }
        public int? DeliveryCharge { get; set; }
        public int? ProductsSold { get; set; }
        public string ProductDescription { get; set; }
        public string ProductionCountryOrigin { get; set; }
        public string ProductTermsandCondition { get; set; }

        public virtual SellerRegistration Seller { get; set; }
        public virtual ICollection<CartTable> CartTables { get; set; }
        public virtual ICollection<OrderTable> OrderTables { get; set; }
        public virtual ICollection<ProductImage> ProductImages { get; set; }
        public virtual ICollection<Wishlist> Wishlists { get; set; }
    }
}
