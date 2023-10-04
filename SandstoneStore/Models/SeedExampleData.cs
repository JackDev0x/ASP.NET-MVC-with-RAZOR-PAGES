using Microsoft.EntityFrameworkCore;
using SandstoneStore.Models;

namespace SportsStore.Models
{
    public static class SeedExampleData
    {
        public static void EnsurePopulated(IApplicationBuilder app)
        {
            StoreDbContext context = app.ApplicationServices
                .CreateScope().ServiceProvider.GetRequiredService<StoreDbContext>();
            if (context.Database.GetPendingMigrations().Any())
            {
                context.Database.Migrate();
            }
            if (!context.Products.Any())
            {
                context.Products.AddRange(
                    new Product
                    {
                        Name = "Quartz Sandstone",
                        Description = "The most common type of sandstone, composed mainly of quartz grains. Shades of yellow, brown, gray, or red.",
                        Category = "Sedimentary",
                        Price = 275
                    },
            new Product
            {
                Name = "Arkose Sandstone",
                Description = "Contains both quartz grains and other minerals such as shales and feldspars. Shades of yellow, red, brown, or purple.",
                Category = "Arenaceous",
                Price = 48.95m
            },
            new Product
            {
                Name = "Shale Sandstone",
                Description = "Contains large amounts of shale minerals, giving it a unique structure and color, often appearing in shades of blue, gray, and black.",
                Category = "Sedimentary",
                Price = 19.50m
            },
            new Product
            {
                Name = "Flag Sandstone",
                Description = "Sandstone easily cleavable into thin slabs, making it an ideal material for paving sidewalks, terraces, and paths.",
                Category = "Arenaceous",
                Price = 34.95m
            },
            new Product
            {
                Name = "Basalt Sandstone",
                Description = "Dark-colored sandstone, often in shades of gray and black. More resistant to pressure and weathering than some other types of sandstone.",
                Category = "Sedimentary",
                Price = 79500
            },
            new Product
            {
                Name = "Gypsum Sandstone",
                Description = "Sandstone containing gypsum mineral, giving it a distinctive white or pink color.",
                Category = "Arenaceous",
                Price = 16
            },
            new Product
            {
                Name = "Conglomerate Sandstone",
                Description = "Sandstone containing grains of various rocks or stones that have been cemented together by natural cement. Forms distinctive patterns on the surface.",
                Category = "Sedimentary",
                Price = 29.95m
            }
                );
                context.SaveChanges();
            }
        }
    }
}
