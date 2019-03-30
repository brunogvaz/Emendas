using System;
using System.Collections.Generic;
using System.Linq;
using EmendasModel;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Emendas.Data
{
    public class EmendasRepository : IEmendasRepository
    {
        private EmendasContext _ctx;
        private ILogger<EmendasRepository> _logger;

        public EmendasRepository(EmendasContext ctx, ILogger<EmendasRepository> logger)
        {
            _ctx = ctx;
            _logger = logger;
        }
        public IEnumerable<Parlamentar> GetParlamentars(bool incluiEmendas = false)
        {
            try
            {
                _logger.LogInformation("GetParlamentar was called");

                if (incluiEmendas)
                {
                   return _ctx.Parlamentars.Include(p => p.Emendas)
                        .Include("Emendas.EmendaEmpenho")
                        .Include("Emendas.PlanoTrabalho")
                        .Include("Emendas.EmendaEmpenho.Empenho")
                        .OrderBy(p => p.Name)
                        .ToList();
                }
                else return _ctx.Parlamentars.OrderBy(p => p.Name)
                    .ToList();


            }
            catch (Exception ex)
            {

                _logger.LogError($"Failed to get all products: {ex}");
                return null;
            }
        }
        public Parlamentar GetParlamentarById(int Id, bool includeEmendas = false)
        {
            return GetParlamentars(includeEmendas).Where(p => p.Id == Id).FirstOrDefault();

        }


        public IEnumerable<Emenda> GetEmendasByParlamentar(int ParlamentarId)
        {
            return _ctx.Emendas.Include(e => e.PlanoTrabalho)
                .Include(e => e.EmendaEmpenho)
                .ThenInclude(ee => ee.Empenho)
                .Where(p => p.ParlamentarId == ParlamentarId);
        }



        public IEnumerable<Empenho> GetEmpenhosByEmendaId(int EmendaId)
        {
            return _ctx.Empenhos
                .Where(e => e.EmendaEmpenhos.Any(emp => emp.EmendaId == EmendaId));
        }

        public bool SaveAll()
        {
            return _ctx.SaveChanges() > 0;
        }

        public IEnumerable<Emenda> GetEmendas()
        {
            return _ctx.Emendas
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
