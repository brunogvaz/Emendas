using Emendas.Data;
using EmendasModel;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace ImportarDados
{
    public static class ImportarEmpenhosPagamentos
    {

        public static void Importar()
        {
            IEnumerable<EmendaEmpenho> list = ProcessCSV("c:\\temp\\csv TB_EMPENHOS_2018_tratado elmar.csv");


            using (var context = new EmendasContext())
            {
                foreach (var emendaempenho in list)
                {
                    // Console.WriteLine(parla.Name);
                    if (!string.IsNullOrEmpty(emendaempenho.Empenho.CodigoEmpenho) && !string.IsNullOrEmpty(emendaempenho.Emenda.CodEmenda))
                    if (!context.EmendaEmpenhos.Any(e => (e.Empenho.CodigoEmpenho == emendaempenho.Empenho.CodigoEmpenho) && (e.Emenda.CodEmenda==emendaempenho.Emenda.CodEmenda)))
                    {
                        var emendaExistente = context.Emendas.Where(e => e.CodEmenda == emendaempenho.Emenda.CodEmenda).SingleOrDefault();

                        if (emendaExistente == null )
                        {
                            Console.WriteLine("Emenda Nao Encontrada com CodEmenda:" + emendaempenho.Emenda.CodEmenda);
                        }

                        var empenhoExistente = context.Empenhos.Where(e => e.CodigoEmpenho == emendaempenho.Empenho.CodigoEmpenho).SingleOrDefault();

                        if (empenhoExistente == null)
                        {
                            empenhoExistente=new Empenho { CodigoEmpenho = emendaempenho.Empenho.CodigoEmpenho };
                        }



                        if (empenhoExistente != null  && emendaExistente != null)
                        {
                            emendaempenho.Emenda = emendaExistente;
                            emendaempenho.Empenho = empenhoExistente;
                            context.EmendaEmpenhos.Add(emendaempenho);
                            Console.WriteLine("Gravando Emenda: " + emendaExistente.CodEmenda  + " Empenho: " + empenhoExistente.CodigoEmpenho );

                        }
                       
                    }

                }
                
                context.SaveChanges();
            }
        }

        internal static IEnumerable<EmendaEmpenho> ProcessCSV(string csv)
        {
            return File.ReadAllLines(csv)
                .Skip(1)
                .Where(line => line.Length > 1)
                .Select(ParseFromCsv).ToList();
        }

        private static EmendaEmpenho ParseFromCsv(string line)
        {
            var columns = line.Split(';');

            return new EmendaEmpenho
            {
                Emenda = new Emenda { CodEmenda = columns[2] },
                Empenho= new Empenho { CodigoEmpenho= columns[9]},
                      
                ValorEmpenhado = String.IsNullOrEmpty(columns[10]) ? 0 : Decimal.Parse(columns[10]),
                ValorPago= String.IsNullOrEmpty(columns[11]) ? 0 : Decimal.Parse(columns[11])
            };


        }
    }

}

