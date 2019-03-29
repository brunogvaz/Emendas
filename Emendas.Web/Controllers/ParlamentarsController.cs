using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Emendas.Data;
using EmendasModel;
using AutoMapper;
using Microsoft.Extensions.Logging;
using Emendas.Web.ViewModels;

namespace Emendas.Web.Controllers
{ 
    [Route("api/[Controller]")]
    [ApiController]
    [Produces("application/json")]
public class ParlamentarsController : ControllerBase
    {
        
        private IEmendasRepository _repository;
        private IMapper _mapper;
        private ILogger<Parlamentar> _logger;

        public ParlamentarsController(IEmendasRepository repository, ILogger<Parlamentar> logger, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
            _logger = logger;

        }

        // GET: api/Parlamentars
        [HttpGet]
        public ActionResult<IEnumerable<Parlamentar>> GetParlamentars()
        {
            return Ok(_repository.GetParlamentars());
        }

        // GET: api/Parlamentars/5
        [HttpGet("{id}")]
        public ActionResult<Parlamentar> GetParlamentar(int id)
        {

            try
            {
                var parlamentar = _repository.GetParlamentarById(id);

                if (parlamentar != null)
                {
                    return Ok(_mapper.Map<Parlamentar, ParlamentarViewModel>(parlamentar));
                }
                else return NotFound();

               
            }
            catch (Exception ex)
            {

                _logger.LogError($"Failed to get parlamentar {ex}" );
                return BadRequest();
            }
            
        }

        //// PUT: api/Parlamentars/5
        //[HttpPut("{id}")]
        //public async Task<IActionResult> PutParlamentar(int id, Parlamentar parlamentar)
        //{
        //    if (id != parlamentar.Id)
        //    {
        //        return BadRequest();
        //    }

        //    _context.Entry(parlamentar).State = EntityState.Modified;

        //    try
        //    {
        //        await _context.SaveChangesAsync();
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        if (!ParlamentarExists(id))
        //        {
        //            return NotFound();
        //        }
        //        else
        //        {
        //            throw;
        //        }
        //    }

        //    return NoContent();
        //}

        //// POST: api/Parlamentars
        //[HttpPost]
        //public async Task<ActionResult<Parlamentar>> PostParlamentar(Parlamentar parlamentar)
        //{
        //    _context.Parlamentars.Add(parlamentar);
        //    await _context.SaveChangesAsync();

        //    return CreatedAtAction("GetParlamentar", new { id = parlamentar.Id }, parlamentar);
        //}

        //// DELETE: api/Parlamentars/5
        //[HttpDelete("{id}")]
        //public async Task<ActionResult<Parlamentar>> DeleteParlamentar(int id)
        //{
        //    var parlamentar = await _context.Parlamentars.FindAsync(id);
        //    if (parlamentar == null)
        //    {
        //        return NotFound();
        //    }

        //    _context.Parlamentars.Remove(parlamentar);
        //    await _context.SaveChangesAsync();

        //    return parlamentar;
        //}

        //private bool ParlamentarExists(int id)
        //{
        //    return _context.Parlamentars.Any(e => e.Id == id);
        //}
    }
}
