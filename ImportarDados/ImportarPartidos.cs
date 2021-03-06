﻿using Emendas.Data;
using EmendasModel;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace ImportarDados
{
    public static class ImportarPartidos
    {
        public static void Importar()
        {
            IEnumerable<Partido> list = ProcessCSVPartidos("./partidos.csv");


            using (var context = new EmendasContext())
            {
                foreach (var part in list)
                {
                    // Console.WriteLine(parla.Name);

                    InserePartido(context, part);

                }
                context.SaveChanges();
            }
        }

        public static Partido InserePartido(EmendasContext context, Partido part)
        {
            var partidoexistente = context.Partidos.Where(p => p.Sigla == part.Sigla ).SingleOrDefault();
            if (partidoexistente == null)
            {
                context.Partidos.Add(part);
                partidoexistente = part;
            }
            

            return partidoexistente;
        }

        internal static IEnumerable<Partido> ProcessCSVPartidos(string csv)
        {
            return File.ReadAllLines(csv)
                .Skip(1)
                .Where(line => line.Length > 1)
                .Select(ParseFromCsv).ToList();
        }

        private static Partido ParseFromCsv(string line)
        {
            var columns = line.Split(';');
            //            0             1               2           3              4                               5               6        7       8           9           10                  11       12      13      14      15             16          17                  18                  19                                  20                  21              22                      23              24                          25              26                  27                          28                  29              30              31                      32                              33                  34                                      35                                      36
            //Ano Exercício   Número    Emenda      Autor(nome)    Partido(sigla) Órgão(desc.)   Unidade Orçamentária(desc.)    Função  Subfunção   Programa Ação(desc.)    Localizador(desc.) Fonte    IDOC    IDUSO   GND     Modalidade  Beneficiário    Beneficiário(nome) Tipo Impedimento    Justificativa Impedimento(desc.)   Município(desc.)   Região(desc.)  População do Município PIB do Município Tipo Autor Emenda Tipo Autor Emenda(desc.)   Grupo Autor Emenda Grupo Autor Emenda(desc.)  Tipo de Crédito Tipo de Crédito(desc.) UF(desc.)  Prioridade Desbloqueio  Emenda Aprovada(Dot Atual) Valor Bloqueado da Emenda   Valor Impedido(por Beneficiário)   Valor Indicado(por Beneficiário)   Valor Priorizado(por Beneficiário)

            return new Partido
            {


                Sigla = columns[3],



            };


        }
    }
}
