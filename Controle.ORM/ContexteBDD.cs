using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Controle.ORM
{
    public class ContexteBDD : DbContext
    {
        public ContexteBDD() : base("maChaineDeConnexion")
        {

        }

        public virtual DbSet<Intervenant> Intervenants { get; set; }
        public virtual DbSet<Intervention> Interventions { get; set; }
        public virtual DbSet<Vehicule> Vehicules { get; set; }
        public virtual DbSet<Materiel> Materiels { get; set; }
        public virtual DbSet<Administration> Administrations { get; set; }
    }
}
