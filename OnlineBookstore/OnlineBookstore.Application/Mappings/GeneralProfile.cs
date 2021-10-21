using AutoMapper;
using OnlineBookstore.Application.Features.Products.Commands.CreateProduct;
using OnlineBookstore.Application.Features.Products.Queries.GetAllProducts;
using OnlineBookstore.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineBookstore.Application.Mappings
{
    public class GeneralProfile : Profile
    {
        public GeneralProfile()
        {
            CreateMap<Product, GetAllProductsViewModel>().ReverseMap();
            CreateMap<CreateProductCommand, Product>();
            CreateMap<GetAllProductsQuery, GetAllProductsParameter>();
        }
    }
}
