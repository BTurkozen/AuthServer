﻿using System;
using System.Collections.Generic;
using System.Text;

namespace AuthServer.Core.DTOs
{
   public class UserAppDTO
    {
        public string Id { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string City { get; set; }

    }
}
