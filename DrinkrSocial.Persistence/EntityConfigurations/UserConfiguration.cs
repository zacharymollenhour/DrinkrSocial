using DrinkrSocial.Application.Helpers;
using DrinkrSocial.Domain.Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrinkrSocial.Persistence.EntityConfigurations
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            const string DefaultAdminUserId = "6e5d8fa8-fa96-419f-9c07-3e05b96b087e";

            builder.Property(u => u.UserName)
                .HasMaxLength(50)
                .IsRequired();
            builder.Property(u => u.FirstName)
                .HasMaxLength(50)
                .IsRequired();
            builder.Property(u => u.LastName)
                .HasMaxLength(50)
                .IsRequired();
            builder.Property(u => u.Email)
                .IsRequired();
            builder.Property(u => u.PasswordHash)
                .IsRequired();
            builder.Property(u => u.PasswordSalt)
                .IsRequired();
            builder.Property(u => u.PostalCode)
                .IsRequired();

            var (passwordHash, passwordSalt) = AuthenticationHelper.CreateHash("159357456qW");

            builder.HasData(
                new User
                {
                    Id = Guid.Parse(DefaultAdminUserId),
                    UserName = "admin",
                    FirstName = "Default",
                    LastName = "Admin",
                    PasswordHash = passwordHash,
                    EmailConfirmed = true,
                    PasswordSalt = passwordSalt,
                    Email = "defaultadmin@gmail.com",
                    PostalCode = "52002"
                });
        }
    }
}
