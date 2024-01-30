using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using ProductWebApi.Application.Models.Product;
using ProductWebApi.Infrastructure.Data.Services.Paging;
using SessionNine.Application.Models;
using SessionNine.Application.Models.Product;
using SessionNine.Domains.Entity;

namespace SessionNine.Application.Mapping
{
    public class ProductMapper : Profile
    {
        public ProductMapper()
        {
            CreateMap<CreateProductOne , Product>();
            CreateMap<Product , ShowProductDto>();
            CreateMap<EditProductModel , Product>();
            CreateMap<ProductFillterDto , PagingParam>();
        }
    }
}