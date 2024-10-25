using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoApi.Domain.Entities;

namespace ToDoApi.Domain.Interfaces;

public interface ITokenService
{
    string CreateToken(MiniAppUser? miniAppUser, WebAppUser? webAppUser);
}
