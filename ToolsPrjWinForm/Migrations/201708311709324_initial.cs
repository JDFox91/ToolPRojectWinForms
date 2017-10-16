namespace ToolsPrjWinForm.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Groups",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Name = c.String(),
                        CreateDate = c.DateTime(nullable: false),
                        ModifyDate = c.DateTime(nullable: false),
                        DeleteDate = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Items",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Name = c.String(),
                        IdNum = c.String(),
                        Code = c.String(),
                        CheckDate = c.DateTime(nullable: false),
                        GiveDate = c.DateTime(),
                        Condition = c.Int(nullable: false),
                        CreateDate = c.DateTime(nullable: false),
                        ModifyDate = c.DateTime(nullable: false),
                        DeleteDate = c.DateTime(),
                        Group_Id = c.Guid(),
                        Worker_Id = c.Guid(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Groups", t => t.Group_Id)
                .ForeignKey("dbo.Workers", t => t.Worker_Id)
                .Index(t => t.Group_Id)
                .Index(t => t.Worker_Id);
            
            CreateTable(
                "dbo.Workers",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        WorkerName = c.String(),
                        PersonalNumber = c.Int(nullable: false),
                        CreateDate = c.DateTime(nullable: false),
                        ModifyDate = c.DateTime(nullable: false),
                        DeleteDate = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Items", "Worker_Id", "dbo.Workers");
            DropForeignKey("dbo.Items", "Group_Id", "dbo.Groups");
            DropIndex("dbo.Items", new[] { "Worker_Id" });
            DropIndex("dbo.Items", new[] { "Group_Id" });
            DropTable("dbo.Workers");
            DropTable("dbo.Items");
            DropTable("dbo.Groups");
        }
    }
}
