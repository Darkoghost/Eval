using Controle.ORM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Controle.console
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var db = new ContexteBDD())
            {
                var Date = DateTime.Now;

                var admin = new Administration()
                {
                    Admin = "Big Brother"
                };

                var person = new Intervenant()
                {
                    Matricule = "A92B",
                    Nom = "Pampa",
                    Prenom = "Juju"
                };

                var inter = new Intervention()
                {
                    Adresse = "32 Rue du Poney des Sables",
                    DateOuvert = Date,
                    DateCloture = Date.AddDays(2),
                    Cloturer = false
                };

                var vehicule = new Vehicule()
                {
                    Marque = "Citroen",
                    Modele = "Tesla",
                    Immatriculation = "COM2T17",
                    VolumeUtile = 25,
                    Disponible = true
                };

                var materiel = new Materiel()
                {
                    Designation = "Vis de qualité",
                    DateAchat = Date,
                    Disponible = true
                };

                db.Administrations.Add(admin);
                db.Intervenants.Add(person);
                db.Interventions.Add(inter);
                db.Vehicules.Add(vehicule);
                db.Materiels.Add(materiel);
                db.SaveChanges();
            }
        }
    }
}
