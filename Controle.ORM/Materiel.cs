using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Controle.ORM
{
    public class Materiel
    {
        [Key]
        public int ID { get; set; }
        [Required]
        [StringLength(20)]
        public string Designation { get; set; }
        [StringLength(50)]
        public string Description { get; set; }
        public DateTime DateAchat { get; set; }
        public bool Disponible { get; set; }
        public virtual ICollection<Intervention> Interventions { get; set; }
        public virtual Administration Administration { get; set; }

        public Materiel()
        {
            Interventions = new List<Intervention>();
        }
    }
}
