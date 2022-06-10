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
    public class TavernOperatingHourConfiguration : IEntityTypeConfiguration<TavernOperatingHours>
    {
        public void Configure(EntityTypeBuilder<TavernOperatingHours> builder)
        {

            // Tavern Guid For Default
            const string DefaultTavernId = "6e5d8fa8-fa96-419f-9c07-3e05b96b087e";

            // Days Of Week Guids
            const string MondayGuid = "B372A17B-1D6A-4944-BD40-1A077A303ACD";
            const string TuesdayGuid = "721E9A99-B783-4DDE-95FD-EE1BAABD7F1C";
            const string WednesdayGuid = "1C326E9E-7A39-4C89-A755-DBE2DC63A428";
            const string ThursdayGuid = "88EA84EB-8858-430D-A076-1C3D5251E0B9";
            const string FridayGuid = "0C6B2C73-D6B0-4F21-BB88-B55004120395";
            const string SaturdayGuid = "38799236-31E9-48E9-AF78-970FC4F2EBF7";
            const string SundayGuid = "4F9BC7B1-FED3-4719-A7A9-E99D1B436202";

            // Guids for Each Operating Hours Record
            const string MondayOperatingHours = "B1784642-2FA7-41B5-9F3B-6124FB91692F";
            const string TuesdayOperatingHours = "DFE18A72-D95E-4936-9D67-1203FE5A344E";
            const string WednesdayOperatingHours = "56E510D6-4D4B-4596-926D-2F751DCB27B3";
            const string ThursdayOperatingHours = "385D4334-EA67-4887-81DE-B4A7CAA61D94";
            const string FridayOperatingHours = "B7C32DBE-5081-4004-8087-69F9C1101F01";
            const string SaturdayOperatingHours = "68C75036-5AAF-4937-AD54-F36D524E8E32";
            const string SundayOperatingHours = "A9705AF2-48FF-40E1-A688-C61990AB7D86";

            builder.HasKey(u => new { u.DayId, u.OperatingHoursId, u.TavernId });

            builder.HasData(
                // Monday
                new TavernOperatingHours
                {
                    OperatingHoursId = Guid.Parse(MondayOperatingHours),
                    TavernId = Guid.Parse(DefaultTavernId),
                    DayId = Guid.Parse(MondayGuid),
                    OpenTime = "8:00 A.M",
                    CloseTime = "12:00 P.M"
                },
                // Tuesday
                new TavernOperatingHours
                {
                    OperatingHoursId = Guid.Parse(TuesdayOperatingHours),
                    TavernId = Guid.Parse(DefaultTavernId),
                    DayId = Guid.Parse(TuesdayGuid),
                    OpenTime = "8:00 A.M",
                    CloseTime = "12:00 P.M"
                },
                // Wednesday
                new TavernOperatingHours
                {
                    OperatingHoursId = Guid.Parse(WednesdayOperatingHours),
                    TavernId = Guid.Parse(DefaultTavernId),
                    DayId = Guid.Parse(WednesdayGuid),
                    OpenTime = "8:00 A.M",
                    CloseTime = "12:00 P.M"
                },
                // Thursday
                new TavernOperatingHours
                {
                    OperatingHoursId = Guid.Parse(ThursdayOperatingHours),
                    TavernId = Guid.Parse(DefaultTavernId),
                    DayId = Guid.Parse(ThursdayGuid),
                    OpenTime = "8:00 A.M",
                    CloseTime = "12:00 P.M"
                },
                // Friday
                new TavernOperatingHours
                {
                    OperatingHoursId = Guid.Parse(FridayOperatingHours),
                    TavernId = Guid.Parse(DefaultTavernId),
                    DayId = Guid.Parse(FridayGuid),
                    OpenTime = "8:00 A.M",
                    CloseTime = "12:00 P.M"
                },
                // Saturday
                new TavernOperatingHours
                {

                    OperatingHoursId = Guid.Parse(SaturdayOperatingHours),
                    TavernId = Guid.Parse(DefaultTavernId),
                    DayId = Guid.Parse(SaturdayGuid),
                    OpenTime = "8:00 A.M",
                    CloseTime = "12:00 P.M"
                },
                // Sunday
                new TavernOperatingHours
                {
                    OperatingHoursId = Guid.Parse(SundayOperatingHours),
                    TavernId = Guid.Parse(DefaultTavernId),
                    DayId = Guid.Parse(SundayGuid),
                    OpenTime = "8:00 A.M",
                    CloseTime = "12:00 P.M"
                }
                );
        }
    }
}
