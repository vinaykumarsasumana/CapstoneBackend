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
    public class ProdcutImageController : ControllerBase
    {
        DemoTokenContexts DB = new DemoTokenContexts();

        [Route("AddProduct")]
        [HttpPost]
        public object AddProduct(ProductTable Reg)
        {

            try
            {
                ProductTable EL = new ProductTable();

                if (EL.ProductId == 0)
                {
                    //EL.SellerId = Reg.SellerId;
                    //EL.ProductBrandName = Reg.ProductBrandName;
                    //EL.ProductType = Reg.ProductType;
                    //EL.ProductSubType = Reg.ProductSubType;
                    //EL.ProductName = Reg.ProductName;
                    //EL.ProductPrice = Reg.ProductPrice;
                    //EL.DeliveryCharge = Reg.DeliveryCharge;
                    //EL.ProductDescription = Reg.ProductDescription;
                    //EL.ProductionCountryOrigin = Reg.ProductionCountryOrigin;
                    //EL.ProductTermsandCondition = Reg.ProductTermsandCondition;
                    //DB.ProductTables.Add(EL);
                    //DB.SaveChanges();
                    EL.SellerId = Reg.SellerId;
                    EL.ProductBrandName = Reg.ProductBrandName;
                    EL.ProductType = Reg.ProductType;
                    EL.ProductSubType = Reg.ProductSubType;
                    EL.ProductName = Reg.ProductName;
                    EL.ProductPrice = Reg.ProductPrice;
                    EL.ProductQuantity = Reg.ProductQuantity;
                    EL.DeliveryTime = Reg.DeliveryTime;
                    EL.DeliveryCharge = Reg.DeliveryCharge;
                    Random r = new Random();
                    EL.ProductsSold = r.Next(1, 1000);
                    EL.ProductDescription = Reg.ProductDescription;
                    EL.ProductionCountryOrigin = Reg.ProductionCountryOrigin;
                    EL.ProductTermsandCondition = Reg.ProductTermsandCondition;
                    DB.ProductTables.Add(EL);
                    DB.SaveChanges();


                    //    var PL = DB.ProductTables.Where(x => x.ProductId == Reg.ProductId).ToList().FirstOrDefault();

                    var PI = DB.ProductTables.Where(x => x.ProductName == Reg.ProductName).ToList().FirstOrDefault();

                    ProductImage a = new ProductImage();
                    a.ProductId = PI.ProductId;
                    foreach (ProductImage image in Reg.ProductImages)
                    {
                        a.ProductImageId = 0;
                        a.ProductImageUrl = image.ProductImageUrl;
                        a.ImageCaption = image.ImageCaption;


                        DB.ProductImages.Add(a);
                        DB.SaveChanges();
                    }


                    return new Response
                    { Status = "Success", Message = "Registration successful." };
                }
            }
            catch (Exception Ex)
            {
                return new Response
                //{ Status = "Failure", Message = "Seller does not exists." };
                { Status = "Failure", Message = Ex.InnerException.Message };
                //throw;
            }
            return new Response
            { Status = "Error", Message = "Invalid Data." };

        }
    }
}
