using System;
using System.Collections.Generic;

#nullable disable

namespace CoreWebApiJWT.DataContexts
{
    public partial class OrderTable
    {
        public int OrderId { get; set; }
        public int? ProductId { get; set; }
        public int? BuyerId { get; set; }
        public int? SellerId { get; set; }
        public string ProductName { get; set; }
        public int? ProductPrice { get; set; }
        public int? ProductQuantity { get; set; }
        public string BuyerAddress { get; set; }
        public string City { get; set; }
        public string BuyerState { get; set; }
        public string Pincode { get; set; }
        public string Country { get; set; }
        public string Mobile { get; set; }
        public string Email { get; set; }
        public string DeliverCharge { get; set; }
        public string TotalPrice { get; set; }

        public virtual BuyerRegistration Buyer { get; set; }
        public virtual ProductTable Product { get; set; }
        public virtual SellerRegistration Seller { get; set; }
    }
}
