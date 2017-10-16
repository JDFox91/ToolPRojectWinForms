namespace ToolsPrjWinForm.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addHistory : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Histories",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        ActDate = c.DateTime(),
                        Description = c.String(),
                        CreateDate = c.DateTime(nullable: false),
                        ModifyDate = c.DateTime(nullable: false),
                        DeleteDate = c.DateTime(),
                        Item_Id = c.Guid(),
                        Worker_Id = c.Guid(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Items", t => t.Item_Id)
                .ForeignKey("dbo.Workers", t => t.Worker_Id)
                .Index(t => t.Item_Id)
                .Index(t => t.Worker_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Histories", "Worker_Id", "dbo.Workers");
            DropForeignKey("dbo.Histories", "Item_Id", "dbo.Items");
            DropIndex("dbo.Histories", new[] { "Worker_Id" });
            DropIndex("dbo.Histories", new[] { "Item_Id" });
            DropTable("dbo.Histories");
        }
    }
}
