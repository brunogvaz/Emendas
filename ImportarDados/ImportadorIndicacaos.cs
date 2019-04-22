using System;
using EmendasModel;

namespace ImportarDados
{
    public static class ImportadorIndicacaos
    {
        private static Indicacao ParseImpedimentosFromCsv(string line)
        {
            var columns = line.Split(';');
            //            0             1               2           3              4                               5               6        7       8           9           10                  11       12      13      14      15             16          17                  18                  19                                  20                  21              22                      23              24                          25              26                  27                          28                  29              30              31                      32                              33                  34                                      35                                      36
            //Ano Exercício   Número    Emenda      Autor(nome)    Partido(sigla) Órgão(desc.)   Unidade Orçamentária(desc.)    Função  Subfunção   Programa Ação(desc.)    Localizador(desc.) Fonte    IDOC    IDUSO   GND     Modalidade  Beneficiário    Beneficiário(nome) Tipo Impedimento    Justificativa Impedimento(desc.)   Município(desc.)   Região(desc.)  População do Município PIB do Município Tipo Autor Emenda Tipo Autor Emenda(desc.)   Grupo Autor Emenda Grupo Autor Emenda(desc.)  Tipo de Crédito Tipo de Crédito(desc.) UF(desc.)  Prioridade Desbloqueio  Emenda Aprovada(Dot Atual) Valor Bloqueado da Emenda   Valor Impedido(por Beneficiário)   Valor Indicado(por Beneficiário)   Valor Priorizado(por Beneficiário)


            var posHifen = columns[2].IndexOf('-');
            return new Indicacao
            {
               
                Beneficiario = 
                ValorIndicado = Decimal.Parse(columns[35]),
                   ValorImpedido = Decimal.Parse(columns[34]),
                   ValorBloqueado = Decimal.Parse(columns[33]),
                   ValorPriorizado= Decimal.Parse(columns[36]),



            };
            throw new NotImplementedException();

        }
    }
}
