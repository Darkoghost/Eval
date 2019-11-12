namespace Controle.ORM.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class add_lereste : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Intervenants", "Vehicule_ID", "dbo.Vehicules");
            DropIndex("dbo.Intervenants", new[] { "Vehicule_ID" });
            CreateTable(
                "dbo.Administrations",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Materiels",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Designation = c.String(nullable: false, maxLength: 20),
                        Description = c.String(maxLength: 50),
                        DateAchat = c.DateTime(nullable: false),
                        Disponible = c.Boolean(nullable: false),
                        Administration_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Administrations", t => t.Administration_ID)
                .Index(t => t.Administration_ID);
            
            CreateTable(
                "dbo.MaterielInterventions",
                c => new
                    {
                        Materiel_ID = c.Int(nullable: false),
                        Intervention_ID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Materiel_ID, t.Intervention_ID })
                .ForeignKey("dbo.Materiels", t => t.Materiel_ID, cascadeDelete: true)
                .ForeignKey("dbo.Interventions", t => t.Intervention_ID, cascadeDelete: true)
                .Index(t => t.Materiel_ID)
                .Index(t => t.Intervention_ID);
            
            AddColumn("dbo.Intervenants", "Administration_ID", c => c.Int());
            AddColumn("dbo.Interventions", "Vehicule_ID", c => c.Int());
            AddColumn("dbo.Vehicules", "Administration_ID", c => c.Int());
            CreateIndex("dbo.Intervenants", "Administration_ID");
            CreateIndex("dbo.Interventions", "Vehicule_ID");
            CreateIndex("dbo.Vehicules", "Administration_ID");
            AddForeignKey("dbo.Intervenants", "Administration_ID", "dbo.Administrations", "ID");
            AddForeignKey("dbo.Vehicules", "Administration_ID", "dbo.Administrations", "ID");
            AddForeignKey("dbo.Interventions", "Vehicule_ID", "dbo.Vehicules", "ID");
            DropColumn("dbo.Intervenants", "Vehicule_ID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Intervenants", "Vehicule_ID", c => c.Int());
            DropForeignKey("dbo.Interventions", "Vehicule_ID", "dbo.Vehicules");
            DropForeignKey("dbo.Vehicules", "Administration_ID", "dbo.Administrations");
            DropForeignKey("dbo.MaterielInterventions", "Intervention_ID", "dbo.Interventions");
            DropForeignKey("dbo.MaterielInterventions", "Materiel_ID", "dbo.Materiels");
            DropForeignKey("dbo.Materiels", "Administration_ID", "dbo.Administrations");
            DropForeignKey("dbo.Intervenants", "Administration_ID", "dbo.Administrations");
            DropIndex("dbo.MaterielInterventions", new[] { "Intervention_ID" });
            DropIndex("dbo.MaterielInterventions", new[] { "Materiel_ID" });
            DropIndex("dbo.Vehicules", new[] { "Administration_ID" });
            DropIndex("dbo.Materiels", new[] { "Administration_ID" });
            DropIndex("dbo.Interventions", new[] { "Vehicule_ID" });
            DropIndex("dbo.Intervenants", new[] { "Administration_ID" });
            DropColumn("dbo.Vehicules", "Administration_ID");
            DropColumn("dbo.Interventions", "Vehicule_ID");
            DropColumn("dbo.Intervenants", "Administration_ID");
            DropTable("dbo.MaterielInterventions");
            DropTable("dbo.Materiels");
            DropTable("dbo.Administrations");
            CreateIndex("dbo.Intervenants", "Vehicule_ID");
            AddForeignKey("dbo.Intervenants", "Vehicule_ID", "dbo.Vehicules", "ID");
        }
    }
}
