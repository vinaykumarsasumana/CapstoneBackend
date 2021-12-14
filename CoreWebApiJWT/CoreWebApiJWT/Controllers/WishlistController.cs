//using CoreWebApiJWT.DataContexts;
//using CoreWebApiJWT.Models;
//using Microsoft.AspNetCore.Http;
//using Microsoft.AspNetCore.Mvc;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Threading.Tasks;

//namespace CoreWebApiJWT.Controllers
//{
//    [Route("api/[controller]")]
//    [ApiController]
//    public class WishlistController : ControllerBase
//    {
//        DemoTokenContexts DB = new DemoTokenContexts();
//        [Route("AddToWishlist")]
//        [HttpPost]
//        public object AddToWishlist(Wishlist Reg)
//        {
//            try
//            {
//                var obj = DB.Wishlists.Where(x => x.ProductId == Reg.ProductId).ToList().FirstOrDefault();
//                if (obj == null)
//                {
//                    Wishlist EL = new Wishlist();
//                    EL.BuyerId = Reg.BuyerId;
//                    EL.ProductId = Reg.ProductId;
//                    EL.ProductName = Reg.ProductName;
//                    EL.ProductPrice = Reg.ProductPrice;
//                    EL.OneImage = Reg.OneImage;
//                    DB.Wishlists.Add(EL);
//                    DB.SaveChanges();
//                    return new Response
//                    {
//                        Status = "Success",
//                        Message = "Data Successfully"
//                    };
//                }
//                else
//                {
//                    //var obj = DB.Wishlists.Where(x => x.ProductId == Reg.ProductId).ToList().FirstOrDefault();
//                    //if (obj.ProductId > 0)
//                    //{
//                    return new Response
//                    { Status = "Error", Message = "Product already exists in wishlist." };
//                    //}
//                }
//            }
//            catch (Exception ex)
//            {
//                Console.Write(ex.Message);
//            }
//            return new Response
//            {
//                Status = "Error",
//                Message = "Data not insert"
//            };
//        }
//    }
//}
