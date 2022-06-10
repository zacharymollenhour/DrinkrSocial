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
    public class TavernHappyHourConfiguration : IEntityTypeConfiguration<TavernHappyHours>
    {
        public void Configure(EntityTypeBuilder<TavernHappyHours> builder)
        {
            
            const string DefaultTavernId = "6e5d8fa8-fa96-419f-9c07-3e05b96b087e";

            builder.HasData(
                new TavernHappyHours
                {
                    Id = Guid.Parse("D7B563D0-1900-4E96-87B8-1040A9A606E1"),
                    TavernId = Guid.Parse(DefaultTavernId),
                    StartTime = "8:00 A.M",
                    EndTime = "12:00 P.M"
                });
        }
    }
}
