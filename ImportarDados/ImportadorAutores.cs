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

        public static void Importar()
        {
            IEnumerable<Parlamentar> list = ProcessCSVAutores("c:\\temp\\autores.csv");


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

        internal static IEnumerable<Parlamentar> ProcessCSVAutores(string csv)
        {
            return File.ReadAllLines(csv)
                .Skip(1)
                .Where(line => line.Length > 49)
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
                Partido=new Partido { Codigo= int.Parse(columns[6]) }


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
