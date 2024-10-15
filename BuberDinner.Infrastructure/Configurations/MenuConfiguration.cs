using BuberDinner.Domain.Host.ValueObjects;
using BuberDinner.Domain.Menu;
using BuberDinner.Domain.Menu.Entities;
using BuberDinner.Domain.Menu.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuberDinner.Infrastructure.Configurations
{
    public class MenuConfiguration : IEntityTypeConfiguration<Menu>
    {
        public void Configure(EntityTypeBuilder<Menu> builder)
        {
            ConfigureMenusTable(builder);

            ConfigureMenuSectionsTable(builder);

            ConfigureMenuDinnerIdsTable(builder);

            ConfigureMenuReviewIdsTable(builder);
        }

        private static void ConfigureMenusTable(EntityTypeBuilder<Menu> builder)
        {
            builder.ToTable("Menus");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id) // Configure the property
                .ValueGeneratedNever() // Never generate a value for this property
                .HasConversion(
                    id => id.Value,
                    value => MenuId.Create(value)
                ); // Convert the value to the type of the property

            builder.Property(x => x.Name)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(x => x.Description)
                .IsRequired()
                .HasMaxLength(500);

            builder.Property(x => x.AverageRating)
                .IsRequired()
                .HasDefaultValue(0);


            builder.Property(x => x.HostId)
            .HasConversion(
                id => id.Value,
                value => HostId.Create(value)
            );

            builder.Property(x => x.CreatedDateTime)
                .HasColumnName("CreatedDateTime");

            builder.Property(x => x.UpdatedDateTime)
                .HasColumnName("UpdatedDateTime");
        }

        private static void ConfigureMenuSectionsTable(EntityTypeBuilder<Menu> builder)
        {
            builder.OwnsMany(menu => menu.Sections,
                sb =>
                {
                    sb.ToTable("MenuSections");

                    sb.HasKey("Id", "MenuId");

                    sb.WithOwner().HasForeignKey("MenuId");

                    sb.Property(s => s.Id)
                    .HasColumnName("MenuSectionId")
                    .ValueGeneratedNever()
                    .HasConversion(
                        id => id.Value,
                        value => MenuSectionId.Create(value)
                     );

                    sb.Property(x => x.Name)
                    .IsRequired()
                    .HasMaxLength(100);

                    sb.Property(x => x.Description)
                        .IsRequired()
                        .HasMaxLength(500);

                    // Configure the Items

                    sb.OwnsMany(section => section.Items,
                        ib =>
                        {
                            ib.ToTable("MenuItems");

                            ib.WithOwner().HasForeignKey("MenuSectionId", "MenuId");

                            ib.HasKey(nameof(MenuItem.Id), "MenuSectionId", "MenuId");

                            ib.Property(i => i.Id)
                            .HasColumnName("MenuItemId")
                            .ValueGeneratedNever()
                            .HasConversion(
                                id => id.Value,
                                value => MenuItemId.Create(value)
                             );

                            ib.Property(x => x.Name)
                            .IsRequired()
                            .HasMaxLength(100);

                            ib.Property(x => x.Description)
                                .IsRequired()
                                .HasMaxLength(500);
                            
                        });


                    
                    sb.Navigation(s => s.Items).Metadata.SetField("_items"); 
                    sb.Navigation(s => s.Items).UsePropertyAccessMode(PropertyAccessMode.Field);
                }
            );


            // Configure the navigation with field access, this is required because the navigation is a collection of value objects
            builder.Metadata.FindNavigation(nameof(Menu.Sections))!
                .SetPropertyAccessMode(PropertyAccessMode.Field);
        }

        private static void ConfigureMenuReviewIdsTable(EntityTypeBuilder<Menu> builder)
        {
            builder.OwnsMany(m => m.MenuReviewIds, dib =>
            {
                dib.ToTable("MenuReviewIds");

                dib.WithOwner().HasForeignKey("MenuId");

                dib.HasKey("Id");

                dib.Property(x => x.Value)
                .HasColumnName("ReviewId")
                .ValueGeneratedNever();
            });

            builder.Metadata.FindNavigation(nameof(Menu.MenuReviewIds))!
                .SetPropertyAccessMode(PropertyAccessMode.Field);
        }

        private static void ConfigureMenuDinnerIdsTable(EntityTypeBuilder<Menu> builder)
        {
            builder.OwnsMany(m => m.DinnerIds, dib =>
            {
                dib.ToTable("MenuDinnerIds");

                dib.WithOwner().HasForeignKey("MenuId");

                dib.HasKey("Id");

                // Ensure DinnerId.Value is mapped correctly
                dib.Property(x => x.Value)
                .HasColumnName("DinnerId")
                .ValueGeneratedNever(); // Indicate that this ID is not auto-generated
            });

            // Ensure that EF Core uses field access for the navigation property
            builder.Metadata.FindNavigation(nameof(Menu.DinnerIds))!
                .SetPropertyAccessMode(PropertyAccessMode.Field);
        }
    }

}
