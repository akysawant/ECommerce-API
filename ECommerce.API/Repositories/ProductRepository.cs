using ECommerce.API.Data;
using ECommerce.API.Interfaces.Repository;
using ECommerce.API.Models;
using ECommerce.API.Services;
using Microsoft.EntityFrameworkCore;

namespace ECommerce.API.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly ECommerceDbContext _context;
        private readonly RequestTracker _tracker;

        public ProductRepository(
            ECommerceDbContext context,
            RequestTracker tracker)
        {
            _context = context;
            _tracker = tracker;
        }

        public async Task<Product> AddAsync(Product product)
        {
            await _context.Products.AddAsync(product);
            await _context.SaveChangesAsync();
            return product;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var existingProduct = await GetByIdAsync(id);

            if (existingProduct == null)
                return false;

            _context.Products.Remove(existingProduct);
            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<IEnumerable<Product>> GetAllAsync()
        {
            return await _context.Products
                          .Include(p => p.Category)
                          .ToListAsync();
        }

        public async Task<Product?> GetByIdAsync(int id)
        {
            return await _context.Products
                                 .Include(p => p.Category)
                                 .FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task<Product?> UpdateAsync(int id, Product product)
        {
            var existingProduct = await GetByIdAsync(id);

            if (existingProduct == null)
                return null;

            existingProduct.Update(
                product.Name,
                product.Price,
                product.Stock,
                product.CategoryId);

            await _context.SaveChangesAsync();
            return existingProduct;                 
        }

        public Guid GetTrackerId()
        {
            return _tracker.Id;
        }

        public async Task PracticeQuery()
        {
            //return product whose id is 5
            var product = _context.Products
                .FirstOrDefault(p => p.Id == 5);

            //check product exist 
            var productExist = _context.Products
                .Any(p => p.Id == 5);

            //count product 
            var count = _context.Products
                .Count(p => p.IsActive);

            //product having price greater than 10,000
            var product2 = _context.Products
                .Where(p => p.Price > 1000)
                .ToList();

            //product between 5000 t0 10000
            var product3 = _context.Products
                .Where(p => p.Price >= 5000 &&
                            p.Price <= 10000)
                .ToList();

            //product whose stock less than 5
            var prodcut4 = _context.Products
                .Where(p => p.Stock < 5)
                .ToList();

            //Active prduct of category 2
            var products5 = _context.Products
                .Where(p => p.IsActive &&
                            p.CategoryId == 2)
                .ToList();

            // search product containing laptop
            var productserch = _context.Products
                .Where(p => p.Name.Contains("laptop"))
                .ToList();

            //sorting top5 expensivve
            var top5products = _context.Products
                .OrderByDescending(p => p.Price)
                .Take(5)
                .ToList();

            //top 3 cheapest product 
            var top3cheapestProducts = _context.Products
                .OrderBy(p => p.Price)
                .Take(3)
                .ToList();

            var products = _context.Products
                .OrderBy(p => p.Name)
                .ToList();

            //sort by stock descending
            var product6 = _context.Products
                .OrderByDescending(p => p.Stock)
                .ToList();

            /// PROJECTION 
            //return only Name and price
            var product7 = _context.Products
                .Select(p => new ProductResponse
                {
                    Name = p.Name,
                    Price = p.Price
                })
                .ToList();

            //return only product name 
            var productNames = _context.Products
                .Select(p => p.Name)
                .ToList();

            //return product Id and CategoryName
            var prodcutCategoryName = _context.Products
                .Select(p => new ProductResponse
                {
                    ProductId = p.Id,
                    CategoryName = p.Category.Name
                })
                .ToList();

            ///PAGINATION
            //page 1, sizw 10
            var productPage = _context.Products
                .OrderBy(p => p.Id)
                .Skip(0)
                .Take(10)
                .ToList();

            //page 3, size 10
            int page = 3;
            int pageSize = 10;

            var productPage2 = _context.Products
                .OrderBy(p => p.Id)
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .ToList();

            ///GROUPING 

            //product count per category
            var productCount = _context.Products
                .GroupBy(p => p.Category.Name)
                .Select(g => new ProductResponse
                {
                    CategoryName = g.Key,
                    Count = g.Count()
                })
                .ToList();

            //average price per category
            var prodctAvgPrice = _context.Products
                .GroupBy(p => p.Category.Name)
                .Select(g => new
                {
                    Category = g.Key,
                    AveragePrice = g.Average(p => p.Price)
                })
                .ToList();

            //Highest price per category
            var highestCategoryProdcut = _context.Products
                .GroupBy(p => p.Category.Name)
                .Select(g => new
                {
                    Category = g.Key,
                    MaxPrice = g.Max(p => p.Price)
                })
                .ToList();

            //duplicate product name 
            var duplicateProductName = _context.Products
                .GroupBy(p => p.Name)
                .Where(g => g.Count() > 1)
                .Select(g => new
                {
                    Name = g.Key,
                    Count = g.Count()
                })
                .ToList();

            ///AGGREGATE

            //Total inventory value
            var total = _context.Products
                .Sum(p => p.Price * p.Stock);

            //most expensive products 
            var expensiveProduct = _context.Products
                .OrderByDescending(p => p.Price)
                .FirstOrDefault();

            //cheapest product 
            var cheapestProduct = _context.Products
                .OrderBy(p => p.Price)
                .FirstOrDefault();

            //totatl stock available
            var stock = _context.Products
                .Sum(p => p.Stock);

            //Duplicate product names 
            var duplicateProducts = _context.Products
                .GroupBy(p => p.Name)
                .Where(g => g.Count() > 1)
                .Select(x => new
                {
                    Name = x.Key,
                    Count = x.Count()
                })
                .ToList();

            //categories with active product count
            var categoryCount = _context.Categories
                .Select(c => new
                {
                    Category = c.Name,
                    ActiveProducts = c.Products.Count(p => p.IsActive)
                });



        }
    }

    internal class ProductResponse
    {
        public int ProductId { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public string CategoryName { get; set; }
        public object Count { get; set; }
    }
}
