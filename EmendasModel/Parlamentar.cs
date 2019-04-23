using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmendasModel
{
    public class Parlamentar
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int CodParlamentar { get; set; }
        public int TipoParlamentar { get; set; }//TODO 1 ou 2
        public Partido Partido { get; set; }
        public int PartidoId { get; set; }
        public ICollection<Emenda> Emendas { get; set; }
        public User User { get; set; }

    }
}
