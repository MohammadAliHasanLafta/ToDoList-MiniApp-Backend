using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using Telegram.Bot.Types;
using ToDoApi.Domain.Entities;
using ToDoApi.Domain.Interfaces;
using ToDoApi.Infrastructure.Data;
using static System.Net.WebRequestMethods;

namespace ToDoApi.Infrastructure.Repositpry
{
    public class AccountRepository : IAccountRepository
    {
        private readonly AppDbContext _context;
        private readonly string _eitaaToken = "60315349:4BLmgjuTJR-%94mHOf5GA-blA0nTf12J-T~OWILRsgk-yw6}J5qY9E-KlrW/yG4S*-RmKtx909&p-AVZwLgQl3s-1UI#oJxc!w-8XDWmUF3]{-7SB7RLXMt6-ShC8P*NXEW-p.kJQrIrMQ-laQc,Cj)uF-pFYOIoS";

        public AccountRepository(AppDbContext context)
        {
            _context = context;
        }

        public string GetBotToken()
        {
            return _eitaaToken;
        }

        public async Task SaveChangesAsync()
        {
            _context.SaveChanges();
        }

        public async Task UpdateInMiniUsers(long userId, string contactRequest, string mobile)
        {
            // ابتدا شیء را بدون ردیابی پیدا کنید
            var user = await GetUserById(userId);

            if (user != null)
            {
                //// اتصال شیء به DbContext
                //_context.MiniAppUsers.Attach(user);

                //// اعمال تغییرات
                user.ContactRequest = contactRequest;
                user.Mobile = mobile;
                user.IsValid = true;
                user.UpdatedAt = DateTime.Now;

                //// علامت گذاری شیء به عنوان تغییر یافته
                //_context.Entry(user).State = EntityState.Modified;



                // ذخیره تغییرات
                _context.SaveChanges();
            }
        }

        public async Task AddUserAsync(MiniAppUser user)
        {
            await _context.MiniAppUsers.AddAsync(user);
            await SaveChangesAsync();
        }

        public async Task SaveChangesInWebUsers(string phoneNumber, string otp)
        {
            var user = GetUserByNumber(phoneNumber);
            if (user == null)
            {
                user = new WebAppUser(phoneNumber, otp);
                _context.WebAppUsers.AddAsync(user);
                _context.SaveChangesAsync();
            }
            else
            {
                user.Otp = otp;
                user.UpdatedAt = DateTime.Now;
                _context.SaveChangesAsync();
            }
        }

        public Task<MiniAppUser> GetUserById(long userId)
        {
            return _context.MiniAppUsers.FirstOrDefaultAsync(u => u.UserId == userId);
        }

        public WebAppUser GetUserByNumber(string phoneNumber)
        {
            return _context.WebAppUsers.FirstOrDefault(u => u.PhoneNumber == phoneNumber);
        }

        public byte[] GenerateHmacSha256(string key, string message)
        {
            using (var hmac = new HMACSHA256(Encoding.UTF8.GetBytes(key)))
            {
                return hmac.ComputeHash(Encoding.UTF8.GetBytes(message));
            }
        }

        public string GenerateHmacSha256(byte[] key, string message)
        {
            using (var hmac = new HMACSHA256(key))
            {
                var hash = hmac.ComputeHash(Encoding.UTF8.GetBytes(message));
                return BitConverter.ToString(hash).Replace("-", "").ToLower();
            }
        }

        public Dictionary<string, string> ParseUrlEncodedData(string encodedData)
        {
            var query = HttpUtility.ParseQueryString(encodedData);
            return query.AllKeys.ToDictionary(key => key, key => query[key]);
        }
    }
}
