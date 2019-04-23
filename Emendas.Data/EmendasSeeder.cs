using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Microsoft.AspNetCore.Hosting;
using Newtonsoft.Json;

namespace Emendas.Data
{
    public class EmendasSeeder
    {
        private EmendasContext _context;
        private IHostingEnvironment _hosting;

        public EmendasSeeder(EmendasContext context, IHostingEnvironment hosting )
        {
            _context = context;
            _hosting = hosting;

        }


        public void Seed()
        {
            _context.Database.EnsureCreated();


            if (!_context.Users.Any())
            {
                var user = new EmendasModel.User() {
                 UserName="brunogvaz@hotmail.com",
                 };
            }

            var file = Path.Combine(_hosting.ContentRootPath, "Data/emendas.csv" );
            var json = File.ReadAllText(file);
            var emendas = JsonConvert.DeserializeObject<IEnumerable<EmendasModel.Emenda>>(json);
            _context.AddRange(emendas);


        }
    }
}
