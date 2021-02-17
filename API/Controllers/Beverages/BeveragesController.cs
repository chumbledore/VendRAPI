using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Models;
using Database;
using Microsoft.Extensions.Logging;

namespace API.Controllers
{
    public class BeveragesController : BasicController
    {
        private readonly ILogger<BeveragesController> _logger;
        private readonly DataContext _context;
        public BeveragesController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<Beverage>>> GetBeverages()
        {
            return await _context.Beverages.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Beverage>> GetBeverage(Guid id)
        {
            return await _context.Beverages.FindAsync(id);
        }

        [HttpPost]
        public async Task CreateNewBeverage([Bind("BevName, Price, Size")]Beverage beverage)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    await _context.Beverages.AddAsync(beverage);
                    await _context.SaveChangesAsync();
                    return;
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error has occured in migration.");
            }
        }

        [HttpDelete("{id}")]
        public async Task DeleteBeverage(Guid id)
        {
            var beverage = await _context.Beverages.FindAsync(id);
            if (beverage == null)
            {
                return;
            }

            try 
            { 
                _context.Beverages.Remove(beverage);
                await _context.SaveChangesAsync();
                return;
            }
            catch (Exception ex) 
            {
                _logger.LogError(ex, "An error has occured in migration.");
            }
        }

    }

    
}