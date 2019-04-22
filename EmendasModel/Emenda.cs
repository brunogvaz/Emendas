using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmendasModel
{
    public class Emenda
    {
        public int Id { get; set; }
        public string CodEmenda { get; set; }
        public decimal Valor { get; set; }


        public Parlamentar Parlamentar { get; set; }
        public int ParlamentarId { get; set; }
        public int? PlanoTrabalhoId { get; set; }
        public virtual PlanoTrabalho PlanoTrabalho { get; set; }
        public virtual ICollection<EmendaEmpenho> EmendaEmpenho { get; set; }

        public virtual ICollection<Indicacao> Indicacaos { get; set; }

    }
}
