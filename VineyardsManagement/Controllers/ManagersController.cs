using System;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using VineyardsManagement.DB;
using VineyardsManagement.Models;

namespace VineyardsManagement.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ManagersController : Controller
    {
        private readonly VineyardDBContext _context;
        public ManagersController(VineyardDBContext context)
        {
            _context = context;
        }

        //Devuelve una lista de los Ids de los Managers
        [HttpGet]
        [Route("ids")]
        public async Task<ActionResult<List<Managers>>> GetManagersIds()
        {
            var managerList = await _context.Managers.Select(x => x.Id).ToListAsync();

            return Ok(managerList);
        }

        //Devuelve los taxNumber de cada Manager ordenados por el nombre del Manager
        [HttpGet]
        [Route("taxnumbers")]
        public async Task<ActionResult<List<Managers>>> GetManagersTaxNumbers(bool sorted = true)
        {

            if (sorted) { 
            var managerListOrderByName = await _context.Managers.OrderBy(m => m.Name).Select(m => m.TaxNumber).ToListAsync();

            return Ok(managerListOrderByName);
            }

            return BadRequest();
        }

        //Calcula el area total que gestiona cada manager.
        [HttpPost]
        [Route("totalarea")]
        public async Task<ActionResult<Dictionary<string, int>>> GetTotalAreaByManager()
        {
            var totalAreaByManager = await _context.Managers.Include(m => m.Parcels)
                .Select(m => new
                {
                    ManagerName = m.Name,
                    TotalArea = m.Parcels.Sum(p => p.Area)
                })
                .ToDictionaryAsync(
                    x => x.ManagerName,
                    x => x.TotalArea
                );

            return Ok(totalAreaByManager);

        }

    }
}
