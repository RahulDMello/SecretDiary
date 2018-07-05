namespace SecretDiary.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class third : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.StickyNotes", "User_Id", "dbo.AspNetUsers");
            DropIndex("dbo.StickyNotes", new[] { "User_Id" });
            RenameColumn(table: "dbo.DiaryEntries", name: "User_Id", newName: "UserID");
            RenameIndex(table: "dbo.DiaryEntries", name: "IX_User_Id", newName: "IX_UserID");
            AddColumn("dbo.AspNetUsers", "Note_EntryID", c => c.Int());
            AddColumn("dbo.StickyNotes", "UserID", c => c.String());
            CreateIndex("dbo.AspNetUsers", "Note_EntryID");
            AddForeignKey("dbo.AspNetUsers", "Note_EntryID", "dbo.StickyNotes", "EntryID");
            DropColumn("dbo.StickyNotes", "User_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.StickyNotes", "User_Id", c => c.String(maxLength: 128));
            DropForeignKey("dbo.AspNetUsers", "Note_EntryID", "dbo.StickyNotes");
            DropIndex("dbo.AspNetUsers", new[] { "Note_EntryID" });
            DropColumn("dbo.StickyNotes", "UserID");
            DropColumn("dbo.AspNetUsers", "Note_EntryID");
            RenameIndex(table: "dbo.DiaryEntries", name: "IX_UserID", newName: "IX_User_Id");
            RenameColumn(table: "dbo.DiaryEntries", name: "UserID", newName: "User_Id");
            CreateIndex("dbo.StickyNotes", "User_Id");
            AddForeignKey("dbo.StickyNotes", "User_Id", "dbo.AspNetUsers", "Id");
        }
    }
}
