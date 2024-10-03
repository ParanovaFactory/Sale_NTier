using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.FluentValidation
{
    public class JobValidator : AbstractValidator<Job>
    {
        public JobValidator() 
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("Job name can not to be empty");
            RuleFor(x => x.Name).MinimumLength(3).WithMessage("Job name have to be contain minumum 3 characters");
        }
    }
}
