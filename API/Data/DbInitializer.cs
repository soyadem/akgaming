using API.Entities;
using Microsoft.EntityFrameworkCore;

namespace API.Data;

public class DbInitializer
{
    public static void InitDb(WebApplication app)
    {
        using var scope = app.Services.CreateScope();

        var context = scope.ServiceProvider.GetRequiredService<StoreContext>()
        ?? throw new InvalidOperationException("Failed to retrieve store context");

        SeedData(context);
    }

    private static void SeedData(StoreContext context)
    {
        context.Database.Migrate();

        if (context.Products.Any()) return;

        var products = new List<Product>
        {
                   new()
                {
                    Name = "Valorant",
                    Description = "Valorant is a tactical 5v5 shooter where players use unique agent abilities and precise gunplay to win objective-based rounds.",
                    Price = 349,
                    PictureUrl = "/images/products/sb-ang1.png",
                    Type = "Action, FPS, Teamgame.",
                    QuantityInStock = 50
                },
                new()
                {
                    Name = "Bloodborne",
                    Description = "Bloodborne is a gothic action RPG where you battle nightmarish creatures in a plague-ridden city, uncovering dark, cosmic secrets.",
                    Price = 119,
                    PictureUrl = "/images/products/sb-ang2.png",
                    Type = "Action, Rolegame",
                    QuantityInStock = 50
                },
                new()
                {
                    Name = "The Last of Us Part II Remastered",
                    Description = "The Last of Us Part II Remastered is an enhanced version of the post-apocalyptic action-adventure game, featuring improved graphics, new gameplay modes, and behind-the-scenes content.",
                    Price = 249,
                    PictureUrl = "/images/products/sb-core1.png",
                    Type = "Experience, Action",
                    QuantityInStock = 70
                },
                new() 
                {
                    Name = "Black Myth: Wukong",
                    Description = "Black Myth: Wukong is an action RPG inspired by Chinese mythology, where you play as the Monkey King battling legendary foes with dynamic combat and stunning visuals.",
                    Price = 449,
                    PictureUrl = "/images/products/sb-core2.png",
                    Type = "Rolegame, Experience, Action",
                    QuantityInStock = 100
                },
                new() 
                {
                    Name = "Sifu",
                    Description = "Sifu is a stylish action brawler where you play a kung fu student seeking revenge, aging with each defeat as you master combat and timing.",
                    Price = 199,
                    PictureUrl = "/images/products/sb-react1.png",
                    Type = "Action, Beat 'Em Up",
                    QuantityInStock = 30
                },
                new() 
                {
                    Name = "Clair Obscur: Expedition 33",
                    Description = "Clair Obscur: Expedition 33 is a dark fantasy RPG set in a Belle Époque-inspired world, blending turn-based and real-time combat as players fight to stop a mysterious entity erasing people from existence.",
                    Price = 349,
                    PictureUrl = "/images/products/sb-ts1.png",
                    Type = "Rolegame, Fantasy",
                    QuantityInStock = 100
                },
                new() 
                {
                    Name = "The Elder Scrolls IV: Oblivion Remastered",
                    Description = "The Elder Scrolls IV: Oblivion Remastered is a 2025 update of the classic RPG, featuring enhanced visuals, improved combat, and all original DLCs set in the vast world of Cyrodiil.",
                    Price = 299,
                    PictureUrl = "/images/products/hat-core1.png",
                    Type = "Rolegame, Fantasi",
                    QuantityInStock = 100
                },
                new() 
                {
                    Name = "Forza Horizon 5",
                    Description =
                        "Forza Horizon 5 is an open-world racing game set in vibrant Mexico, where players explore diverse landscapes, complete races, and enjoy mini-campaigns celebrating local culture.",
                    Price = 499,
                    PictureUrl = "/images/products/hat-react1.png",
                    Type = "Racing, Action, Adventure",
                    QuantityInStock = 100
                }
        };

        context.Products.AddRange(products);

        context.SaveChanges();
    }
}

