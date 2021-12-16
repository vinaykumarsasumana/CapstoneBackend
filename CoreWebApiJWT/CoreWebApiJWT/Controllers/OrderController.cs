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
    public class OrderController : ControllerBase
    {
        DemoTokenContexts DB = new DemoTokenContexts();
        [Route("OrderTheProduct")]
        [HttpPost]
        public object OrderTheProduct(OrderTable[] Orders)
        {
            DemoTokenContexts DB = new DemoTokenContexts();
            try
            {
                foreach (var item in Orders)
                {
                    DB.OrderTables.Add(item);
                    DB.SaveChanges();
                }
                return new Response
                { Status = "Success", Message = "Order successfully placed." };
            }
            catch (Exception Ex)
            {
                return new Response
                { Status = "Failure", Message = Ex.InnerException.Message };
                //throw;
            }
            return new Response
            { Status = "Error", Message = "Invalid Data." };
        }


        [Route("GetOrderDetailsByBuyerId")]
        [HttpGet]
        public object GetOrderDetailsByBuyerId(int BuyerId)
        {
            var obj = DB.OrderTables.Where(x => x.BuyerId == BuyerId).ToList();
            return obj;
        }

        [Route("GetOrderDetailsByProductId")]
        [HttpGet]
        public object GetOrderDetailsByProductId(int ProductId)
        {
            var obj = DB.OrderTables.Where(x => x.ProductId == ProductId).ToList();
            return obj;
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteOrder(int ProductId)
        {
            var order = DB.OrderTables.Where(x => x.ProductId == ProductId).ToList().FirstOrDefault();
            if (order == null)
            {
                return NotFound();
            }

            DB.OrderTables.Remove(order);
            await DB.SaveChangesAsync();

            return NoContent();
        }

    }

}
