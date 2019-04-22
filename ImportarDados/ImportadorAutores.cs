using Emendas.Data;
using EmendasModel;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace ImportarDados
{
    public static class ImportadorAutores
    {

        public static void Importar(ImportacaoEmendasDumpSiop importacao)
        {
            IEnumerable<Parlamentar> list = ProcessCSVAutores(importacao);



            using (var context = new EmendasContext())
            {
                foreach (var parla in list)
                {
                    // Console.WriteLine(parla.Name);

                    if (!context.Parlamentars.Any(p => p.CodParlamentar == parla.CodParlamentar) && (parla.TipoParlamentar == 1 || parla.TipoParlamentar == 2))
                    {
                        var partido = ImportarDados.ImportarPartidos.InserePartido(context, parla.Partido);
                        parla.Partido = partido;
                        context.Parlamentars.Add(parla);
                    }

                }
                context.SaveChanges();
            }
        }

        internal static IEnumerable<Parlamentar> ProcessCSVAutores(ImportacaoEmendasDumpSiop importacao)
        {
            return importacao.ProcessCSV()
                .Select(ParseFromCsv).ToList();
        }

        private static Parlamentar ParseFromCsv(LinhaImportacaoEmendasDumpSiop line)
        {

            //            0             1               2           3              4                               5               6        7       8           9           10                  11       12      13      14      15             16          17                  18                  19                                  20                  21              22                      23              24                          25              26                  27                          28                  29              30              31                      32                              33                  34                                      35                                      36
            //Ano Exercício   Número    Emenda      Autor(nome)    Partido(sigla) Órgão(desc.)   Unidade Orçamentária(desc.)    Função  Subfunção   Programa Ação(desc.)    Localizador(desc.) Fonte    IDOC    IDUSO   GND     Modalidade  Beneficiário    Beneficiário(nome) Tipo Impedimento    Justificativa Impedimento(desc.)   Município(desc.)   Região(desc.)  População do Município PIB do Município Tipo Autor Emenda Tipo Autor Emenda(desc.)   Grupo Autor Emenda Grupo Autor Emenda(desc.)  Tipo de Crédito Tipo de Crédito(desc.) UF(desc.)  Prioridade Desbloqueio  Emenda Aprovada(Dot Atual) Valor Bloqueado da Emenda   Valor Impedido(por Beneficiário)   Valor Indicado(por Beneficiário)   Valor Priorizado(por Beneficiário)

          
            var posHifen = line.Autor.IndexOf('-');
            return new Parlamentar
            {


                CodParlamentar = int.Parse(line.Autor.Substring(0, posHifen - 1).Trim()),
                TipoParlamentar = line.TipoParlamentar,
                Name = line.Autor.Substring(posHifen + 1).Trim(),
                Partido=new Partido { Name= (line.Partido) 

                }


            };


        }
        public static Parlamentar InsereParlamentar(EmendasContext context, Parlamentar parla)
        {
            var parlamentarExistente = context.Parlamentars.Where(p => p.CodParlamentar == parla.CodParlamentar || p.Name==parla.Name).SingleOrDefault();
            if (parlamentarExistente == null)
            {
                context.Parlamentars.Add(parla);
                parlamentarExistente = parla;
            }


            return parlamentarExistente;
        }

    }
}
