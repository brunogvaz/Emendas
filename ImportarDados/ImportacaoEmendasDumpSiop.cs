using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace ImportarDados
{

  


    public  class ImportacaoEmendasDumpSiop
    {
        private string _csv;

        public ImportacaoEmendasDumpSiop(string csv)
        {
            _csv = csv;
        }




        //Ano Exercício   Número    Emenda      Autor(nome)    Partido(sigla) Órgão(desc.)   Unidade Orçamentária(desc.)    Função  Subfunção   Programa Ação(desc.)    Localizador(desc.) Fonte    IDOC    IDUSO   GND     Modalidade  Beneficiário    Beneficiário(nome) Tipo Impedimento    Justificativa Impedimento(desc.)   Município(desc.)   Região(desc.)  População do Município PIB do Município Tipo Autor Emenda Tipo Autor Emenda(desc.)   Grupo Autor Emenda Grupo Autor Emenda(desc.)  Tipo de Crédito Tipo de Crédito(desc.) UF(desc.)  Prioridade Desbloqueio  Emenda Aprovada(Dot Atual) Valor Bloqueado da Emenda   Valor Impedido(por Beneficiário)   Valor Indicado(por Beneficiário)   Valor Priorizado(por Beneficiário)


        public  IEnumerable<LinhaImportacaoEmendasDumpSiop> ProcessCSV()
        {
            return File.ReadAllLines(_csv)
                .Skip(1)
                .Where(line => line.Length > 1).Select(ParseColumns)
                .ToList();
        }

        private  LinhaImportacaoEmendasDumpSiop ParseColumns(string line)
        {

            var columns = line.Split(';');
            return new LinhaImportacaoEmendasDumpSiop
            {
                AnoExercicio = columns[0],
                NumeroEmenda = columns[1].Substring(4)


            };
        }
    }



    public class LinhaImportacaoEmendasDumpSiop
    {

        public string AnoExercicio { get; set; }
        public string NumeroEmenda { get; set; }
        public string Autor { get; set; }
        public string Partido { get; set; }
        public string Orgao { get; set; }
        public string Unidade { get; set; }
        public string Funcao { get; set; }
        public string SubFuncao { get; set; }
        public string ProgramaAcao { get; set; }
        public string Localizador { get; set; }
        public int Fonte { get; set; }
        public string Idoc { get; set; }
        public string IdUso { get; set; }
        public int Gnd { get; set; }
        public int Modalidade { get; set; }
        public string Beneficiario { get; set; }
        public string BeneficiarioNome { get; set; }






        public int TipoParlamentar { get; set; }


    }
}
