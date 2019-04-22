using System;
using System.Collections.Generic;
using System.Text;

namespace EmendasModel
{
    public class EmendaEmpenho
    {
        
        public int EmendaId { get; set; }
        public Emenda Emenda { get; set; }
        public int EmpenhoId { get; set; }
        public Empenho Empenho { get; set; }
        public int BeneficiarioId { get; set; }
        public Beneficiario Beneficiario { get; set; }
        public decimal ValorEmpenhado { get; set; }
        public decimal ValorPago { get; set; }
    }
}
