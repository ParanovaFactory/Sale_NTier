using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.FluentValidation
{
    public class ProductValidator : AbstractValidator<Product>
    {
        public ProductValidator()
        {
            RuleFor(x=>x.Name).NotEmpty().WithMessage("Product name can not to be empty");
            RuleFor(x=>x.Name).MinimumLength(3).WithMessage("Product name have to be contain minumum 3 characters");
            RuleFor(x=>x.Stock).NotEmpty().WithMessage("Product stock can not to be empty");
            RuleFor(x=>x.Preis).NotEmpty().WithMessage("Product price can not to be empty");
        }
    }
}
