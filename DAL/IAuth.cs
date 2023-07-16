using System;
using RoviPractic.DAL.Models;
namespace RoviPractic.DAL
{
    public interface IAuthDAL
    {
		Task<UserModel> GetUser(string email);
        Task<UserModel> GetUser(int id); 
        Task<int> CreateUser(UserModel model);
    }
}
