using DrinkrSocial.Domain.Entities.Models.Calendar;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrinkrSocial.Persistence.EntityConfigurations.Calendar
{
    public class DayOfWeekConfiguration : IEntityTypeConfiguration<DayInWeek>
    {
        public void Configure(EntityTypeBuilder<DayInWeek> builder)
        {
            const string MondayGuid = "B372A17B-1D6A-4944-BD40-1A077A303ACD";
            const string TuesdayGuid = "721E9A99-B783-4DDE-95FD-EE1BAABD7F1C";
            const string WednesdayGuid = "1C326E9E-7A39-4C89-A755-DBE2DC63A428";
            const string ThursdayGuid = "88EA84EB-8858-430D-A076-1C3D5251E0B9";
            const string FridayGuid = "0C6B2C73-D6B0-4F21-BB88-B55004120395";
            const string SaturdayGuid = "38799236-31E9-48E9-AF78-970FC4F2EBF7";
            const string SundayGuid = "4F9BC7B1-FED3-4719-A7A9-E99D1B436202";

            builder.Property(u => u.DayName)
                .IsRequired();

            builder.HasData(
                // Monday
                new DayInWeek
                {
                    Id = Guid.Parse(MondayGuid),
                    DayName = "Monday"
                },
                // Tuesday
                new DayInWeek
                {
                    Id = Guid.Parse(TuesdayGuid),
                    DayName = "Tuesday"
                },
                // Wednesday
                new DayInWeek
                {
                    Id = Guid.Parse(WednesdayGuid),
                    DayName = "Wednesday"
                },
                // Thursday
                new DayInWeek
                {
                    Id = Guid.Parse(ThursdayGuid),
                    DayName = "Thursday"
                },
                // Friday
                new DayInWeek
                {
                    Id = Guid.Parse(FridayGuid),
                    DayName = "Friday"
                },
                // Saturday
                new DayInWeek
                {
                    Id = Guid.Parse(SaturdayGuid),
                    DayName = "Saturday"
                },
                // Sunday
                new DayInWeek
                {
                    Id = Guid.Parse(SundayGuid),
                    DayName = "Sunday"
                }
            );
        }

        
    }
}
