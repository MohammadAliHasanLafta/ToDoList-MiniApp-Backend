using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography;
using System.Text;
using Telegram.Bot.Types;
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

        public async Task<long> AddUser(MiniAppUser user)
        {
            _context.MiniAppUsers.AddAsync(user);
            _context.SaveChanges();

            Console.WriteLine("Hello Hello!");
            return user.UserId;
        }

        public async Task SaveChangesInUsers(string phoneNumber, string otp)
        {
            var user = _context.WebAppUsers.SingleOrDefault(u => u.PhoneNumber == phoneNumber);
            if (user == null)
            {
                user = new WebAppUser(phoneNumber, otp);
                await _context.WebAppUsers.AddAsync(user);
            }
            else
            {
                user.Otp = otp;
                _context.WebAppUsers.Update(user);
            }
            await _context.SaveChangesAsync();
        }

        public bool UserIsExistById(long userId)
        {
            return _context.MiniAppUsers.Any(u => u.UserId == userId);
        }

        public WebAppUser GetUserByNumber(string phoneNumber)
        {
            return _context.WebAppUsers.FirstOrDefault(u => u.PhoneNumber == phoneNumber);
        }

        //public bool VerifyTelegramInitData(string initData)
        //{
        //    var secretKey = Encoding.UTF8.GetBytes("WebAppData" + _telegramToken);
        //    using var hmac = new HMACSHA256(secretKey);

        //    var initDataHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(initData));

        //    // Validate initData with the expected hash (from Telegram)
        //    var hash = ExtractHashFromInitData(initData); // Implement this function
        //    return initDataHash.SequenceEqual(hash);
        //}

        //public AppUser ParseUserData(string initData)
        //{
        //    var parsedData = System.Web.HttpUtility.ParseQueryString(initData);
        //    return new AppUser(parsedData["id"], parsedData["first_name"], parsedData["username"]);

        //}

        //public byte[] ExtractHashFromInitData(string initData)
        //{
        //    var parsedData = System.Web.HttpUtility.ParseQueryString(initData);
        //    var hashString = parsedData["hash"];
        //    return Convert.FromBase64String(hashString);
        //}
    }

}
