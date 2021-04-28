using GS1US.Framework.DAL.Services.MockRepositories.Interfaces;
using GS1US.Framework.DAL.Services.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using GS1US.Framework.Common.Logging;

namespace GS1US.Framework.DAL.Services.MockRepositories
{
    public class ProductsDataStore : IProductsDataStore
    {
        // A dummy logger to trace things
        private IGS1USAppInsightsLogger Logger { get; }

        public ProductsDataStore(IGS1USAppInsightsLogger logger)
        {   
            this.Logger = logger;
        }

        public static ProductsDataStore Current { get; } = new ProductsDataStore();

        public List<Product> Products { get; set; }

        public List<Product> RegistryProducts { get; set; }

        public async Task<List<Product>> GetProducts()
        {
            await DoWorkAsync();
            return Current.Products;
        }

        public async Task<List<Product>> GetRegistryProducts()
        {
            await DoWorkAsync();
            return Current.RegistryProducts;
        }


        public async Task<Product> GetProductById(int id)
        {
            await DoWorkAsync();
            return Current.Products.Where(p => p.Id == id).FirstOrDefault();
        }

        public async Task<Product> GetRegistryProductById(int id)
        {
            await DoWorkAsync();
            return Current.RegistryProducts.Where(p => p.Id == id).FirstOrDefault();
        }

        public async Task<List<Product>> SearchProducts(SearchCriteria searchCriteria)
        {
            await DoWorkAsync();
            var filteredProducts = new List<Product>();

            foreach (var prop in searchCriteria.GetType().GetProperties())
            {
                var val = prop.GetValue(searchCriteria, null);
                if (val != null && val.GetType() == typeof(string))
                {
                    var tType = val.GetType();
                    filteredProducts = FilterByProperty<string>(filteredProducts, new KeyValuePair<string, string>(prop.Name, val.ToString()), false);
                }
            }
            return filteredProducts;
        }


        public async Task<List<Product>> SearchRegistryProducts(SearchCriteria searchCriteria)
        {
            await DoWorkAsync();
            var filteredProducts = new List<Product>();

            foreach (var prop in searchCriteria.GetType().GetProperties())
            {
                var val = prop.GetValue(searchCriteria, null);
                if (val != null && val.GetType() == typeof(string))
                {
                    var tType = val.GetType();
                    filteredProducts = FilterByProperty<string>(filteredProducts, new KeyValuePair<string, string>(prop.Name, val.ToString()), true);
                }
            }
            return filteredProducts;
        }

