using System;
using System.Collections.Generic;
using System.Linq;
using EmendasModel;
using Microsoft.Extensions.Logging;

namespace Emendas.Data
{
    public class EmendasRepository : IEmendasRepository
    {
        private EmendasContext _ctx;
        private ILogger<EmendasRepository> _logger;

        public EmendasRepository(EmendasContext ctx,ILogger<EmendasRepository> logger)
        {
            _ctx = ctx;
            _logger = logger;
        }
        public IEnumerable<Parlamentar> GetParlamentars()
        {

            try
            {
                _logger.LogInformation("GetParlamentar was called");

                return _ctx.Parlamentars
                    .OrderBy(p => p.Name)
                    .ToList();
            }
            catch (Exception ex)
            {

                _logger.LogError($"Failed to get all products: {ex}");
                return null;
            }
        }
        public Parlamentar GetParlamentarById(int Id, bool includeEmendas=false)
        {
        
                
                var query =GetParlamentars()
                .Where(p => p.Id == Id).FirstOrDefault();

            if (includeEmendas)
            {
                return query.In
            }
        }


        public IEnumerable<Emenda> GetEmendasByParlamentar(int ParlamentarId)
        {
            return _ctx.Emendas
                .Where(p => p.ParlamentarId == ParlamentarId);
        }

        

        public IEnumerable<Empenho> GetEmpenhosByEmendaId(int EmendaId)
        {
            return _ctx.Empenhos
                .Where(e => e.EmendaEmpenhos.Any(emp=>emp.EmendaId == EmendaId));
        }

        public bool SaveAll()
        {
            return _ctx.SaveChanges() > 0;
        }

        public IEnumerable<Emenda> GetEmendas()
        {
           return  _ctx.Emendas
                .OrderBy(e => e.CodEmenda).ToList();
        }

        public Emenda GetEmendaById(int id)
        {
            return _ctx.Emendas
                .Where(e => e.Id == id)
                .FirstOrDefault();
        }
    }
}
