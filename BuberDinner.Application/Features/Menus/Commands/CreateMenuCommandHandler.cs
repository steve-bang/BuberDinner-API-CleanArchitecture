using BuberDinner.Application.Common.Intefaces.Persistence;
using BuberDinner.Domain.Host.ValueObjects;
using BuberDinner.Domain.Menu;
using BuberDinner.Domain.Menu.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuberDinner.Application.Features.Menus.Commands
{
    public class CreateMenuCommandHandler : IRequestHandler<CreateMenuCommand, Menu>
    {
        private readonly IMenuRepository _menuRepository;

        public CreateMenuCommandHandler(IMenuRepository menuRepository)
        {
            _menuRepository = menuRepository;
        }

        public async Task<Menu> Handle(CreateMenuCommand request, CancellationToken cancellationToken)
        {
            await Task.CompletedTask;

            // Create a new menu
            Menu menu = Menu.Create(
                hostId: HostId.Create(request.HostId),
                name: request.Name,
                description: request.Description,
                sections: request.Sections.ConvertAll(section => 
                    MenuSection.Create(
                        name: section.Name,
                        description: section.Description,
                        items: section.Items.ConvertAll(item =>
                            MenuItem.Create(
                                name: item.Name,
                                description: item.Description
                            )
                    )
                )));


            // Persist the menu

            _menuRepository.Add(menu);

            // Return the menu

            return menu;
        }
    }

}
