using CoreWebApiJWT.DataContexts;
using CoreWebApiJWT.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreWebApiJWT.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CartController : ControllerBase
    {
        DemoTokenContexts DB = new DemoTokenContexts();
        [Route("AddToCart")]
        [HttpPost]
        public object AddToCart(CartTable Reg)
        {
            //try
            //{
            // CartTable EL = new CartTable();



            // if (EL.CartId == 0)
            // {
            // EL.BuyerId = Reg.BuyerId;
            // EL.ProductId = Reg.ProductId;
            // EL.ProductName = Reg.ProductName;
            // EL.ProductPrice = Reg.ProductPrice;
            // EL.ProductQuantity = Reg.ProductQuantity;
            // EL.ProductImage = Reg.ProductImage;
            // DB.CartTables.Add(EL);
            // DB.SaveChanges();
            // return new Response
            // { Status = "Success", Message = "Added to cart successfully." };
            // }
            //}
            //catch (Exception)
            //{
            // return new Response
            // { Status = "Failure", Message = "Invalid Data" };
            // //throw;
            //}
            //return new Response
            //{ Status = "Error", Message = "Invalid Data." };

            //..........................................


            try
            {
                var obj = DB.CartTables.Where(x => x.ProductId.Equals(Reg.ProductId)).ToList().FirstOrDefault();
                if (obj == null)
                {
                    CartTable EL = new CartTable();
                    EL.BuyerId = Reg.BuyerId;
                    EL.ProductId = Reg.ProductId;
                    EL.ProductName = Reg.ProductName;
                    EL.ProductPrice = Reg.ProductPrice;
                    EL.ProductQuantity = Reg.ProductQuantity;
                    EL.ProductImage = Reg.ProductImage;

                    EL.DeliveryCharge = Reg.DeliveryCharge;
                    EL.DeliveryTime = Reg.DeliveryTime;


                    DB.CartTables.Add(EL);
                    DB.SaveChanges();
                    return new Response
                    { Status = "Success", Message = "Added to cart successfully." };
                }
                else
                {
                    //var obj = DB.Wishlists.Where(x => x.ProductId == Reg.ProductId).ToList().FirstOrDefault();
                    //if (obj.ProductId > 0)
                    //{
                    return new Response
                    { Status = "Error", Message = "Product already exists in cart." };
                    //}
                }
            }
            catch (Exception ex)
            {
                Console.Write(ex.Message);
            }
            return new Response
            {
                Status = "Error",
                Message = "Data not insert"
            };
        }



        //[Route("UpdateSeller")]
        //[HttpPost]
        //public object UpdateSeller(SellerRegistration Reg)
        //{
        // try
        // {
        // if (Reg.SellerRegId != 0)
        // {
        // var obj = DB.SellerRegistrations.Where(x => x.SellerRegId == Reg.SellerRegId).ToList().FirstOrDefault();
        // if (obj.SellerRegId > 0)
        // {
        // obj.FirstName = Reg.FirstName;
        // obj.LastName = Reg.LastName;
        // obj.EmailId = Reg.EmailId;
        // obj.SellerPassword = Reg.SellerPassword;
        // obj.Country = Reg.Country;
        // obj.MobileNo = Reg.MobileNo;
        // obj.SellerAddress = Reg.SellerAddress;
        // obj.CompanyName = Reg.CompanyName;
        // obj.CompanyUrl = Reg.CompanyUrl;
        // DB.SaveChanges();
        // return new Response
        // {
        // Status = "Updated",
        // Message = "Updated Successfully"
        // };
        // }
        // }
        // }
        // catch (Exception ex)
        // {
        // //Console.Write(ex.Message);
        // return new Response
        // { Status = "Failure", Message = "User not found." };
        // }
        // return new Response
        // { Status = "Error", Message = "User not found." };
        //}



        //[Route("GetAllCartDetails")]
        //[HttpGet]
        //public object GetAllSellerDetails()
        //{



        // var a = DB.SellerRegistrations.ToList();
        // return a;
        //}



        [Route("GetCartDetailsById")]
        [HttpGet]
        public object GetCartDetailsById(int BuyerId)
        {
            var obj = DB.CartTables.Where(x => x.BuyerId == BuyerId).ToList();
            return obj;
        }



        //[Route("GetSellerDetailsByEmail")]
        //[HttpGet]
        //public object GetSellerDetailsByEmail(string Email)
        //{
        // var obj = DB.SellerRegistrations.Where(x => x.EmailId == Email).ToList().FirstOrDefault();
        // return obj;
        //}



        //[Route("DeleteSeller")]
        //[HttpDelete]
        //public object DeleteSeller(int SellerRegId)
        //{
        // var obj = DB.SellerRegistrations.Where(x => x.SellerRegId == SellerRegId).ToList().FirstOrDefault();
        // DB.SellerRegistrations.Remove(obj);
        // DB.SaveChanges();
        // return new Response
        // {
        // Status = "Delete",
        // Message = "Record Deleted Successfully"
        // };
        //}



        //Query to sort in ascending and descending order



        //[Route("Sorting")]
        //[HttpGet]
        //public object sorting(string sortOrder)
        //{
        // var products = from s in DB.ProductTables
        // select s;
        // switch (sortOrder)
        // {
        // case "Z2A":
        // products = products.OrderByDescending(s => s.ProductName);
        // break;
        // case "A2Z":
        // products = products.OrderBy(s => s.ProductName);
        // break;
        // case "H2L":
        // products = products.OrderByDescending(s => s.ProductPrice);
        // break;
        // case "L2H":
        // products = products.OrderBy(s => s.ProductPrice);
        // break;
        // case "BS":
        // products = products.OrderBy(s => s.ProductPrice);
        // break;
        // default:
        // products = products.OrderBy(s => s.ProductName);
        // break;
        // }



        // var items = products
        // .Select(f => new OnlyName
        // {
        // Name = f.ProductName
        // }).ToList();
        // return items;
        //}



        ////Function for querying search
        //[Route("Searching")]
        //[HttpGet]
        //public object search(string search)
        //{
        // var product = DB.ProductTables.Where(s => s.ProductName.Contains(search) || search == null).ToList().Take(10);



        // var items = product
        // .Select(f => new OnlyName
        // {
        // Name = f.ProductName
        // }).ToList();
        // return items;
        // //return (DB.Registers.Where(s => s.Name.StartsWith(search) || search == null).ToList().Take(10));
        // //return (DB.Registers.Where(s => s.Name.Contains(search) || search == null).ToList().Take(10));
        //}

        //.................

        //[HttpGet]
        //public async Task<ActionResult<CartTable>> GetCartDetails(string ProductName)
        //{
        //    var obj = DB.CartTables.Where(x => x.ProductName == ProductName).ToList().FirstOrDefault();

        //    //return obj;
        //    return obj;
        //}

        [HttpPut("{CartId}")]
        public async Task<IActionResult> PutCartTable(int CartId, CartTable cartTable)
        {
            if (CartId != cartTable.CartId)
            {
                return BadRequest();
            }

            DB.Entry(cartTable).State = EntityState.Modified;

            try
            {
                await DB.SaveChangesAsync();
            }
            catch (/*DbUpdateConcurrencyException*/Exception)
            {
                if (!CartTableExists(CartId))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }
        private bool CartTableExists(int id)
        {
            return DB.CartTables.Any(e => e.CartId == id);
        }



        [Route("DeleteFromCart")]
        [HttpDelete]
        public object DeleteFromCart(int ProductId)
        {
            var obj = DB.CartTables.Where(x => x.ProductId == ProductId).ToList().FirstOrDefault();
            DB.CartTables.Remove(obj);
            DB.SaveChanges();
            return new Response
            {
                Status = "Delete",
                Message = "Record Deleted Successfully"
            };
        }


    }
}
