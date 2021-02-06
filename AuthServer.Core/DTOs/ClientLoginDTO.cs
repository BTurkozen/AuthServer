using System;
using System.Collections.Generic;
using System.Text;

namespace AuthServer.Core.DTOs
{
   public class ClientLoginDTO
    {
        public string ClientId { get; set; }
        public string ClientSecret { get; set; }

    }
}
