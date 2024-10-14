using BuberDinner.Domain.Common.Models;
using BuberDinner.Domain.Menu.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuberDinner.Domain.Menu.Entities
{
    public class MenuSection : Entity<MenuSectionId>
    {
        private readonly List<MenuItem> _items = new();

        public string Name { get; private set; }

        public string Description { get; private set; }

        public IReadOnlyCollection<MenuItem> Items => _items.AsReadOnly();

        public MenuSection(MenuSectionId id, string name, string description)
            : base(id)
        {
            Name = name;
            Description = description;
        }

        public void AddItem(MenuItem item)
        {
            _items.Add(item);
        }

        public void RemoveItem(MenuItem item)
        {
            _items.Remove(item);
        }

        public void AddItems(List<MenuItem> items)
        {
            _items.AddRange(items);
        }


        public static MenuSection Create(string name, string description)
        {
            return new MenuSection(
                MenuSectionId.CreateUnique(),
                name,
                description
           );
        }

        public static MenuSection Create(string name, string description, List<MenuItem> items)
        {
            var section = new MenuSection(
                MenuSectionId.CreateUnique(),
                name,
                description
            );

            section.AddItems(items);

            return section;
        }
    }
}
