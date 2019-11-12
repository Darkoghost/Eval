using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Controle.ORM
{
    public class Vehicule
    {
        [Key]
        public int ID { get; set; }
        [Required]
        [StringLength(50)]
        public string Marque { get; set; }
        [Required]
        [StringLength(50)]
        public string Modele { get; set; }
        [Required]
        [StringLength(50)]
        public string Immatriculation { get; set; }
        public decimal VolumeUtile { get; set; }
        public bool Disponible { get; set; }
        public virtual ICollection<Intervention> Interventions { get; set; }
        public virtual Administration Administration { get; set; }

        public Vehicule()
        {
            Interventions = new List<Intervention>();
        }
    }

}
