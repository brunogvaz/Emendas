using System;
using System.Collections.Generic;
using System.Text;

namespace EmendasModel
{
    public class Partido
    {
        public int Id { get; set; }
        public int Codigo { get; set; }
        public string Sigla { get; set; }
        public string Name { get; set; }
        public ICollection<Parlamentar> Parlamentars { get; set; }
    }
}
