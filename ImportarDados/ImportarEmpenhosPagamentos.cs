using Emendas.Data;
using EmendasModel;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;

namespace ImportarDados
{
    public static class ImportarEmpenhosPagamentos
    {

        public static void Importar()
        {

            var file = Path.GetFullPath("./csv TB_EMPENHOS_2018_tratado.csv");
            IEnumerable<EmendaEmpenho> list = ProcessCSV(file);
            (list);


            //using (var context = new EmendasContext())
            //{
            //    foreach (var emendaempenho in list)
            //    {
            //        var planoTrabalhoExistente = context.PlanoTrabalhos.Where(p => p.Codigo == emendaempenho.Emenda.PlanoTrabalho.Codigo).SingleOrDefault();

            //        if (planoTrabalhoExistente == null)
            //        {

            //            context.PlanoTrabalhos.Add(emendaempenho.Emenda.PlanoTrabalho);
            //        }
            //    }
            //}





            using (var context = new EmendasContext())
            {
                foreach (var emendaempenho in list)
                {
                    // Console.WriteLine(parla.Name);
                    if (!string.IsNullOrEmpty(emendaempenho.Empenho.CodigoEmpenho) && !string.IsNullOrEmpty(emendaempenho.Emenda.CodEmenda) && !string.IsNullOrEmpty(emendaempenho.Beneficiario.CNPJ))
                        if (!context.EmendaEmpenhos.Any(e => (e.Empenho.CodigoEmpenho == emendaempenho.Empenho.CodigoEmpenho) && (e.Emenda.CodEmenda == emendaempenho.Emenda.CodEmenda) && (e.Beneficiario.CNPJ == emendaempenho.Beneficiario.CNPJ)))
                        //
                        {
                            var emendaExistente = context.Emendas.Where(e => e.CodEmenda == emendaempenho.Emenda.CodEmenda).SingleOrDefault();

                            if (emendaExistente == null)
                            {
                                Console.WriteLine("Emenda Nao Encontrada com CodEmenda:" + emendaempenho.Emenda.CodEmenda);
                            }

                            var empenhoExistente = context.Empenhos.Where(e => e.CodigoEmpenho == emendaempenho.Empenho.CodigoEmpenho).SingleOrDefault();

                            if (empenhoExistente == null)
                            {
                                empenhoExistente = emendaempenho.Empenho;
                            }

                            //var planoTrabalhoExistente = context.PlanoTrabalhos.Where(e => e.Codigo == emendaempenho.Emenda.PlanoTrabalho.Codigo).SingleOrDefault();

                            //if (planoTrabalhoExistente == null && emendaExistente != null)
                            //{
                            //    emendaExistente.PlanoTrabalho=emendaempenho.Emenda.PlanoTrabalho;
                            //   // Console.WriteLine($"Plano trabalho {emendaempenho.Emenda.PlanoTrabalho.Codigo} referente a emenda {emendae}");
                            //}


                            var beneficiarioExistente = context.Beneficiarios.Where(e => e.CNPJ == emendaempenho.Beneficiario.CNPJ).SingleOrDefault();




                            if (empenhoExistente != null && emendaExistente != null)
                            {
                                emendaempenho.Emenda = emendaExistente;
                                emendaempenho.Empenho = empenhoExistente;
                                emendaempenho.Beneficiario = beneficiarioExistente;
                                context.EmendaEmpenhos.Add(emendaempenho);
                                Console.WriteLine("Gravando Emenda: " + emendaExistente.CodEmenda + " Empenho: " + empenhoExistente.CodigoEmpenho);

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
            var planoTrabalho = new PlanoTrabalho { Codigo = columns[5], Descricao = columns[6] };
            var beneficiario = new Beneficiario { CNPJ = columns[7], Nome = columns[8] };
            var empenho = new Empenho { CodigoEmpenho = columns[9] };
            var emenda = new Emenda
            {
                CodEmenda = columns[2],
                PlanoTrabalho = planoTrabalho
            };

            return new EmendaEmpenho
            {
                Emenda = emenda,
                Empenho = empenho,
                Beneficiario = beneficiario,    
                ValorEmpenhado = String.IsNullOrEmpty(columns[10]) ? 0 : Decimal.Parse(columns[10]),
                ValorPago= String.IsNullOrEmpty(columns[11]) ? 0 : Decimal.Parse(columns[11])
            };


        }
    }

}

