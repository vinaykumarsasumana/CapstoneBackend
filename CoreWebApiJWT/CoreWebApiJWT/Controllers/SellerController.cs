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
                //throw;
            }
            return new Response
            { Status = "Error", Message = "Invalid Data." };
        }

        //[Route("SellerLogin")]
        //[HttpPost]
        //public Response sellerLogin(string Email, string Password)
        //{
        //    //var log = DB.SellerRegisters.Where(x => x.EmailId.Equals(reg.EmailID)).FirstOrDefault();
        //    //var log = DB.SellerRegisters.Where(x => x.Id.Equals(loginId) ).FirstOrDefault();

        //    var log = DB.SellerRegistrations.Where(x => x.EmailId.Equals(Email)).FirstOrDefault();
        //    var pass = DB.SellerRegistrations.Where(x => x.SellerPassword.Equals(Password)).FirstOrDefault();

        //    if (log == null || pass == null)
        //    {
        //        return new Response { Status = "Invalid", Message = "Invalid User." };
        //    }
        //    else
        //    {
        //        SellerLogin EL = new SellerLogin();
        //        //EL.SellerId = SellerRegID;
        //        EL.Email = Email;
        //        EL.SellerPassword = Password;
        //        DB.SellerLogins.Add(EL);
        //        DB.SaveChanges();
        //        return new Response { Status = "Success", Message = "Login Successful" };
        //    }
        //}
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
                //Console.Write(ex.Message);
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

        //[Route("GetSellerDetailsByEmail")]
        //[HttpGet]
        //public object GetSellerDetailsByEmail(string Email)
        //{
        //    var obj = DB.SellerRegistrations.Where(x => x.EmailId == Email).ToList().FirstOrDefault();
        //    return obj;
        //}

        //[Route("DeleteSeller")]
        //[HttpDelete]
        //public object DeleteSeller(int SellerRegId)
        //{
        //    var obj = DB.SellerRegistrations.Where(x => x.SellerRegId == SellerRegId).ToList().FirstOrDefault();
        //    DB.SellerRegistrations.Remove(obj);
        //    DB.SaveChanges();
        //    return new Response
        //    {
        //        Status = "Delete",
        //        Message = "Record Deleted Successfully"
        //    };
        //}

        //Query to sort in ascending and descending order

        //[Route("Sorting")]
        //[HttpGet]
        //public object sorting(string sortOrder)
        //{
        //    var products = from s in DB.ProductTables
        //                   select s;
        //    switch (sortOrder)
        //    {
        //        case "Z2A":
        //            products = products.OrderByDescending(s => s.ProductName);
        //            break;
        //        case "A2Z":
        //            products = products.OrderBy(s => s.ProductName);
        //            break;
        //        case "H2L":
        //            products = products.OrderByDescending(s => s.ProductPrice);
        //            break;
        //        case "L2H":
        //            products = products.OrderBy(s => s.ProductPrice);
        //            break;
        //        case "BS":
        //            products = products.OrderBy(s => s.ProductPrice);
        //            break;
        //        default:
        //            products = products.OrderBy(s => s.ProductName);
        //            break;
        //    }

        //    var items = products
        //      .Select(f => new OnlyName
        //      {
        //          Name = f.ProductName
        //      }).ToList();
        //    return items;
        //}

        ////Function for querying search
        //[Route("Searching")]
        //[HttpGet]
        //public object search(string search)
        //{
        //    var product = DB.ProductTables.Where(s => s.ProductName.Contains(search) || search == null).ToList().Take(10);

        //    var items = product
        //      .Select(f => new OnlyName
        //      {
        //          Name = f.ProductName
        //      }).ToList();
        //    return items;
        //    //return (DB.Registers.Where(s => s.Name.StartsWith(search) || search == null).ToList().Take(10));
        //    //return (DB.Registers.Where(s => s.Name.Contains(search) || search == null).ToList().Take(10));
        //}


        [Route("GetSellerDetailsByEmail")]
        [HttpGet]
        public object GetSellerDetailsByEmail(string Email)
        {
            var obj = DB.SellerRegistrations.Where(x => x.EmailId == Email).ToList().FirstOrDefault();
            return obj;
        }



    }
}

