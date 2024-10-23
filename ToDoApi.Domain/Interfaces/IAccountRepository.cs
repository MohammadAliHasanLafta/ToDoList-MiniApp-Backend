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
        Task SaveChangesInUsers(string phoneNumber, string otp);
        public Task<long> AddUser(MiniAppUser user);
        public bool UserIsExistById(long userId);
        public WebAppUser GetUserByNumber(string phoneNumber);
        //public bool VerifyTelegramInitData(string initData);
        //public AppUser ParseUserData(string initData);
        //public byte[] ExtractHashFromInitData(string initData);
    }
}
