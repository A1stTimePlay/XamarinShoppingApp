using System;
using System.Collections.Generic;
using System.Text;
using FluentValidation;

namespace XamarinShoppingApp.Models
{
    public class validateUser : AbstractValidator<User>
    {
        public validateUser()
        {
            RuleFor(x => x.Username).NotNull().Length(8, 20);
            RuleFor(x => x.Email).NotNull().EmailAddress().WithMessage("Invalid Email.");
            RuleFor(x => x.PASS_WORD).NotNull().Length(8);
          
        }
    }
} 