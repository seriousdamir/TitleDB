using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace TDB.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ChartsController : ControllerBase
    {
        private readonly TitleDBContext _context;

        public ChartsController(TitleDBContext context)
        {
            _context = context;
        }
        [HttpGet("JsonData")]
        public JsonResult JsonData()
        {
            var franchaises = _context.Franchaise.Include(b => b.Title).ToList();

            List<object> frantitle = new List<object>();

            frantitle.Add(new[] { "Франшиза", "Кількість тайтлів" });

            foreach (var c in franchaises)
            {
                frantitle.Add(new object[] { c.Name, c.Title.Count() });
            }
            return new JsonResult(frantitle);
            //
        }
    }
}