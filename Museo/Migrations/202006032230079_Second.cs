namespace Museo.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Second : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Artists",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nombre = c.String(),
                        FechaNac = c.DateTime(nullable: false),
                        Descripcion = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Artworks",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nombre = c.String(),
                        Tipo = c.String(),
                        Fecha = c.DateTime(nullable: false),
                        Descripcion = c.String(),
                        ImgUrl = c.String(),
                        ArtistId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Artists", t => t.ArtistId, cascadeDelete: true)
                .Index(t => t.ArtistId);
            
            CreateTable(
                "dbo.Countries",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        NombrePais = c.String(),
                        ArtistId = c.Int(),
                        ArtworkId = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Artists", t => t.ArtistId)
                .ForeignKey("dbo.Artworks", t => t.ArtworkId)
                .Index(t => t.ArtistId)
                .Index(t => t.ArtworkId);
            
            CreateTable(
                "dbo.Tourists",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId)
                .Index(t => t.UserId);
            
            AddColumn("dbo.AspNetUsers", "FirstName", c => c.String(maxLength: 50));
            AddColumn("dbo.AspNetUsers", "Lastname", c => c.String(maxLength: 50));
            AddColumn("dbo.AspNetUsers", "Address", c => c.String(maxLength: 400));
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Tourists", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.Countries", "ArtworkId", "dbo.Artworks");
            DropForeignKey("dbo.Countries", "ArtistId", "dbo.Artists");
            DropForeignKey("dbo.Artworks", "ArtistId", "dbo.Artists");
            DropIndex("dbo.Tourists", new[] { "UserId" });
            DropIndex("dbo.Countries", new[] { "ArtworkId" });
            DropIndex("dbo.Countries", new[] { "ArtistId" });
            DropIndex("dbo.Artworks", new[] { "ArtistId" });
            DropColumn("dbo.AspNetUsers", "Address");
            DropColumn("dbo.AspNetUsers", "Lastname");
            DropColumn("dbo.AspNetUsers", "FirstName");
            DropTable("dbo.Tourists");
            DropTable("dbo.Countries");
            DropTable("dbo.Artworks");
            DropTable("dbo.Artists");
        }
    }
}
