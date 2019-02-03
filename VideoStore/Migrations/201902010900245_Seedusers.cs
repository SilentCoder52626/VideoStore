namespace VideoStore.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Seedusers : DbMigration
    {
        public override void Up()
        {
            Sql(@"
                INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'0abfdcbe-cc94-4dad-b1e6-82b75eecfb10', N'admin@videostore.com', 0, N'AP1tPMtlq9nags2WLGO7oQ17RCmJrJ3qULk/VmhDepW8rbkgKgPd497ag1K1QWqNsA==', N'e38bf078-3d2a-4caa-bdb0-9b56845d53ca', NULL, 0, 0, NULL, 1, 0, N'admin@videostore.com')
                INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'69612e30-aae3-4f42-841c-54ef9974a56f', N'guest@videostore.com', 0, N'ADQurNIjHr8Vb4g9aqMLi4OsPJKUtkfCPUeEKa7CtpwHYRNOui6GG+JKmf/5K5JBUw==', N'72f85571-add7-4ac2-b5bd-fdc8738a1cd8', NULL, 0, 0, NULL, 1, 0, N'guest@videostore.com')
                INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'81a63bb8-ffe7-40d7-9972-a08da9328d7d', N'CanManageMovie')
                INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'0abfdcbe-cc94-4dad-b1e6-82b75eecfb10', N'81a63bb8-ffe7-40d7-9972-a08da9328d7d')

            ");
        }
        
        public override void Down()
        {
        }
    }
}
