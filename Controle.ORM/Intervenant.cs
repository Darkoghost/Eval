using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Controle.ORM
{
    public class Intervenant
    {
        [Key]
        public int ID { get; set; }
        [Required]
        [StringLength(10)]
        public string Matricule { get; set; }
        [Required]
        [StringLength(50)]
        public string Nom { get; set; }
        [Required]
        [StringLength(50)]
        public string Prenom { get; set; }
        public virtual ICollection<Intervention> Interventions { get; set; }
        public virtual Administration Administration { get; set; }


        public Intervenant()
        {
            Interventions = new List<Intervention>();
        }


    }
}
