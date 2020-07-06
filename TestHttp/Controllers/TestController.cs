using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace TestHttp.Controllers
{
    [Route("test")]
    public class TestController : Controller
    {
        private readonly AppContext _context;

        public TestController(AppContext context)
        {
            _context = context;
        }
        public async Task<DataModel> GetData()
        {
            try
            {
                var last = await _context.Data.OrderByDescending(i => i.Id).FirstOrDefaultAsync();
                var res = await _context.Data.AddAsync(new DataModel()
                {
                    Id = (last?.Id ?? 0) + 1,
                    Age = (last?.Age ?? 0) + 1,
                    Name = last + new Random().Next().ToString()
                });
                await _context.SaveChangesAsync();
                return res.Entity;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }

        }
    }
}
