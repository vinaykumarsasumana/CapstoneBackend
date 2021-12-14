using System;
using System.Collections.Generic;

#nullable disable

namespace CoreWebApiJWT.DataContexts
{
    public partial class BuyerRegistration
    {
        public BuyerRegistration()
        {
            BuyerLogins = new HashSet<BuyerLogin>();
            CartTables = new HashSet<CartTable>();
            OrderTables = new HashSet<OrderTable>();
            Wishlists = new HashSet<Wishlist>();
        }

        public int BuyerRegId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string EmailId { get; set; }
        public string BuyerPassword { get; set; }
        public string BuyerAddress { get; set; }
        public string City { get; set; }
        public string BuyerState { get; set; }
        public string Pincode { get; set; }
        public string Country { get; set; }
        public string MobileNo { get; set; }

        public virtual ICollection<BuyerLogin> BuyerLogins { get; set; }
        public virtual ICollection<CartTable> CartTables { get; set; }
        public virtual ICollection<OrderTable> OrderTables { get; set; }
        public virtual ICollection<Wishlist> Wishlists { get; set; }
    }
}
