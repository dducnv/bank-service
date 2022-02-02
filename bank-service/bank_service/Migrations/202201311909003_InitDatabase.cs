namespace bank_service.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitDatabase : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Accounts",
                c => new
                    {
                        AccountNumber = c.Int(nullable: false, identity: true),
                        FistName = c.String(),
                        LastName = c.String(),
                        Password = c.String(),
                        PhoneNumber = c.String(),
                        Address = c.String(),
                        Email = c.String(),
                        IndetityNumber = c.String(),
                        Birthday = c.DateTime(nullable: false),
                        CreatedAt = c.DateTime(nullable: false),
                        UpdatedAt = c.DateTime(nullable: false),
                        Status = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.AccountNumber);
            
            CreateTable(
                "dbo.Balances",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        AccountNumber = c.Int(nullable: false),
                        Value = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Accounts", t => t.AccountNumber, cascadeDelete: true)
                .Index(t => t.AccountNumber);
            
            CreateTable(
                "dbo.TransactionHistories",
                c => new
                    {
                        TransactionId = c.String(nullable: false, maxLength: 128),
                        SenderName = c.String(),
                        Amount = c.Double(nullable: false),
                        SenderAccountNumber = c.String(),
                        RecevierAccountNumber = c.String(),
                        Message = c.String(),
                        TransactionType = c.String(),
                        CreatedAt = c.DateTime(nullable: false),
                        UpdatedAt = c.DateTime(nullable: false),
                        Status = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.TransactionId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Balances", "AccountNumber", "dbo.Accounts");
            DropIndex("dbo.Balances", new[] { "AccountNumber" });
            DropTable("dbo.TransactionHistories");
            DropTable("dbo.Balances");
            DropTable("dbo.Accounts");
        }
    }
}
