using Emendas.Data;
using EmendasModel;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace ImportarDados
{
    public class ImportadorPlanoTrabalho
    {
        private static void Importar()
        {
            IEnumerable<Parlamentar> list = ProcessCSVAutores("c:\\temp\\autores.csv");


            using (var context = new EmendasContext())
            {
                foreach (var parla in list)
                {
                    // Console.WriteLine(parla.Name);

                    if (!context.Parlamentars.Any(p => p.CodParlamentar == parla.CodParlamentar) && (parla.TipoParlamentar == 1 || parla.TipoParlamentar == 2))
                    {
                        context.Parlamentars.Add(parla);
                    }

                }
                context.SaveChanges();
            }
        }

        internal static IEnumerable<Parlamentar> ProcessCSVAutores(string csv)
        {
            return File.ReadAllLines(csv)
                .Skip(1)
                .Where(line => line.Length > 59)
                .Select(ParseFromCsv).ToList();
        }

        private static Parlamentar ParseFromCsv(string line)
        {
            var columns = line.Split(';');

            return new Parlamentar
            {
                CodParlamentar = int.Parse(columns[0]),
                TipoParlamentar = int.Parse(columns[2]),
                Name = columns[4],


            };


        }

    }
}
