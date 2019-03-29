using EmendasModel;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Emendas.Web.ViewModels
{
    public class ParlamentarViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int CodParlamentar { get; set; }
        public int TipoParlamentar { get; set; }//TODO 1 ou 2
        public Partido Partido { get; set; }
        public int PartidoId { get; set; }
        public ICollection<Emenda> Emendas { get; set; }
    }
}