        public ProductsDataStore()
        {
            // init dummy data
            Products = new List<Product>()
            {
                new Product()
                {
                    Id = 1,
                    Category = "Business Services",
                    Shared = false,
                    Description = "Aut nesciunt blanditiis nihil et distinctio magni voluptas placeat sapiente.",
                    Gtin = "00007260484776",
                    LastUpdatedDate = DateTime.Parse("09/20/2020"),
                    License = new ProductLicense() {
                        BrandName = "Awesome Concrete Hello",
                        Company = "Considine - Jast",
                        CompanyPrefix = "0138299",
                        CountryCode = "Chad"
                    },
                    Name = "Awesome Concrete Bacon - Hello World 2",
                    PackagingLevel = "Mixed Pallet",
                    Sku = "82817",
                    Status = "Inactive",
                    CreatedDate = DateTime.Parse("12/01/1991")
                },
                new Product()    {
                        Id = 2,
                        Category = "Computer Software",
                        Shared = false,
                        Description = "Veritatis quisquam deserunt dolorum.",
                        Gtin = "00009329736388",
                        LastUpdatedDate = DateTime.Parse("12/21/2019"),
                       License = new ProductLicense() {
                            BrandName = "Awesome Concrete",
                            Company = "Will - Feil",
                            CompanyPrefix = "0347512",
                            CountryCode = "Egypt"
                        },
                        Name = "Awesome Concrete Bike",
                        PackagingLevel = "Case",
                        Sku = "25377",
                        Status = "Pre-Market",
                        CreatedDate = DateTime.Parse("12/01/2017")
                    },
                new Product()    {
                    Id = 3,
                    Category = "Construction",
                    Shared = false,
                    Description = "In ex dolorem consequatur atque aut cupiditate rerum deleniti.",
                    Gtin = "00003776082624",
                    LastUpdatedDate = DateTime.Parse("01/27/2020"),
                    License = new ProductLicense() {
                        BrandName = "Awesome Concrete",
                        Company = "Christiansen - Bogan",
                        CompanyPrefix = "0305131",
                        CountryCode = "Costa Rica"
                    },
                    Name = "Awesome Concrete Chips",
                    PackagingLevel = "Mixed Pallet",
                    Sku = "33105",
                    Status = "Pre-Market",
                    CreatedDate = DateTime.Parse("09/15/2011")
            },
            new Product() {
                Id = 4,
                Category = "Bars & Restaurants",
                Shared = false,
                Description = "Eius sunt neque temporibus quo quae quia rem.",
                Gtin = "00003513888034",
                LastUpdatedDate = DateTime.Parse("04/12/2020"),
               License = new ProductLicense() {
                    BrandName = "Awesome Concrete",
                    Company = "Dooley and Sons",
                    CompanyPrefix = "0973747",
                    CountryCode = "Croatia"
                },
                Name = "Awesome Concrete Computer",
                PackagingLevel = "Case as Each",
                Sku = "58501",
                Status = "Archived",
                CreatedDate = DateTime.Parse("04/12/2020")
            },
            new Product()    {
                Id = 5,
                Category = "Health",
                Shared = false,
                Description = "Reprehenderit in id omnis repudiandae ab commodi quidem doloribus dolorem.",
                Gtin = "00008777385741",
                LastUpdatedDate = DateTime.Parse("09/03/2020"),
                License = new ProductLicense() {
                    BrandName = "Awesome Concrete",
                    Company = "Abernathy, Mertz and Toy",
                    CompanyPrefix = "0532287",
                    CountryCode = "Palestinian Territory"
                },
                Name = "Awesome Concrete Fish",
                PackagingLevel = "Inner Pack",
                Sku = "13942",
                Status = "In Use",
                CreatedDate = DateTime.Parse("09/03/2020")
            }
            };

            RegistryProducts = new List<Product>()
            {
                new Product()
                {
                    Id = 1,
                    Category = "Business Services",
                    Shared = false,
                    Description = "Aut nesciunt blanditiis nihil et distinctio magni voluptas placeat sapiente.",
                    Gtin = "00007260484776",
                    LastUpdatedDate = DateTime.Parse("09/20/2020"),
                    License = new ProductLicense() {
                        BrandName = "Awesome Global Concrete Hello",
                        Company = "Considine - Jast",
                        CompanyPrefix = "0138299",
                        CountryCode = "Chad"
                    },
                    Name = "Awesome Concrete Bacon - Hello Global World",
                    PackagingLevel = "Mixed Pallet",
                    Sku = "82817",
                    Status = "Inactive",
                    CreatedDate = DateTime.Parse("12/01/1991")
                },
                new Product()    {
                        Id = 2,
                        Category = "Computer Software",
                        Shared = false,
                        Description = "Veritatis quisquam deserunt dolorum.",
                        Gtin = "00009329736388",
                        LastUpdatedDate = DateTime.Parse("12/21/2019"),
                        License = new ProductLicense() {
                            BrandName = "Awesome Global Concrete",
                            Company = "Will - Feil",
                            CompanyPrefix = "0347512",
                            CountryCode = "Egypt"
                        },
                        Name = "Awesome Global Concrete Bike",
                        PackagingLevel = "Case",
                        Sku = "25377",
                        Status = "Pre-Market",
                        CreatedDate = DateTime.Parse("12/01/2017")
                    },
                new Product()    {
                    Id = 3,
                    Category = "Construction",
                    Shared = false,
                    Description = "In ex dolorem consequatur atque aut cupiditate rerum deleniti.",
                    Gtin = "00003776082624",
                    LastUpdatedDate = DateTime.Parse("01/27/2020"),
                   License = new ProductLicense() {
                        BrandName = "Awesome Global Concrete",
                        Company = "Christiansen - Bogan",
                        CompanyPrefix = "0305131",
                        CountryCode = "Costa Rica"
                    },
                    Name = "Awesome Global Concrete Chips",
                    PackagingLevel = "Mixed Pallet",
                    Sku = "33105",
                    Status = "Pre-Market",
                    CreatedDate = DateTime.Parse("09/15/2011")
            },
            new Product()    {
                Id = 4,
                Category = "Bars & Restaurants",
                Shared = false,
                Description = "Eius sunt neque temporibus quo quae quia rem.",
                Gtin = "00003513888034",
                LastUpdatedDate = DateTime.Parse("04/12/2020"),
               License = new ProductLicense() {
                    BrandName = "Awesome Global Concrete",
                    Company = "Dooley and Sons",
                    CompanyPrefix = "0973747",
                    CountryCode = "Croatia"
                },
                Name = "Awesome Global Concrete Computer",
                PackagingLevel = "Case as Each",
                Sku = "58501",
                Status = "Archived",
                CreatedDate = DateTime.Parse("04/12/2020")
            },
            new Product()    {
                Id = 5,
                Category = "Health",
                Shared = false,
                Description = "Reprehenderit in id omnis repudiandae ab commodi quidem doloribus dolorem.",
                Gtin = "00008777385741",
                LastUpdatedDate = DateTime.Parse("09/03/2020"),
                License = new ProductLicense() {
                    BrandName = "Awesome Global Concrete",
                    Company = "Abernathy, Mertz and Toy",
                    CompanyPrefix = "0532287",
                    CountryCode = "Palestinian Territory"
                },
                Name = "Awesome Global Concrete Fish",
                PackagingLevel = "Inner Pack",
                Sku = "13942",
                Status = "In Use",
                CreatedDate = DateTime.Parse("09/03/2020")
            }
            };

        }
        
