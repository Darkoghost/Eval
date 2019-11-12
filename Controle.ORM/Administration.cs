using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Controle.ORM
{
    public class Administration
    {
        [Key]
        public int ID { get; set; }
        public string Admin { get; set; }
        public virtual ICollection<Materiel> Materiels { get; set; }
        public virtual ICollection<Intervenant> Intervenants { get; set; }
        public virtual ICollection<Vehicule> Vehicules { get; set; }
        public Administration()
        {
            Materiels = new List<Materiel>();
            Intervenants = new List<Intervenant>();
            Vehicules = new List<Vehicule>();
        }
    }
}
