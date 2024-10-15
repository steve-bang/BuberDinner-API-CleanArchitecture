using BuberDinner.Domain.Common.Models;
using BuberDinner.Domain.Dinner.ValueObjects;
using BuberDinner.Domain.Host.ValueObjects;
using BuberDinner.Domain.Menu.Entities;
using BuberDinner.Domain.Menu.ValueObjects;
using BuberDinner.Domain.MenuReview.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuberDinner.Domain.Menu
{
    public class Menu : AggregateRoot<MenuId>
    {
        private readonly List<MenuSection> _sections = new();

        private readonly List<DinnerId> _dinnerIds = new();

        private readonly List<MenuReviewId> _menuReviewIds = new();

        public HostId HostId { get; }

        public string Name { get; set; }

        public string Description { get; set; }

        public float AverageRating { get; set; }

        public IReadOnlyList<MenuSection> Sections => _sections.AsReadOnly();

        public IReadOnlyList<DinnerId> DinnerIds => _dinnerIds.AsReadOnly();

        public IReadOnlyList<MenuReviewId> MenuReviewIds => _menuReviewIds.AsReadOnly();

        public DateTime CreatedDateTime { get; }

        public DateTime UpdatedDateTime { get; }

        public Menu(MenuId id, string name, string description, DateTime createdDateTime, DateTime updatedDateTime)
            : base(id)
        {
            Name = name;
            Description = description;
            CreatedDateTime = createdDateTime;
            UpdatedDateTime = updatedDateTime;
        }

        public Menu(MenuId id, HostId hostId, string name, string description, DateTime createdDateTime, DateTime updatedDateTime)
            : base(id)
        {
            HostId = hostId;
            Name = name;
            Description = description;
            CreatedDateTime = createdDateTime;
            UpdatedDateTime = updatedDateTime;
        }

        public static Menu Create( string name, string description)
        {
            return new Menu(
                    MenuId.CreateUnique(),
                    name,
                    description,
                    DateTime.UtcNow,
                    DateTime.UtcNow
            );
        }

        public static Menu Create(HostId hostId,string name, string description, List<MenuSection> sections)
        {
            var menu = new Menu(
                    MenuId.CreateUnique(),
                    hostId,
                    name,
                    description,
                    DateTime.UtcNow,
                    DateTime.UtcNow
            );

            menu.AddSections(sections);

            return menu;
        }

        public void AddSection(MenuSection section)
        {
            _sections.Add(section);
        }

        public void AddSections(List<MenuSection> sections)
        {
            _sections.AddRange(sections);
        }
    }
}
