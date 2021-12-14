using System;
using System.Collections.Generic;

#nullable disable

namespace CoreWebApiJWT.DataContexts
{
    public partial class BuyerLogin
    {
        public int BuyerLoginId { get; set; }
        public int? BuyerId { get; set; }
        public string EmailId { get; set; }
        public string BuyerPassword { get; set; }

        public virtual BuyerRegistration Buyer { get; set; }
    }
}
