using System.Collections.Generic;
using EmendasModel;

namespace Emendas.Data
{
    public interface IEmendasRepository
    {
        IEnumerable<Emenda> GetEmendasByParlamentar(int ParlamentarId);
        IEnumerable<Emenda> GetEmendas();
        IEnumerable<Empenho> GetEmpenhosByEmendaId(int EmendaId);
        Parlamentar GetParlamentarById(int Id);
        IEnumerable<Parlamentar> GetParlamentars();
        bool SaveAll();
        Emenda GetEmendaById(int id);
    }
}