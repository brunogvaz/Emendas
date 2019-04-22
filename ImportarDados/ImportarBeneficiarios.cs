using System;
using Emendas.Data;
using EmendasModel;

using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;


namespace ImportarDados



{
    public static class ImportarBeneficiarios
    {
        private static void ImportaBeneficiario(IEnumerable<Beneficiario> list)
        {
            var listDistinctCNPJ = list.GroupBy(e => e.CNPJ).Select(e => e.First()).ToList();
            using (var context = new EmendasContext())
            {
                foreach (var beneficiario in listDistinctCNPJ)
                {
                    var beneficiarioExistente = context.Beneficiarios.Where(b => b.CNPJ == beneficiario.CNPJ).SingleOrDefault();

                    if (beneficiarioExistente == null)
                    {

                        context.Beneficiarios.Add(beneficiario);
                    }
                }
                context.SaveChanges();
            }
        }



        public static void Importar(string path)
        {


           
            IEnumerable<Beneficiario> list = ProcessCSV(path);


            using (var context = new EmendasContext())
            {
                foreach (var emenda in list.Where((arg) => arg.Valor != 0))  // apenas linhas que tenham esse campo são emendas
                {
                   

                    if (!context.Emendas.Any(e => e.CodEmenda == emenda.CodEmenda))
                    {
                        var parlamentarExistente = context.Parlamentars.Where(p => p.CodParlamentar == emenda.Parlamentar.CodParlamentar).SingleOrDefault();

                        if (parlamentarExistente == null)
                        {
                            Console.WriteLine("Parlamentar Nao Encontrado com CodParlamentar:" + emenda.Parlamentar.CodParlamentar);
                        }
                        else
                        {
                            emenda.Parlamentar = parlamentarExistente;
                            context.Emendas.Add(emenda);
                        }
                    }

                }
                //context.ChangeTracker.DetectChanges();
                context.SaveChanges();
            }
        }

        internal static IEnumerable<T> ProcessCSV<T>(string csv)
        {
            return File.ReadAllLines(csv)
                .Skip(1)
                .Where(line => line.Length > 1)
                .Select(ParseEmendaFromCsv).ToList();
        }

        private static Beneficiario ParseEmendaFromCsv<T>(string line)
        {
            var columns = line.Split(';');
            //            0             1               2           3              4                               5               6        7       8           9           10                  11       12      13      14      15             16          17                  18                  19                                  20                  21              22                      23              24                          25              26                  27                          28                  29              30              31                      32                              33                  34                                      35                                      36
            //Ano Exercício   Número    Emenda      Autor(nome)    Partido(sigla) Órgão(desc.)   Unidade Orçamentária(desc.)    Função  Subfunção   Programa Ação(desc.)    Localizador(desc.) Fonte    IDOC    IDUSO   GND     Modalidade  Beneficiário    Beneficiário(nome) Tipo Impedimento    Justificativa Impedimento(desc.)   Município(desc.)   Região(desc.)  População do Município PIB do Município Tipo Autor Emenda Tipo Autor Emenda(desc.)   Grupo Autor Emenda Grupo Autor Emenda(desc.)  Tipo de Crédito Tipo de Crédito(desc.) UF(desc.)  Prioridade Desbloqueio  Emenda Aprovada(Dot Atual) Valor Bloqueado da Emenda   Valor Impedido(por Beneficiário)   Valor Indicado(por Beneficiário)   Valor Priorizado(por Beneficiário)


            var posHifen = columns[2].IndexOf('-');
            return new Beneficiario
            {
                 CNPJ = columns[16],
                 Nome = columns[17]
                  
                

            };


        }
    }
}
