﻿using Emendas.Data;
using EmendasModel;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace ImportarDados
{
    public static class ImportarEmendas
    {

        public static void Importar()
        {

           
            // var file = Path.GetFullPath(Path.Combine(AppContext.BaseDirectory, "..\\..\\..\\", "emendas.csv"));
            IEnumerable<Emenda> list = ProcessCSV("./emendas.csv");


            using (var context = new EmendasContext())
            {
                foreach (var emenda in list.Where((arg) => arg.Valor !=0))  // apenas linhas que tenham esse campo são emendas
                {
                    // Console.WriteLine(parla.Name);

                    if (!context.Emendas.Any(e => e.CodEmenda == emenda.CodEmenda) )
                    {
                        var parlamentarExistente = context.Parlamentars.Where(p => p.CodParlamentar == emenda.Parlamentar.CodParlamentar ).SingleOrDefault();

                        if (parlamentarExistente==null)
                        {
                            Console.WriteLine("Parlamentar Nao Encontrado com CodParlamentar:" + emenda.Parlamentar.CodParlamentar);
                        }
                        else { 
                        emenda.Parlamentar = parlamentarExistente;
                        context.Emendas.Add(emenda);
                        }
                    }

                }
                //context.ChangeTracker.DetectChanges();
                context.SaveChanges();
            }
        }

        internal static IEnumerable<Emenda> ProcessCSV(string csv)
        {
            return File.ReadAllLines(csv)
                .Skip(1)
                .Where(line => line.Length > 1)
                .Select(ParseEmendaFromCsv).ToList();
        }

        private static Emenda ParseEmendaFromCsv(string line)
        {
            var columns = line.Split(';');
            //            0             1               2           3              4                               5               6        7       8           9           10                  11       12      13      14      15             16          17                  18                  19                                  20                  21              22                      23              24                          25              26                  27                          28                  29              30              31                      32                              33                  34                                      35                                      36
            //Ano Exercício   Número    Emenda      Autor(nome)    Partido(sigla) Órgão(desc.)   Unidade Orçamentária(desc.)    Função  Subfunção   Programa Ação(desc.)    Localizador(desc.) Fonte    IDOC    IDUSO   GND     Modalidade  Beneficiário    Beneficiário(nome) Tipo Impedimento    Justificativa Impedimento(desc.)   Município(desc.)   Região(desc.)  População do Município PIB do Município Tipo Autor Emenda Tipo Autor Emenda(desc.)   Grupo Autor Emenda Grupo Autor Emenda(desc.)  Tipo de Crédito Tipo de Crédito(desc.) UF(desc.)  Prioridade Desbloqueio  Emenda Aprovada(Dot Atual) Valor Bloqueado da Emenda   Valor Impedido(por Beneficiário)   Valor Indicado(por Beneficiário)   Valor Priorizado(por Beneficiário)


            var posHifen = columns[2].IndexOf('-');
            return new Emenda
            {
                CodEmenda = columns[1].Substring(4),
                Parlamentar = new Parlamentar { CodParlamentar = int.Parse(columns[2].Substring(0,posHifen -1)) },
                Valor = Decimal.Parse(columns[32])



            };


        }


       
    }
}

