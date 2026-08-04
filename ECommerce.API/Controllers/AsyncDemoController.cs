using ECommerce.API.Data;
using ECommerce.API.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace ECommerce.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AsyncDemoController : ControllerBase
    {
        private readonly ECommerceDbContext _context;

        public AsyncDemoController(ECommerceDbContext context)
        {
            _context = context;
        }


        [HttpGet]
        public async Task<IActionResult> Get()
        {
            Console.WriteLine($"Before await : {Environment.CurrentManagedThreadId}");

            await Task.Delay(3000);

            Console.WriteLine($"After await : {Environment.CurrentManagedThreadId}");

            return Ok();
        }

        [HttpGet("sequential")]
        public async Task<IActionResult> Sequential()
        {
            var stopwatch = Stopwatch.StartNew();

            Console.WriteLine("Task 1 Started");
            await Task.Delay(3000);
            Console.WriteLine("Task 1 Completed");

            Console.WriteLine("Task 2 Started");
            await Task.Delay(3000);
            Console.WriteLine("Task 2 Completed");

            Console.WriteLine("Task 3 Started");
            await Task.Delay(3000);
            Console.WriteLine("Task 3 Completed");

            stopwatch.Stop();

            return Ok($"Total Time : {stopwatch.Elapsed.TotalSeconds} sec");
        }

        [HttpGet("parallel")]
        public async Task<IActionResult> Paraller()
        {
            var stopwatch = Stopwatch.StartNew();

            var task1 = FakeApiCall("Task 1");
            var task2 = FakeApiCall("Task 2");
            var task3 = FakeApiCall("Task 3");

            await Task.WhenAll(task1, task2, task3);

            stopwatch.Stop();

            return Ok($"Total time : {stopwatch.Elapsed.TotalSeconds} sec");
        }

        [HttpGet("tracking")]
        public async Task<IActionResult> Tracking()
        {
            var product = await _context.Products.FirstAsync();

            Console.WriteLine("Before Change");
            Console.WriteLine(_context.Entry(product).State);

            product.Name = "Test Product";

            Console.WriteLine("After change");
            Console.WriteLine(_context.Entry(product).State);

            return Ok();
        }

        [HttpGet("entitystates")]
        public async Task<IActionResult> EntityStates()
        {
            var product = new Product
            {
                CategoryId = 2
            };

            Console.WriteLine($"New Object : {_context.Entry(product).State}");

            _context.Products.Add(product);
            Console.WriteLine($"After Add : {_context.Entry(product).State}");

            await _context.SaveChangesAsync();
            Console.WriteLine($"After save : {_context.Entry(product).State}");

            return Ok();

        }

        [HttpGet("no-tracking-demo")]
        public async Task<IActionResult> NoTracingDemo()
        {
            var product = await _context.Products
                .AsNoTracking()
                .FirstAsync();

            Console.WriteLine(_context.Entry(product).State);

            return Ok();
        }

        [HttpGet("attach")]
        public IActionResult AttachDemo()
        {
            var product = new Product
            {
                Id = 1,
                Name = "Laptop",
                CategoryId = 2
            };

            Console.WriteLine($"Before attach : {_context.Entry(product).State}");

            _context.Attach(product);

            Console.WriteLine($"After attach : {_context.Entry(product).State}");

            return Ok();
        }

        [HttpGet("update")]
        public async Task<IActionResult> UpdateDemo()
        {
            var product = new Product
            {
                Id = 2
            };

            _context.Attach(product);

            product.Name = "Gaming Laptop";
            product.CategoryId = 1;

            _context.Entry(product).Property(x => x.Name).IsModified = true;
            _context.Entry(product).Property(x => x.CategoryId).IsModified = true;

            await _context.SaveChangesAsync();

            return Ok();
        }


        [HttpGet("find")]
        public async Task<IActionResult> Find()
        {
            Console.WriteLine("First find");
            var product1 = await _context.Products.FindAsync(1);

            Console.WriteLine("Second Find");
            var product2 = await _context.Products.FindAsync(1);

            return Ok();
        }

        [HttpGet("first")]
        public async Task<IActionResult> FirstDemo()
        {
            Console.WriteLine("first query");
            var products = await _context.Products
                .FirstOrDefaultAsync(x => x.Id == 1);

            Console.WriteLine("second query");
            var product2 = await _context.Products
                .FirstOrDefaultAsync(x => x.Id == 1);

            return Ok();
        }

        [HttpGet("transaction")]
        public async Task<IActionResult> TransactionDemo()
        {
            using var transaction = await _context.Database.BeginTransactionAsync();

            try
            {
                _context.Categories.Add(new Category
                {
                    Name = "Category 1"
                });

                await _context.SaveChangesAsync();

                _context.Categories.Add(new Category
                {
                    Name = "Category 2"
                });

                await _context.SaveChangesAsync();

                throw new Exception("connection lost...");

                await transaction.CommitAsync();
                return Ok();
            }
            catch (Exception ex)
            {
                await transaction.RollbackAsync();
                throw;
            }
        }


        private async Task FakeApiCall(string taskName)
        {
            Console.WriteLine($"{taskName} started");

            await Task.Delay(3000);

            Console.WriteLine($"{taskName} completed");
        }
    }
}
