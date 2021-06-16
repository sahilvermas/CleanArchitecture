using CleanArchitecture.Application.Interfaces;
using CleanArchitecture.Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Data.Common;
using System.Threading.Tasks;

namespace CleanArchitecture.WebApi.Controllers.v1
{
    [ApiVersion("1.0")]
    public class ProductNewController : BaseApiController
    {
        public ProductNewController(IApplicationDbContext dbContext, IApplicationReadDbConnection readDbConnection,
            IApplicationWriteDbConnection writeDbConnection)
        {
            _dbContext = dbContext;
            _readDbConnection = readDbConnection;
            _writeDbConnection = writeDbConnection;
        }

        public IApplicationDbContext _dbContext { get; }
        public IApplicationReadDbConnection _readDbConnection { get; }
        public IApplicationWriteDbConnection _writeDbConnection { get; }


        [HttpGet]
        public async Task<IActionResult> GetProducts()
        {
            var query = $"SELECT * FROM Product";
            var employees = await _readDbConnection.QueryAsync<Product>(query);
            return Ok(employees);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllProducts(int id)
        {
            var employees = await _dbContext.Products.ToListAsync();
            return Ok(employees);
        }

        [HttpPost]
        public async Task<IActionResult> AddNewProduct(Product product)
        {
            _dbContext.Connection.Open();
            using (var transaction = _dbContext.Connection.BeginTransaction())
            {
                try
                {
                    await _dbContext.Database.UseTransactionAsync(transaction as DbTransaction);

                    bool DepartmentExists = await _dbContext.Products.AnyAsync(a => a.Id == product.Id);
                    if (DepartmentExists)
                    {
                        throw new Exception("Department Already Exists");
                    }

                    return null;
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                    throw;
                }
            }
        }
    }
}
