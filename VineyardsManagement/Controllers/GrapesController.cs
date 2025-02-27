using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using VineyardsManagement.DB;
using VineyardsManagement.Models;

namespace VineyardsManagement.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class GrapesController : Controller
    {
        private readonly VineyardDBContext _context;
        public GrapesController(VineyardDBContext context)
        {
            _context = context;
        }

        //Calcula el area total que tiene cada variedad de uva.
        [HttpPost]
        [Route("area")]
        public async Task<ActionResult<Dictionary<string, int>>> GetTotalAreaByGrape()
        {
            var totalAreaByGrape = await _context.Grapes.Include(m => m.Parcels)
                .Select(m => new
                {
                    GrapeName = m.Name,
                    TotalArea = m.Parcels.Sum(p => p.Area)
                })
                .ToDictionaryAsync(
                    x => x.GrapeName,
                    x => x.TotalArea
                );

            return Ok(totalAreaByGrape);

        }
    }
}
