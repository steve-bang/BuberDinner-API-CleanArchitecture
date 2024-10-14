using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using BuberDinner.Domain.Menu;

namespace BuberDinner.Application.Features.Menus.Commands
{
    public record CreateMenuCommand(
        string HostId,
        string Name,
        string Description,
        List<MenuSectionCommand> Sections
    ) : IRequest<Menu>;

    public record MenuSectionCommand(
        string Name,
        string Description,
        List<MenuItemCommand> Items
    );

    public record MenuItemCommand(
        string Name,
        string Description
    );
}