        /// <summary>
        /// Filter records based on tuple of property/value
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="filteredList">List of Products that already found on other attributes, Only support an OR condition.</param>
        /// <param name="search"></param>
        /// <param name="isRegistry">Determines which source to filter on.</param>
        /// <returns>Cummulative list of Products found.</returns>
        private List<Product> FilterByProperty<T>(List<Product> filteredList, KeyValuePair<string, string> search, bool isRegistry)
        {
            var fProducts = new List<Product>();
            var allProducts = isRegistry ? Current.RegistryProducts : Current.Products;
            try
            {
                // Determinse if the proerty is of Product or sub-License
                if (typeof(ProductLicense).GetProperty(search.Key) != null)
                {
                    // filters on properties of the class Product License
                    fProducts = allProducts.Where(p => p.License.GetType()
                                                                .GetProperty(search.Key)
                                                                .GetValue(p.License, null)
                                                                .ToString()
                                                                .Contains(search.Value, StringComparison.OrdinalIgnoreCase))
                                                                   .ToList();
                }
                else
                {
                    // filters on properties of the class Product
                    fProducts = allProducts.Where(p => p.GetType()
                                                        .GetProperty(search.Key)
                                                        .GetValue(p, null)
                                                        .ToString()
                                                        .Contains(search.Value, StringComparison.OrdinalIgnoreCase))
                                                            .ToList();
                }
            }
            catch (Exception e) 
            {
                this.Logger.Error(e, $"Failed to filter products data on {search.Key} = {search.Value}");
            }

            return filteredList.Except(fProducts).Concat(fProducts.Except(filteredList)).ToList();

        }
        
        /// <summary>
        /// Used to emulate an async process.  This can also be used to add time to the process.
        /// </summary>
        /// <returns></returns>
        private Task<int> DoWorkAsync()
        {
            return Task.Run(() =>
            {
                return 1 + 2;
            });
        }
    }
}
