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
    public class GenreChartsController : ControllerBase
    {
        private readonly TitleDBContext _context;

        public GenreChartsController(TitleDBContext context)
        {
            _context = context;
        }
        [HttpGet("JsonData")]
        public JsonResult JsonData()
        {
            var genres = _context.Genre.Include(b => b.TitleToGenre).ToList();

            List<object> genTitle = new List<object>();

            genTitle.Add(new[] { "Жанр", "Кількість тайтлів" });

            foreach (var c in genres)
            {
                genTitle.Add(new object[] { c.Name, c.TitleToGenre.Count() });
            }
            return new JsonResult(genTitle);
        }
    }
}
