using System.Collections.Generic;
using EmendasModel;

namespace Emendas.Data
{
    public interface IEmendasRepository
    {
        IEnumerable<Emenda> GetEmendasByParlamentar(int ParlamentarId);
        IEnumerable<Emenda> GetEmendas();
        IEnumerable<Empenho> GetEmpenhosByEmendaId(int EmendaId);
        Parlamentar GetParlamentarById(int Id, bool includeEmendas=false);
        IEnumerable<Parlamentar> GetParlamentars(bool includeEmendas = false);
        bool SaveAll();
        Emenda GetEmendaById(int id);
    }
}