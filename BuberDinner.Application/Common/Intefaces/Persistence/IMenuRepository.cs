using BuberDinner.Domain.Menu;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuberDinner.Application.Common.Intefaces.Persistence
{
    public interface IMenuRepository
    {
        /// <summary>
        /// Add a new menu.
        /// </summary>
        /// <param name="menu">The menu to add.</param>
        void Add(Menu menu);
    }
}
