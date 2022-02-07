namespace bank_service.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updatedatabase : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.TransactionHistories", "RecevierName", c => c.String());
            DropColumn("dbo.TransactionHistories", "UpdatedAt");
        }
        
        public override void Down()
        {
            AddColumn("dbo.TransactionHistories", "UpdatedAt", c => c.DateTime(nullable: false));
            DropColumn("dbo.TransactionHistories", "RecevierName");
        }
    }
}
