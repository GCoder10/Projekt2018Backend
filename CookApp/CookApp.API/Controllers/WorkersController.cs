using System.Collections.Generic;
using System.Threading.Tasks;
using CookApp.API.Data;
using CookApp.API.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace CookApp.API.Controllers
{

    [Route("api/[controller]")]
    public class WorkersController : Controller
    {
        private readonly MongoDBDataContext _context;
        public WorkersController(IOptions<MongoDBSettings> settings)
        {
            _context = new MongoDBDataContext(settings);
        }
    
    [HttpGet]
    public async Task<IEnumerable<Worker>> GetAllWorkers()
    {
        return await _context.Workers.Find(_ => true).ToListAsync();
    }

    }

}