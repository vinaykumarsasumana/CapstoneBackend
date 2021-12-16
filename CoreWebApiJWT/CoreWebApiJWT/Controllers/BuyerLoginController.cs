using CoreWebApiJWT.DataContexts;
using CoreWebApiJWT.Models;
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
    public class BuyerLoginController : ControllerBase
    {
        DemoTokenContexts DB = new DemoTokenContexts();

        [Route("BuyerLogin")]
        [HttpPost]
        public Response BuyerLogin(LoginModel loginDetails)
        {

            var log = DB.BuyerRegistrations.Where(x => x.EmailId.Equals(loginDetails.EmailId)).FirstOrDefault();
            if (log != null)
            {
                if (log.BuyerPassword == loginDetails.SellerPassword)
                {
                    return new Response { Status = "Success", Message = "Login Successful" };
                }
                else
                {
                    return new Response { Status = "Invalid", Message = "Invalid User." };
                }
            }
            else
            {
                return new Response { Status = "Invalid", Message = "Invalid User." };
            }

        }     

    }
    
}
