namespace Controle.ORM.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class add_intervenant_intervention : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Intervenants",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Matricule = c.String(nullable: false, maxLength: 10),
                        Nom = c.String(nullable: false, maxLength: 50),
                        Prenom = c.String(nullable: false, maxLength: 50),
                        Vehicule_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Vehicules", t => t.Vehicule_ID)
                .Index(t => t.Vehicule_ID);
            
            CreateTable(
                "dbo.Interventions",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Adresse = c.String(),
                        DateOuvert = c.DateTime(nullable: false),
                        DateCloture = c.DateTime(nullable: false),
                        Cloturer = c.Boolean(nullable: false),
                        Intervenant_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Intervenants", t => t.Intervenant_ID)
                .Index(t => t.Intervenant_ID);
            
            CreateTable(
                "dbo.Vehicules",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Marque = c.String(nullable: false, maxLength: 50),
                        Modele = c.String(nullable: false, maxLength: 50),
                        Immatriculation = c.String(nullable: false, maxLength: 50),
                        VolumeUtile = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Disponible = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Intervenants", "Vehicule_ID", "dbo.Vehicules");
            DropForeignKey("dbo.Interventions", "Intervenant_ID", "dbo.Intervenants");
            DropIndex("dbo.Interventions", new[] { "Intervenant_ID" });
            DropIndex("dbo.Intervenants", new[] { "Vehicule_ID" });
            DropTable("dbo.Vehicules");
            DropTable("dbo.Interventions");
            DropTable("dbo.Intervenants");
        }
    }
}
