using CoreWebApiJWT.DataContexts;
using CoreWebApiJWT.Models;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreWebApiJWT.Controllers
{
    //[EnableCors]
    [Route("api/[controller]")]
    [ApiController]
    public class ProductEmptyController : ControllerBase
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
                    EL.SellerId = Reg.SellerId;
                    EL.ProductBrandName = Reg.ProductBrandName;
                    EL.ProductType = Reg.ProductType;
                    EL.ProductSubType = Reg.ProductSubType;
                    EL.ProductName = Reg.ProductName;
                    EL.ProductPrice = Reg.ProductPrice;
                    EL.DeliveryCharge = Reg.DeliveryCharge;
                    EL.ProductDescription = Reg.ProductDescription;
                    EL.ProductionCountryOrigin = Reg.ProductionCountryOrigin;
                    EL.ProductTermsandCondition = Reg.ProductTermsandCondition;
                    DB.ProductTables.Add(EL);
                    DB.SaveChanges();
                    return new Response
                    { Status = "Success", Message = "Registration successful." };
                }
            }
            catch (Exception)
            {
                return new Response
                { Status = "Failure", Message = "Seller does not exists." };
                //throw;
            }
            return new Response
            { Status = "Error", Message = "Invalid Data." };
        }

        [Route("UpdateProductDetails")]
        [HttpPost]
        public object UpdateProduct(ProductTable Reg)
        {
            try
            {
                if (Reg.ProductId != 0)
                {
                    var EL = DB.ProductTables.Where(x => x.ProductId == Reg.ProductId).ToList().FirstOrDefault();
                    if (EL.ProductId > 0)
                    {
                        EL.ProductBrandName = Reg.ProductBrandName;
                        EL.ProductType = Reg.ProductType;
                        EL.ProductSubType = Reg.ProductSubType;
                        EL.ProductName = Reg.ProductName;
                        EL.ProductPrice = Reg.ProductPrice;
                        EL.DeliveryCharge = Reg.DeliveryCharge;
                        EL.ProductDescription = Reg.ProductDescription;
                        EL.ProductionCountryOrigin = Reg.ProductionCountryOrigin;
                        EL.ProductTermsandCondition = Reg.ProductTermsandCondition;
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
                { Status = "Failure", Message = "Product not found." };
            }
            return new Response
            { Status = "Error", Message = "Product not found." };
        }

        [Route("GetAllProductDetails")]
        [HttpGet]
        public object GetAllProductDetails()
        {
            var a = DB.ProductTables.ToList();
            return a;
        }

        [Route("GetProductDetailsById")]
        [HttpGet]
        public object GetProductDetailsById(int SellerRegId)
        {
            var obj = DB.ProductTables.Where(x => x.SellerId == SellerRegId).ToList();
            return obj;
        }

        [Route("GetProductDetailsByProductName")]
        [HttpGet]
        public object GetProductDetailsByProductName(string ProductName)
        {
            //var img = DB.ProductTables.Where(x => x.ProductName == ProductName);
                //GetProductImageDetailsByProductName(DB.ProductTables.Find(ProductTable.P));
            //if (GetProductImageDetailsByProductName(x.ProductId)==0)

            var obj = DB.ProductTables.Where(x => x.ProductName == ProductName).ToList();
            //var img = GetProductImageDetailsByProductName(DB.ProductTables.Find(ProductTable.P))
            //DB.ProductImages.Where(x => x.ProductId == product.ProductId).ToList();
            //return obj;

            //List<string> roleNames = (from UM in DB.ProductTables
            //                          join UR in DB.ProductImages on UM.ProductId equals UR.ProductId
            //                          select UR.ProductImageUrl).ToList();

            //List<ProductTable> rolesMasters = (from UM in DB.ProductTables
            //                                   join UR in DB.ProductImages on UM.ProductId equals UR.ProductId
            //                                   where UM.ProductName == ProductName
            //                                   select UM).ToList();

            //        List<RolesMaster> rolesMasters = (from UM in _context.SellerRegistrations
            //                                          join UR in _context.UserRoles on UM.SellerRegId equals UR.UserId
            //                                          join RM in _context.RolesMaster on UR.RoleId equals RM.RoleId
            //                                          where UM.SellerRegId == UserId
            //                                          select RM).ToList();

            return obj;
        }

        [Route("DeleteProduct")]
        [HttpDelete]
        public object DeleteProduct(int ProductId)
        {
            var obj = DB.ProductTables.Where(x => x.ProductId == ProductId).ToList().FirstOrDefault();
            DB.ProductTables.Remove(obj);
            DB.SaveChanges();
            return new Response
            {
                Status = "Delete",
                Message = "Product Deleted Successfully"
            };
        }

        //Query to sort in ascending and descending order

        [Route("Sorting")]
        [HttpGet]
        public object sorting(string SubType, string sortOrder)
        {
            //var products = from s in DB.ProductTables
            //               select s;
            var products1 = from s in DB.ProductImages
                           select s;
            var products = DB.ProductTables.Where(s => s.ProductSubType.Contains(SubType) || SubType == null).ToList().Take(10);

            switch (sortOrder)
            {
                case "Z2A":
                    products = products.OrderByDescending(s => s.ProductName);
                    break;
                case "A2Z":
                    products = products.OrderBy(s => s.ProductName);
                    break;
                case "H2L":
                    products = products.OrderByDescending(s => s.ProductPrice);
                    break;
                case "L2H":
                    products = products.OrderBy(s => s.ProductPrice);
                    break;
                case "BS":
                    products = products.OrderBy(s => s.ProductPrice);
                    break;
                default:
                    products = products.OrderBy(s => s.ProductName);
                    break;
            }

            var items = products
              .Select(f => new FewFields
              {
                  Name = f.ProductName,
                  Price=f.ProductPrice,
                  //ImageURL = f.ProductImages
              }).ToList();
            var items1 = products1
              .Select(f => new FewFields
              {                 
                  ImageURL = f.ProductImageUrl
              }).ToList();
            //var merger = TypeMerger.MergeTypes(items, items1);
            //var merger = ObjectMerger.MergeObjects(items, items1);
            return items;
        }

        [Route("SortingWithImageURL")]
        [HttpGet]
        public object sortingWithImageURL(string SubType, string sortOrder)
        {
            var products = DB.ProductTables.Where(s => s.ProductSubType.Contains(SubType) || SubType == null).ToList().Take(10);

            switch (sortOrder)
            {
                case "Z2A":
                    products = products.OrderByDescending(s => s.ProductName);
                    break;
                case "A2Z":
                    products = products.OrderBy(s => s.ProductName);
                    break;
                case "H2L":
                    products = products.OrderByDescending(s => s.ProductPrice);
                    break;
                case "L2H":
                    products = products.OrderBy(s => s.ProductPrice);
                    break;
                case "BS":
                    products = products.OrderBy(s => s.ProductPrice);
                    break;
                default:
                    products = products.OrderBy(s => s.ProductName);
                    break;
            }
            //var obj = DB.ProductTables.Where(x => x.ProductId == SellerRegId).ToList();

            List<string> roleNames = (from UM in products
                                     join UR in DB.ProductImages on UM.ProductId equals UR.ProductId
                                      select UR.ProductImageUrl).ToList();


            //var items = products
            //  .Select(f => new FewFields
            //  {
            //      ImageURL = f.ProductImageUrl
            //  }).ToList();
            //var merger = TypeMerger.MergeTypes(items, items1);
            //var merger = ObjectMerger.MergeObjects(items, items1);
            return roleNames;
        }

        //Function for querying search
        [Route("Searching")]
        [HttpGet]
        public object search(string search)
        {
            var product = DB.ProductTables.Where(s => s.ProductName.Contains(search) || search == null).ToList().Take(10);
            var items = product
              .Select(f => new OnlyName
              {
                  Name = f.ProductName
              }).ToList();
            return items;
            //return (DB.Registers.Where(s => s.Name.StartsWith(search) || search == null).ToList().Take(10));
            //return (DB.Registers.Where(s => s.Name.Contains(search) || search == null).ToList().Take(10));
        }

        [Route("AddProductImage")]
        [HttpPost]
        public object AddProductImage(ProductImage Reg)
        {
            try
            {
                ProductImage EL = new ProductImage();

                if (EL.ProductImageId == 0)
                {                   
                    EL.ProductId = Reg.ProductId;
                    EL.ProductImageUrl = Reg.ProductImageUrl;
                    EL.ImageCaption = Reg.ImageCaption;                   
                    DB.ProductImages.Add(EL);
                    DB.SaveChanges();
                    return new Response
                    { Status = "Success", Message = "Product images added successfully." };
                }
            }
            catch (Exception)
            {
                return new Response
                { Status = "Failure", Message = "Product already added." };
                //throw;
            }
            return new Response
            { Status = "Error", Message = "Invalid Data." };
        }

        [Route("UpdateProductImageDetails")]
        [HttpPost]
        public object UpdateProductImage(ProductImage Reg)
        {
            try
            {
                if (Reg.ProductImageId != 0)
                {
                    var EL = DB.ProductImages.Where(x => x.ProductImageId == Reg.ProductImageId).ToList().FirstOrDefault();
                    if (EL.ProductImageId > 0)
                    {
                        EL.ProductId = Reg.ProductId;
                        EL.ProductImageUrl = Reg.ProductImageUrl;
                        EL.ImageCaption = Reg.ImageCaption;
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
                { Status = "Failure", Message = "Product image not found." };
            }
            return new Response
            { Status = "Error", Message = "Image not found." };
        }

        //[Route("GetAllProductImageDetails")]
        //[HttpGet]
        //public object GetAllProductImageDetails()
        //{
        //    List<string> roleNames = (from UM in DB.ProductTables
        //                              join UR in DB.ProductImages on UM.ProductId equals UR.ProductId
        //                              select UR.ProductImageUrl).ToList();

        //    //var a = DB.ProductTables.ToList();

        //    return roleNames;
        //}

        //[Route("GetProductDetailsById")]
        //[HttpGet]
        //public object GetProductDetailsById(int SellerRegId)
        //{
        //    var obj = DB.ProductTables.Where(x => x.SellerId == SellerRegId).ToList();
        //    return obj;
        //}

        [Route("GetProductImageDetailsByProductId")]
        [HttpGet]
        public object GetProductImageDetailsByProductId(int ProductId)
        {
            var obj = DB.ProductImages.Where(x => x.ProductId == ProductId).ToList();
            return obj;
        }

        [Route("DeleteProductImage")]
        [HttpDelete]
        public object DeleteProductImage(int ProductImageId)
        {
            var obj = DB.ProductImages.Where(x => x.ProductImageId == ProductImageId).ToList().FirstOrDefault();
            DB.ProductImages.Remove(obj);
            DB.SaveChanges();
            return new Response
            {
                Status = "Delete",
                Message = "Record Deleted Successfully"
            };
        }         
    }
}
