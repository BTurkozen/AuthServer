using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace AuthServer.Service
{
    public static class ObjectMapper
    {
        private static readonly Lazy<IMapper> lazy = new Lazy<IMapper>(() =>
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<DtoMapper>();
            });
            return config.CreateMapper();
        });
        /// <summary>
        /// Ne zaman Yukarıdaki kod çalışmaya başlar.
        /// </summary>
        public static IMapper Mapper => lazy.Value; 
    }
}
