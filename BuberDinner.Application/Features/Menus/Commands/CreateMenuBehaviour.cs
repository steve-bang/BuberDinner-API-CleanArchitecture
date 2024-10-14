using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuberDinner.Application.Features.Menus.Commands
{
    public class CreateMenuBehaviour : AbstractValidator<CreateMenuCommand>
    {
        public CreateMenuBehaviour()
        {
            RuleFor(x => x.Name)
                .NotEmpty()
                .MaximumLength(100)
                .WithMessage("The name must be less than 100 characters");

            RuleFor(x => x.Description)
                .NotEmpty()
                .MaximumLength(500)
                .WithMessage("The description must be less than 500 characters");

            RuleForEach(x => x.Sections)
                .NotEmpty()
                .WithMessage("The menu must have at least one section");

        }
    }
}
