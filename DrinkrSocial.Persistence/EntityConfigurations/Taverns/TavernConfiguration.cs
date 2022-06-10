using DrinkrSocial.Domain.Entities.Models.Taverns;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrinkrSocial.Persistence.EntityConfigurations.Taverns
{
    public class TavernConfiguration : IEntityTypeConfiguration<Tavern>
    {
        public void Configure(EntityTypeBuilder<Tavern> builder)
        {
            const string DefaultStateId = "122919D2-4235-4764-B995-409C64353208";
            

            builder.Property(u => u.AddressLine1)
                .HasMaxLength(150)
                .IsRequired();
            builder.Property(u => u.Name)
                .HasMaxLength(100)
                .IsRequired();
            builder.Property(u => u.PostalCode)
                .IsRequired();

            builder.HasKey(u => new { u.StateId });

            

            builder.HasData(
                new Tavern
                {
                    Name = "Zachs Bar",
                    AddressLine1 = "1886 Hansel Drive",
                    City = "Dubuque",
                    PostalCode = "52002",
                    StateId = Guid.Parse(DefaultStateId),
                    Country = "USA",
                    PhoneNumber = "904-553-2614"
                });
        }
    }
}
