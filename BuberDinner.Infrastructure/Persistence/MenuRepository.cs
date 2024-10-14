using BuberDinner.Application.Common.Intefaces.Persistence;
using BuberDinner.Domain.Menu;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuberDinner.Infrastructure.Persistence
{
    public class MenuRepository : IMenuRepository
    {
        private readonly List<Menu> _menus = new List<Menu>();

        public void Add(Menu menu)
        {
            _menus.Add(menu);
        }
    }
}
