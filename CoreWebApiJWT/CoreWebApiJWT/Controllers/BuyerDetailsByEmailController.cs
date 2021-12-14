using CoreWebApiJWT.DataContexts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreWebApiJWT.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BuyerDetailsByEmailController : ControllerBase
    {
        DemoTokenContexts DB = new DemoTokenContexts();
        [Route("GetBuyerDetailsByEmail")]
        [HttpGet]
        public object GetBuyerDetailsByEmail(string Email)
        {
            var obj = DB.BuyerRegistrations.Where(x => x.EmailId == Email).ToList().FirstOrDefault();
            return obj;
        }
    }
}
