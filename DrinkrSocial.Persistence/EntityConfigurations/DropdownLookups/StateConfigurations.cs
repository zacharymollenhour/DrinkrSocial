using DrinkrSocial.Domain.Entities.Models.DropdownLookups;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrinkrSocial.Persistence.EntityConfigurations.DropdownLookups
{
    public class StateConfigurations : IEntityTypeConfiguration<State>
    {
        public void Configure(EntityTypeBuilder<State> builder)
        {
            const string DefaultStateId = "122919D2-4235-4764-B995-409C64353208";

            builder.Property(u => u.StateNameEN)
                .IsRequired();

            builder.HasData(
                new State
                {
                    Id = Guid.Parse(DefaultStateId),
                    StateNameEN = "Iowa",
                    StateNameES = "Iowa"
                }
            );
        }
    }
}
