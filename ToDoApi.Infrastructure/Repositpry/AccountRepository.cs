using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using ToDoApi.Domain.Entities;
using ToDoApi.Domain.Interfaces;
using ToDoApi.Infrastructure.Data;

namespace ToDoApi.Infrastructure.Repositpry
{
    public class AccountRepository : IAccountRepository
    {
        private readonly AppDbContext _context;
        private readonly string _telegramToken = "7921489724:AAFgEnfdofhXdpAUFlO5TBAVwFBAE2PV6Uw";

        public AccountRepository(AppDbContext context)
        {
            _context = context;
        }

        public void AddUser(AppUser user)
        {
            _context.Users.Add(user);
        }
        public bool UserIsExist(AppUser user)
        {
            return _context.Users.Any(u => u.Id == user.Id);
        }

        public bool VerifyTelegramInitData(string initData)
        {
            var secretKey = Encoding.UTF8.GetBytes("WebAppData" + _telegramToken);
            using var hmac = new HMACSHA256(secretKey);

            var initDataHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(initData));

            // Validate initData with the expected hash (from Telegram)
            var hash = ExtractHashFromInitData(initData); // Implement this function
            return initDataHash.SequenceEqual(hash);
        }

        public AppUser ParseUserData(string initData)
        {
            var parsedData = System.Web.HttpUtility.ParseQueryString(initData);
            return new AppUser(parsedData["id"], parsedData["first_name"], parsedData["username"]);

        }

        public byte[] ExtractHashFromInitData(string initData)
        {
            var parsedData = System.Web.HttpUtility.ParseQueryString(initData);
            var hashString = parsedData["hash"];
            return Convert.FromBase64String(hashString);
        }
    }

}
