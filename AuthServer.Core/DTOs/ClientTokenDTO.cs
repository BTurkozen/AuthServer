using System;
using System.Collections.Generic;
using System.Text;

namespace AuthServer.Core.DTOs
{
   public class ClientTokenDTO
    {
        public string AccessToken { get; set; }
        public DateTime AccessTokenExpiration { get; set; }
    }
}
