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
        public object OrderTheProduct(OrderTable Reg)
        {
            try
            {
                OrderTable EL = new OrderTable();



                if (EL.OrderId == 0)
                {
                    EL.ProductId = Reg.ProductId;
                    EL.BuyerId = Reg.BuyerId;
                    EL.SellerId = Reg.SellerId;
                    EL.ProductName = Reg.ProductName;
                    EL.ProductPrice = Reg.ProductPrice;
                    EL.ProductQuantity = Reg.ProductQuantity;
                    EL.BuyerAddress = Reg.BuyerAddress;
                    EL.City = Reg.City;
                    EL.BuyerState = Reg.BuyerState;
                    EL.Pincode = Reg.Pincode;
                    EL.Country = Reg.Country;
                    EL.Mobile = Reg.Mobile;
                    EL.Email = Reg.Email;
                    EL.DeliverCharge = Reg.DeliverCharge;
                    DB.OrderTables.Add(EL);
                    DB.SaveChanges();
                    return new Response
                    { Status = "Success", Message = "Order successfully placed." };
                }
            }
            catch (Exception)
            {
                return new Response
                { Status = "Failure", Message = "Order already placed." };
                //throw;
            }
            return new Response
            { Status = "Error", Message = "Invalid Data." };
        }
    }

}
