using System;
using System.Collections.Generic;

#nullable disable

namespace CoreWebApiJWT.DataContexts
{
    public partial class SellerLogin
    {
        public int SellerLoginId { get; set; }
        public int? SellerId { get; set; }
        public string Email { get; set; }
        public string SellerPassword { get; set; }

        public virtual SellerRegistration Seller { get; set; }
    }
}
