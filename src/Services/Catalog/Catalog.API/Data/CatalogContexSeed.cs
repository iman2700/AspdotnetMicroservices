using Catalog.API.Entities;
using MongoDB.Driver;

namespace Catalog.API.Data
{
    public class CatalogContexSeed
    {
        public static void SeedData(IMongoCollection<Product> productCollection)
        {
            bool existProducts = productCollection.Find(p => true).Any();
            if (!existProducts)
            {
                productCollection.InsertManyAsync(GetPreconfiguredProducts());
            }
        }
        public static IEnumerable<Product> GetPreconfiguredProducts()
        {
            return new List<Product>() {
                new Product()
                {
                    Id="3045843oieurerwe34",
                    Name="iphone",
                    Summery="sfkdjf sdfkjsdlf",
                    Description="long state sd",
                    ImageFilr="product",
                    Price = 1234.1,
                    Category="smart phone"

                }
            };
        } 
    }
}