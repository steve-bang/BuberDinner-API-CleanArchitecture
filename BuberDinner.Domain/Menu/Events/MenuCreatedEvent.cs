using BuberDinner.Domain.Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuberDinner.Domain.Menu.Events
{
    public record MenuCreatedEvent(Menu menu) : IDomainEvent;
}
