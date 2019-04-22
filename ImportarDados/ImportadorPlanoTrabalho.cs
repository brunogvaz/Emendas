using Emendas.Data;
using EmendasModel;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace ImportarDados
{
    public class ImportadorPlanoTrabalho { 
        private static void Importar()
        {
            IEnumerable<Parlamentar> list = ProcessCSVPlano("c:\\temp\\autores.csv");


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

        internal new IEnumerable<PlanoTrabalho> ProcessCSVAuTores(LinhaImportacaoEmendasDumpSiop csv)
        {
            return base.ProcessCSV(csv).Select(ParseFromCsv).ToList();
        }
       
        private static PlanoTrabalho ParseFromCsv(string line)
        {
            var columns = line.Split(';');

            return new PlanoTrabalho
            {
                //TODO


            };


        }

    }
}
