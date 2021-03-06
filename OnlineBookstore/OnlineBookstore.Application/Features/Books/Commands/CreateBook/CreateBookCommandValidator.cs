using FluentValidation;
using Microsoft.EntityFrameworkCore.Internal;
using OnlineBookstore.Application.Interfaces.Repositories;
using OnlineBookstore.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace OnlineBookstore.Application.Features.Books.Commands.CreateBook
{
    public class CreateBookCommandValidator : AbstractValidator<CreateBookCommand>
    {
        private readonly IBookRepositoryAsync bookRepository;

        public CreateBookCommandValidator(IBookRepositoryAsync bookRepository)
        {
            this.bookRepository = bookRepository;

            RuleFor(p => p.Barcode)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull()
                .MaximumLength(50).WithMessage("{PropertyName} must not exceed 50 characters.")
                .MustAsync(IsUniqueBarcode).WithMessage("{PropertyName} already exists.");

            RuleFor(p => p.Name)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull()
                .MaximumLength(50).WithMessage("{PropertyName} must not exceed 50 characters.");

        }

        private async Task<bool> IsUniqueBarcode(string barcode, CancellationToken cancellationToken)
        {
            return await bookRepository.IsUniqueBarcodeAsync(barcode);
        }
    }
}
