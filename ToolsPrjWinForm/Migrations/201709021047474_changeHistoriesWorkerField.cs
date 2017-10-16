namespace ToolsPrjWinForm.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class changeHistoriesWorkerField : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Histories", "Worker_Id", "dbo.Workers");
            DropIndex("dbo.Histories", new[] { "Worker_Id" });
            AddColumn("dbo.Histories", "Worker", c => c.String());
            DropColumn("dbo.Histories", "Worker_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Histories", "Worker_Id", c => c.Guid());
            DropColumn("dbo.Histories", "Worker");
            CreateIndex("dbo.Histories", "Worker_Id");
            AddForeignKey("dbo.Histories", "Worker_Id", "dbo.Workers", "Id");
        }
    }
}
