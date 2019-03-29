using System;
using System.Collections.Generic;
using System.Text;

namespace EmendasModel
{
    public class Empenho
    {
        public int Id { get; set; }
        public string CodigoEmpenho { get; set; }
        public virtual ICollection<EmendaEmpenho> EmendaEmpenhos { get; set; }
        
    }
}
