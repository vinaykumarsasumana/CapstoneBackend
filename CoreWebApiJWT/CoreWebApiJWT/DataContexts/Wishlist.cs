using System;
using System.Collections.Generic;

#nullable disable

namespace CoreWebApiJWT.DataContexts
{
    public partial class Wishlist
    {
        public int CartId { get; set; }
        public int? BuyerId { get; set; }
        public int? ProductId { get; set; }
        public string ProductName { get; set; }
        public string ProductPrice { get; set; }
        public string OneImage { get; set; }

        public virtual BuyerRegistration Buyer { get; set; }
        public virtual ProductTable Product { get; set; }
    }
}
