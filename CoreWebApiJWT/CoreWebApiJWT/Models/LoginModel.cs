using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreWebApiJWT.Models
{
    public class LoginModel
    {
        [JsonProperty("emailId")]
        public string EmailId { get; set; }
        [JsonProperty("sellerPassword")]
        public string SellerPassword { get; set; }
    }
}
