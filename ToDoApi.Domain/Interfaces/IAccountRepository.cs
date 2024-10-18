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
        public Task<long> AddUser(AppUser user);
        public bool UserIsExist(long userId);
        //public bool VerifyTelegramInitData(string initData);
        //public AppUser ParseUserData(string initData);
        //public byte[] ExtractHashFromInitData(string initData);
    }
}
