using System;
using System.Collections.Generic;

#nullable disable

namespace CoreWebApiJWT.DataContexts
{
    public partial class CartTable
    {
        public int CartId { get; set; }
        public int? BuyerId { get; set; }
        public int? ProductId { get; set; }
        public string ProductName { get; set; }
        public int? ProductPrice { get; set; }
        public int? ProductQuantity { get; set; }
        public string ProductImage { get; set; }
        public string DeliveryTime { get; set; }
        public int? DeliveryCharge { get; set; }

        public virtual BuyerRegistration Buyer { get; set; }
        public virtual ProductTable Product { get; set; }
    }
}
