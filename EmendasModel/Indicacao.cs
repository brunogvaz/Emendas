using System;
namespace EmendasModel
{
    public class Indicacao
    {



        public int Id { get; set; }

        public decimal ValorBloqueado { get; set; }
        public decimal ValorIndicado { get; set; }
        public decimal ValorPriorizado { get; set; }
        public decimal ValorImpedido { get; set; }
        public int  EmendaId { get; set; }
        public Emenda Emenda { get; set; }
        public Beneficiario Beneficiario { get; set; }


           
    }
    }

