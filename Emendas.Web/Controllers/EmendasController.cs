using AutoMapper;
using Emendas.Data;
using Emendas.Web.ViewModels;
using EmendasModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;

namespace Emendas.Web.Controllers
{
    [Route("api/parlamentars/{parlamentarId}/emendas")]
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
        public ActionResult<IEnumerable<Emenda>> Get(int parlamentarId)
        {
            try
            {
                return Ok(_mapper.Map<IEnumerable<Emenda>, IEnumerable<EmendaViewModel>>(_repository.GetEmendasByParlamentar(parlamentarId)));
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