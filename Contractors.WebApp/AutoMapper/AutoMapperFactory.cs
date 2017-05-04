using AutoMapper;
using Contractors.WebApp.Profiles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Contractors.WebApp
{
    public class AutoMapperFactory
    {
        public static IMapper Create()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<ContractorMapperProfile>();
            });

            return config.CreateMapper();
        }
    }
}