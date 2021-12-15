using System;
using System.Collections.Generic;

#nullable disable

namespace CoreWebApiJWT.DataContexts
{
    public partial class SellerRegistration
    {
        public SellerRegistration()
        {
            ProductTables = new HashSet<ProductTable>();
            SellerLogins = new HashSet<SellerLogin>();
        }

        public int SellerRegId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string EmailId { get; set; }
        public string SellerPassword { get; set; }
        public string Country { get; set; }
        public string MobileNo { get; set; }
        public string SellerAddress { get; set; }
        public string CompanyName { get; set; }
        public string CompanyUrl { get; set; }

        public virtual ICollection<ProductTable> ProductTables { get; set; }
        public virtual ICollection<SellerLogin> SellerLogins { get; set; }
    }
}
