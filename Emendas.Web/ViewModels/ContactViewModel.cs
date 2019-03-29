using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Emendas.Web.ViewModels
{
    public class ContactViewModel
    {   [Required, MinLength(5)]
        public string Name { get; set; }
        [Required]
        public string Subject { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        [ MaxLength(250,ErrorMessage ="Muito Longo !!!!!!!!!!!")]
        public string Msg { get; set; }
    }
}
