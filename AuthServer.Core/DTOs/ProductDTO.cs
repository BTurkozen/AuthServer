using System;
using System.Collections.Generic;
using System.Text;

namespace AuthServer.Core.DTOs
{
   public class ProductDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int Stoct { get; set; }
        public string UserId { get; set; }
    }
}
