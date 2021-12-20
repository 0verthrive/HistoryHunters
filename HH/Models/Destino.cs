using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace HH.Models
{
    [Table("Destino")]
    public class Destino
    {
        [Key]
        public int ID { get; set; }
        [Required(ErrorMessage = "Informe o destino")]
        [StringLength(50)]
        public string Local { get; set; }
        [Required(ErrorMessage = "Informe o valor da viagem")]
        public double Preco { get; set; }
    }
}
