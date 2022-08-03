using ECommerce.DAL.Entities;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace ECommerce.DAL
{
    public class StoreContextSeed
    {
        public static async Task SeedAsync(StoreContext context, ILoggerFactory loggerFactory)
        {
            try {

                //chaeck if database is empty to input data
                // start with productTypes and productbrands before products as it depends on them
                if (!context.ProductTypes.Any())
                {
                    var typesData = File.ReadAllText("../ECommerce.DAL/Data/SeedsData/types.json");

                    var types = JsonSerializer.Deserialize<List<ProductType>>(typesData);

                    foreach (var type in types)
                        context.ProductTypes.Add(type);

                    await context.SaveChangesAsync();
                }

                ///Brands

                if (!context.ProductBrands.Any())
                {
                    var brandsData = File.ReadAllText("../ECommerce.DAL/Data/SeedsData/brands.json");

                    var brands = JsonSerializer.Deserialize<List<ProductBrand>>(brandsData);

                    foreach (var brand in brands)
                        context.ProductBrands.Add(brand);

                    await context.SaveChangesAsync();
                }


                ///Products

                if (!context.Products.Any())
                {
                    var productsData = File.ReadAllText("../ECommerce.DAL/Data/SeedsData/products.json");

                    var products = JsonSerializer.Deserialize<List<Product>>(productsData);

                    foreach (var product in products)
                        context.Products.Add(product);

                    await context.SaveChangesAsync();
                }

            }
            catch (Exception ex) {
                var logger = loggerFactory.CreateLogger<StoreContextSeed>();
                logger.LogError(ex.Message);
            }
        }
    }
}
