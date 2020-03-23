using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TestFast.Api.Model
{
    public class ClienteModel
    {
        public long Id { get; set; }
        [Required]
        public string Nome { get; set; }
        [Required]
        public long Documento { get; set; }
    }
}
