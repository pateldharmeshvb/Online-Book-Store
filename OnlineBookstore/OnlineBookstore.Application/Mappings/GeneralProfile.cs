using AutoMapper;
using OnlineBookstore.Application.DTOs.Book;
using OnlineBookstore.Application.Features.Books.Commands.CreateBook;
using OnlineBookstore.Application.Features.Books.Queries.GetAllBook;
using OnlineBookstore.Application.Features.Books.Queries.GetAllBooks;
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
            CreateMap<Book, GetAllBooksViewModel>().ReverseMap();
            CreateMap<CreateBookCommand, Book>();
            CreateMap<GetAllBooksQuery, GetAllBooksParameter>();
        }
    }
}
