
using AutoMapper;
using Customer_Invoice_Payment_Management.BusinessLogic.Services.Abstract;
using Customer_Invoice_Payment_Management.BusinessLogic.Services.BusinessModel;
using Customer_Invoice_Payment_Management.DataLogic.Abstract;
using Customer_Invoice_Payment_Management.DataLogic.DatabaseModel;
using Customer_Invoice_Payment_Management.Model.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace Customer_Invoice_Payment_Management.BusinessLogic.Services.Concrete
{
    public class AuthenticateServices : IAuthenticateServices
    {
        private readonly IMapper _imapper;
        private readonly IAuthenticate _Authenticate;
        public AuthenticateServices(IMapper imapper, IAuthenticate Authenticate)
        {
            _imapper = imapper;
            _Authenticate = Authenticate;
        }

        public Userdata Authenticate(Userdata Model)
        {
            return _imapper.Map<Userdata>(_Authenticate.Authenticate(Model));
        }

        public int Editprofile(user UserModel, string UserName, int UserId)
        {
            return _Authenticate.Editprofile(_imapper.Map<Customer_Invoice_Payment_Management.DataLogic.DatabaseModel.User>(UserModel), UserName, UserId);
        }

        public user GetEditprofileById(int UserId)
        {
            return _imapper.Map<user>(_Authenticate.GetEditprofileById(UserId));
        }

        public List<user> GetLogindetails()
        {
            return _imapper.Map<List<user>>(_Authenticate.GetLogindetails());
        }

        public int Registration(user UserModel, string UserName)
        {
            return _Authenticate.Registration(_imapper.Map<Customer_Invoice_Payment_Management.DataLogic.DatabaseModel.User>(UserModel), UserName);
        }
    }
}


