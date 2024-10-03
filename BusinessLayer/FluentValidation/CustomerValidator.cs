using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.FluentValidation
{
    public class CustomerValidator : AbstractValidator<Customer>
    {
        public CustomerValidator()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("Customer name can not to be empty");
            RuleFor(x => x.City).NotEmpty().WithMessage("Customer city can not to be empty");
            RuleFor(x => x.Name).MinimumLength(3).WithMessage("Customer name have to be contain minumum 3 characters");
        }
    }
}
