using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoApi.Domain.Entities;

namespace ToDoApi.Domain.Interfaces
{
    public interface IAccountRepository
    {
        public Task SaveChangesInWebUsers(string phoneNumber, string otp);
        public Task UpdateInMiniUsers(long userId, string contactRequest, string mobile);
        public Task<MiniAppUser> GetUserById(long userId);
        public WebAppUser GetUserByNumber(string phoneNumber);
        public byte[] GenerateHmacSha256(string key, string message);
        public string GenerateHmacSha256(byte[] key, string message);
        public Dictionary<string, string> ParseUrlEncodedData(string encodedData);
        public string GetBotToken();
        public Task SaveChangesAsync();
        public Task AddUserAsync(MiniAppUser user);
    }
}
