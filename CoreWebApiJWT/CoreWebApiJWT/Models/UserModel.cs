using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreWebApiJWT.Models
{
    public class UserModel
    {
        [JsonProperty("sellerRegId")]
        public int SellerRegId { get; set; }
        [JsonProperty("firstName")]
        public string FirstName { get; set; }
        [JsonProperty("lastName")]
        public string LastName { get; set; }
        
        [JsonProperty("emailId")]
        public string EmailId { get; set; }

        [JsonProperty("sellerPassword")]
        public string SellerPassword { get; set; }
        [JsonProperty("country")]
        public string Country { get; set; }
        [JsonProperty("mobileNo")]
        public string MobileNo { get; set; }
        [JsonProperty("sellerAddress")]
        public string SellerAddress { get; set; }
        [JsonProperty("companyName")]
        public string CompanyName { get; set; }
        [JsonProperty("companyUrl")]
        public string CompanyUrl { get; set; }
        [JsonProperty("sellerLogin")]
        public List<string> sellerLogin { get; set; }
        [JsonProperty("productTable")]
        public List<string> ProductTable { get; set; }
        [JsonProperty("orderTable")]
        public List<string> OrderTable { get; set; }
    }
}
