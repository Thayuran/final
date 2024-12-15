using Entities.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Repository.Configuration
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasData(
                new User
                {
                    Id = "a2bd32c0-d75e-4966-8274-758e273da3fb",
                    UserName = "admin@test.com",
                    NormalizedUserName = "ADMIN@TEST.COM",
                    Email = "admin@test.com",
                    NormalizedEmail = "ADMIN@TEST.COM",
                    EmailConfirmed = true,
                    PasswordHash = new PasswordHasher<User>().HashPassword(null, "Password.123"),
                    SecurityStamp = string.Empty,
                    FirstName = "John",
                    LastName = "Doe"
                },
                 new User
                 {
                     Id = "d7930984-3648-45c8-b33e-7b902e1166b4",
                     UserName = "thayuran1998@gmail.com",
                     NormalizedUserName = "THAYURAN1998@GMAIL.COM",
                     Email = "thayuran1998@gmail.com",
                     NormalizedEmail = "THAYURAN1998@GMAIL.COM",
                     EmailConfirmed = true,
                     PasswordHash = new PasswordHasher<User>().HashPassword(null, "thayu@123"),
                     SecurityStamp = string.Empty,
                     FirstName = "S",
                     LastName = "T"
                 }
           
            );
        }
    }
}
