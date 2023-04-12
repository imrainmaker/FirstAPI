using DAL.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DAL.Context.Config
{
    public class UserConfig : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasCheckConstraint("CK_Email", "[Email] LIKE '%@%.%'");
            builder.HasIndex(u => u.Email).IsUnique();
            builder.HasData(
                            new User
                            {
                                Id = 1,
                                Pseudo = "rains-",
                                Email = "jeremy.bazin@email.com",
                                Password = "Test123=",
                                Role = "admin"
                            },
                            new User
                            {
                                Id = 2,
                                Pseudo = "MidnightWolf",
                                Email = "bob.martin@email.com",
                                Password = "5Gh#zBvKw3PxYrE",
                                Role = "user"
                            },
                            new User
                            {
                                Id = 3,
                                Pseudo = "GalacticNinja",
                                Email = "charlie.nguyen@email.com",
                                Password = "fT7#eRm2QxLz9Dy$",
                                Role = "user"
                            },
                            new User
                            {
                                Id = 4,
                                Pseudo = "DragonSlayer",
                                Email = "david.lee@email.com",
                                Password = "V6b$UwPcNz @hM8xK",
                                Role = "user"
                            },
                            new User
                            {
                                Id = 5,
                                Pseudo = "PixelPrincess",
                                Email = "emma.garcia@email.com",
                                Password = "aH5%kXjL9$qBm2W",
                                Role = "user"
                            },
                            new User
                            {
                                Id = 6,
                                Pseudo = "PhantomGamer",
                                Email = "frank.chen@email.com",
                                Password = "qJ9@fM8cWu5$xLrE",
                                Role = "user"
                            },
                            new User
                            {
                                Id = 7,
                                Pseudo = "ElectricNoodle",
                                Email = "grace.wong@email.com",
                                Password = "7Km&zRb#vGy2hNj",
                                Role = "user"
                            },
                            new User
                            {
                                Id = 8,
                                Pseudo = "MoonlightRider",
                                Email = "henry.zhang@email.com",
                                Password = "T4c#nSv@wGj2RkF",
                                Role = "user"
                            },
                            new User
                            {
                                Id = 9,
                                Pseudo = "GoldenPhoenix",
                                Email = "isabella.lopez@email.com",
                                Password = "H8f$kL3q#sVp9Xy",
                                Role = "user"
                            },
                            new User
                            {
                                Id = 10,
                                Pseudo = "StormChaser",
                                Email = "jack.kim@email.com",
                                Password = "3ZgY*6tLx#pVfDhN",
                                Role = "user"
                            }
                        ); 
        }
    }
    
}
