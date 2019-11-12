using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Controle.ORM
{
    public class Intervention
    {
        [Key]
        public int ID { get; set; }
        public string Adresse { get; set; }
        public DateTime DateOuvert { get; set; }
        public DateTime DateCloture { get; set; }
        public bool Cloturer { get; set; }
        public virtual Intervenant Intervenant { get; set; }
        public virtual Vehicule Vehicule { get; set; }
        public virtual ICollection<Materiel> Materiels { get; set; }
        public Intervention()
        {
            Materiels = new List<Materiel>();
        }
    }
}
