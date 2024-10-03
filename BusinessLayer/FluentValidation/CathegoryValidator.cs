using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.FluentValidation
{
    public class CathegoryValidator : AbstractValidator<Cathegory>
    {
        public CathegoryValidator()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("Cathegory name can not to be empty");
            RuleFor(x => x.Name).MinimumLength(3).WithMessage("Cathegory name have to be contain minumum 3 characters");
        }
    }
}
