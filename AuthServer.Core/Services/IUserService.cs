using AppShared.Library.DTOs;
using AuthServer.Core.DTOs;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AuthServer.Core.Services
{
    public interface IUserService
    {
        Task<Response<UserAppDTO>> CreateUserAsync(CreateUserDTO createUserDTO);
        Task<Response<UserAppDTO>> GetUserByNAmeAsync(string userName);

    }
}
