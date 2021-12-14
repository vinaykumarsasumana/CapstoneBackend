using CoreWebApiJWT.DataContexts;
using CoreWebApiJWT.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreWebApiJWT.Services
{
    public interface IUserService
    {
        ResponseModel<UserModel> Get(long UserId);
    }
    public class UserService : IUserService
    {
        private readonly DemoTokenContexts _context;

        public UserService(DemoTokenContexts context)
        {
            _context = context;
        }
        public ResponseModel<UserModel> Get(long SellerRegId)
        {
            ResponseModel<UserModel> response = new ResponseModel<UserModel>();

            try
            {
                UserModel user = (from UM in _context.SellerRegistrations
                                  where UM.SellerRegId == SellerRegId
                                  select new UserModel
                                  {
                                      SellerRegId = UM.SellerRegId,
                                      FirstName = UM.FirstName,
                                      LastName = UM.LastName,
                                      EmailId = UM.EmailId,
                                      SellerPassword = UM.SellerPassword,
                                      Country = UM.Country,
                                      MobileNo = UM.MobileNo,
                                      SellerAddress = UM.SellerAddress,
                                      CompanyName = UM.CompanyName,
                                      CompanyUrl = UM.CompanyUrl
                                  }).FirstOrDefault();
                List<string> roleNames = (from UM in _context.SellerRegistrations
                                          join UR in _context.SellerRegistrations on UM.SellerRegId equals UR.SellerRegId
                                          join RM in _context.SellerRegistrations on UR.SellerRegId equals RM.SellerRegId
                                          where UM.SellerRegId == SellerRegId
                                          select RM.FirstName).ToList();
                if (user != null)
                {
                    //user.UserRoles = roleNames;
                    response.Data = user;
                    return response;
                }
                else
                {
                    response.IsSuccess = false;
                    response.Message = "User Not Found!";
                    return response;
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
