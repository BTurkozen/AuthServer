using AppShared.Library.DTOs;
using AuthServer.Core.DTOs;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AuthServer.Core.Services
{
    public interface IAuthenticationService
    {
        Task<Response<TokenDTO>> CreateTokenAsync(LoginDTO loginDTO);
        Task<Response<TokenDTO>> CreateTokenByRefreshToken(string refreshToken);
        Task<Response<NoDataDTO>> RevokeRefreshToken(string refreshToken);
        Response<ClientTokenDTO> CreateTokenByClient(ClientLoginDTO clientLoginDTO);
    }
}
