
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using VineyardsManagement.DB;
using VineyardsManagement.Models;

namespace VineyardsManagement.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class VineyardsController : Controller
    {
        private readonly VineyardDBContext _context;
        public VineyardsController(VineyardDBContext context)
        {
            _context = context;
        }
      
        //Devuelve los nombres de los viñedos y una lista de los gerentes ordenados alfabeticamente
        [HttpGet]
        [Route("managers")]
        public async Task<ActionResult<Dictionary<string,List<Managers>>>> GetVineyardAndManagers()
        {
            var vineyardAndManagersName = await _context.Vineyards.Include(p=> p.Parcels).ThenInclude(m=> m.Manager)
                 .Select(m => new
                 {
                     VineyardName = m.Name,
                     IDVineyard = m.Parcels.Select(m => m.Manager.Name)
                        .Distinct()
                        .OrderBy(name => name)
                        .ToList()
                 })
                 .ToDictionaryAsync(
                     x => x.VineyardName,
                     x => x.IDVineyard
                 );

            return Ok(vineyardAndManagersName);

        }
    }
}
