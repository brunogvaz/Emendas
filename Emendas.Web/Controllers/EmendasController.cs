using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Emendas.Data;
using EmendasModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Emendas.Web.Controllers
{
   [Route("api/[Controller]")]
   [ApiController]
    [Produces("application/json")]
    public class EmendasController : ControllerBase
    {
        private ILogger _logger;
        private IEmendasRepository _repository;
        private IMapper _mapper;

        public EmendasController(IEmendasRepository repository, ILogger<Emenda> logger,IMapper mapper)
        {
            _logger = logger;
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Emenda>> Get()
        {
            try
            {
                return Ok(_repository.GetEmendas());
            }
            catch (Exception)
            {

                return BadRequest();
            }
           
        }

        [HttpGet("{id:int}")]
        public ActionResult<IEnumerable<Emenda>> GetById(int id)
        {
            try
            {
                var result = _repository.GetEmendaById(id);
                if (result != null)
                {
                    return Ok(result);
                }
                else return NotFound();
            }
            catch (Exception)
            {

                return BadRequest();
            }

        }
    }
}