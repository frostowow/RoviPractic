using System;
using RoviPractic.DAL.Models;

namespace RoviPractic.DAL
{
	public interface IUserTokenDAL
	{
        Task<Guid> Create(int userId);

        Task<int?> Get(Guid tokenid);
    }
}

