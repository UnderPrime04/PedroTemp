using Microsoft.AspNetCore.Mvc;
using RpgApi.Data;

using RpgApi.Models;
using Microsoft.EntityFrameworkCore;

namespace RpgApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DisputasController : ControllerBase
    {

        private readonly DataContext _context;

        public DisputasController(DataContext context)
        {
            _context = context;
        }

        [HttpGet("Listar")]
        public async Task<IActionResult> ListarAsync()
        {
            try
            {
                List<Disputa> disputas = await _context.Disputas.ToListAsync();
                return Ok(disputas);
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("ApagarDisputas")]
        public async Task<IActionResult> DeleteAsync()
        {
            try
            {
                List<Disputa> disputas = await _context.Disputas.ToListAsync();
                _context.Disputas.RemoveRange(disputas);
                await _context.SaveChangesAsync();
                return Ok("Disputas apagadas");
            }
            catch (System.Exception ex)
            { return BadRequest(ex.Message); }
        }

        


    }
}