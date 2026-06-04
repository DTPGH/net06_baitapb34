using Microsoft.EntityFrameworkCore;
using UserApi.Data;

public static class UserSeedData
{
    public static void Seed(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<UserApi.Models.User>().HasData(
            new UserApi.Models.User
            {
                Id = 1,
                Name = "John Doe",
                Email = "john.doe@example.com",
                Description = "A sample user",
                Age = 30,
                CreatedAt = new DateTime(2026, 1, 1),
                UpdatedAt = new DateTime(2026, 1, 1),
                Deleted = false
            },
            new UserApi.Models.User
            {
                Id = 2,
                Name = "Jane Smith",
                Email = "jane.smith@example.com",
                Description = "Another sample user",
                Age = 25,
                CreatedAt = new DateTime(2026, 1, 1),
                UpdatedAt = new DateTime(2026, 1, 1),
                Deleted = false
            },
            new UserApi.Models.User
            {
                Id = 3,
                Name = "Bob Johnson",
                Email = "bob.johnson@example.com",
                Description = "Yet another sample user",
                Age = 35,
                CreatedAt = new DateTime(2026, 1, 1),
                UpdatedAt = new DateTime(2026, 1, 1),
                Deleted = false
            }
        );
    }
}