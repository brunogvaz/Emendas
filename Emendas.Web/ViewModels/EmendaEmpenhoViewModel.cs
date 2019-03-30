using EmendasModel;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Emendas.Web.ViewModels
{
    public class EmendaEmpenhoViewModel
    {
        public int EmendaId { get; set; }
        public int EmpenhoId { get; set; }
        public string EmpenhoCodigoEmpenho{ get; set; }
        public decimal ValorEmpenhado { get; set; }
        public decimal ValorPago { get; set; }
    }
}
