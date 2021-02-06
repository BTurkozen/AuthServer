using AuthServer.Core.Configuration;
using AuthServer.Core.DTOs;
using AuthServer.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace AuthServer.Core.Services
{
  public  interface ITokenService
    {
        TokenDTO CreateToken(UserApp userApp);

        ClientTokenDTO CreateTokenByClient(Client client);
    }
}
