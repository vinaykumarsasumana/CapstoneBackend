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
    public class SellerController : ControllerBase
    {
        DemoTokenContexts DB = new DemoTokenContexts();
        [Route("SellerRegister")]
        [HttpPost]
        public object SellerRegister(SellerRegistration Reg)
        {
            try
            {
                SellerRegistration EL = new SellerRegistration();

                if (EL.SellerRegId == 0)
                {
                    EL.FirstName = Reg.FirstName;
                    EL.LastName = Reg.LastName;
                    EL.EmailId = Reg.EmailId;
                    EL.SellerPassword = Reg.SellerPassword;
                    EL.Country = Reg.Country;
                    EL.MobileNo = Reg.MobileNo;
                    EL.SellerAddress = Reg.SellerAddress;
                    EL.CompanyName = Reg.CompanyName;
                    EL.CompanyUrl = Reg.CompanyUrl;
                    DB.SellerRegistrations.Add(EL);
                    DB.SaveChanges();
                    return new Response
                    { Status = "Success", Message = "Registration successful." };
                }
            }
            catch (Exception)
            {
                return new Response
                { Status = "Failure", Message = "EmailID already registered." };
            }
            return new Response
            { Status = "Error", Message = "Invalid Data." };
        }

        [Route("SellerLogin")]
        [HttpPost]
        public Response SellerLogin(LoginModel loginDetails)
        {
            var log = DB.SellerRegistrations.Where(x => x.EmailId.Equals(loginDetails.EmailId)).FirstOrDefault();
            if (log != null)
            {
                if (log.SellerPassword == loginDetails.SellerPassword)
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

        [Route("UpdateSeller")]
        [HttpPost]
        public object UpdateSeller(SellerRegistration Reg)
        {
            try
            {
                if (Reg.SellerRegId != 0)
                {
                    var obj = DB.SellerRegistrations.Where(x => x.SellerRegId == Reg.SellerRegId).ToList().FirstOrDefault();
                    if (obj.SellerRegId > 0)
                    {
                        obj.FirstName = Reg.FirstName;
                        obj.LastName = Reg.LastName;
                        obj.EmailId = Reg.EmailId;
                        obj.SellerPassword = Reg.SellerPassword;
                        obj.Country = Reg.Country;
                        obj.MobileNo = Reg.MobileNo;
                        obj.SellerAddress = Reg.SellerAddress;
                        obj.CompanyName = Reg.CompanyName;
                        obj.CompanyUrl = Reg.CompanyUrl;
                        DB.SaveChanges();
                        return new Response
                        {
                            Status = "Updated",
                            Message = "Updated Successfully"
                        };
                    }
                }
            }
            catch (Exception ex)
            {
                return new Response
                { Status = "Failure", Message = "User not found." };
            }
            return new Response
            { Status = "Error", Message = "User not found." };
        }

        [Route("GetAllSellerDetails")]
        [HttpGet]
        public object GetAllSellerDetails()
        {

            var a = DB.SellerRegistrations.ToList();
            return a;
        }

        [Route("GetSellerDetailsById")]
        [HttpGet]
        public object GetSellerDetailsById(int SellerRegId)
        {
            var obj = DB.SellerRegistrations.Where(x => x.SellerRegId == SellerRegId).ToList().FirstOrDefault();
            return obj;
        }

        [Route("GetSellerDetailsByEmail")]
        [HttpGet]
        public object GetSellerDetailsByEmail(string Email)
        {
            var obj = DB.SellerRegistrations.Where(x => x.EmailId == Email).ToList().FirstOrDefault();
            return obj;
        }

    }
}

