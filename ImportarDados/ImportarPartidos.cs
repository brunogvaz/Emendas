using Emendas.Data;
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
            IEnumerable<Partido> list = ProcessCSVPartidos("c:\\temp\\partidos.csv");


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
            var partidoexistente = context.Partidos.Where(p => p.Sigla == part.Sigla || p.Codigo==part.Codigo).SingleOrDefault();
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

            return new Partido
            {
                Codigo = int.Parse(columns[0]),
                Sigla = columns[1],
                Name = columns[2],


            };


        }
    }
}
