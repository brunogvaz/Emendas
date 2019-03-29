using Emendas.Data;
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
            IEnumerable<Emenda> list = ProcessCSV("c:\\temp\\emendas.csv");


            using (var context = new EmendasContext())
            {
                foreach (var emenda in list)
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
                .Select(ParseFromCsv).ToList();
        }

        private static Emenda ParseFromCsv(string line)
        {
            var columns = line.Split(';');

            return new Emenda
            {
                CodEmenda = columns[2],
                Parlamentar = new Parlamentar { CodParlamentar = int.Parse(columns[0]) },
                Valor = Decimal.Parse(columns[13])



            };


        }
    }
}

