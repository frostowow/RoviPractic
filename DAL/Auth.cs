﻿using System;
using RoviPractic.DAL.Models;
using System.Linq;
using Npgsql;
using Dapper;

namespace RoviPractic.DAL

{
    public class AuthDAL : IAuthDAL
    {
        public async Task<UserModel> GetUser(string email)
        {
            var result = await DbHelper.QueryAsync<UserModel>(@"
                    select UserId, Email, Password, Salt, Status
                    from AppUser
                    where Email = @email", new { email = email });
            return result.FirstOrDefault() ?? new UserModel();
        }

        public async Task<UserModel> GetUser(int id)
        {
            var result = await DbHelper.QueryAsync<UserModel>(@"
                        select UserId, Email, Password, Salt, Status
                        from AppUser
                        where UserId = @id", new { id = id });
            return result.FirstOrDefault() ?? new UserModel();
        }

        public async Task<int> CreateUser(UserModel model)
        {
            string sql = @"insert into AppUser(Email, Password, Salt, Status)
                    values(@Email, @Password, @Salt, @Status) returning UserId";
            return await DbHelper.QueryScalarAsync<int>(sql, model);
        }

        public async Task<IEnumerable<AppRoleModel>> GetRoles(int appUserId)
        {
            return await DbHelper.QueryAsync<AppRoleModel>(@"
                    select ar.AppRoleId, ar.Abbreviation, ar.RoleName
                    from AppRole ar
	                    join AppUserAppRole au on au.AppRoleId = ar.AppRoleId
                    where au.AppUserId = @appUserId
                ", new { appUserId = appUserId });
        }
    }
}
