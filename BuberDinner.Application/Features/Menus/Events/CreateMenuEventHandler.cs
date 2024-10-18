using BuberDinner.Domain.Menu.Events;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuberDinner.Application.Features.Menus.Events
{
    public class CreateMenuEventHandler : INotificationHandler<MenuCreatedEvent>
    {
        public Task Handle(MenuCreatedEvent notification, CancellationToken cancellationToken)
        {
            // Handle the event here.
            // Example: Send an email to the user. Notify the user.
            return Task.CompletedTask;
        }
    }
}
