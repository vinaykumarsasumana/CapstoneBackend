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
                    return new Response
                    { Status = "Error", Message = "Product already exists in cart." };
                    
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

        [Route("GetCartDetailsByBuyerId")]
        [HttpGet]
        public object GetCartDetailsByBuyerId(int BuyerId)
        {
            var obj = DB.CartTables.Where(x => x.BuyerId == BuyerId).ToList();
            return obj;
        }

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
            catch (Exception)
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



        [Route("DeleteFromCartByProductId")]
        [HttpDelete]
        public object DeleteFromCartByProductId(int ProductId)
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


        [Route("DeleteFromCartByBuyerId")]
        [HttpDelete]
        public object DeleteFromCartByBuyerId(int BuyerId)
        {
            var obj = DB.CartTables.Where(x => x.BuyerId == BuyerId).ToList();
            foreach (var prod in obj)
            {
                DB.CartTables.Remove(prod);
                DB.SaveChanges();
            }

            return new Response
            {
                Status = "Delete",
                Message = "Record Deleted Successfully"
            };
        }

    }
}
