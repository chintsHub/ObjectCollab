IF((select count(*) from DataObjectHierarchy) = 0)
Begin
 

SET IDENTITY_INSERT [dbo].[DataObjectHierarchy] ON 

 
INSERT [dbo].[DataObjectHierarchy] ([Id], [Name], [ParentId]) VALUES (1, N'Assetic3 Views', NULL)
 
INSERT [dbo].[DataObjectHierarchy] ([Id], [Name], [ParentId]) VALUES (2, N'Asset View', 1)
 
SET IDENTITY_INSERT [dbo].[DataObjectHierarchy] OFF
 
SET IDENTITY_INSERT [dbo].[DataObject] ON 

 
INSERT [dbo].[DataObject] ([DataObjectId], [DataObjectLabel], [GroupId], [DataObjectType]) VALUES (1, N'Building Assets', 2, 1)
 
SET IDENTITY_INSERT [dbo].[DataObject] OFF
 
SET IDENTITY_INSERT [dbo].[OleDbConnection] ON 

 
INSERT [dbo].[OleDbConnection] ([ConnectionId], [ConnectionName], [ConnectionString], [Provider]) VALUES (1, N'Assetic3', N'Password=assetic3password;Persist Security Info=True;User ID=assetic3user;Initial Catalog=OC4;Data Source=BEAK\CHINTSSQL2012', 1)
 
SET IDENTITY_INSERT [dbo].[OleDbConnection] OFF
 
INSERT [dbo].[OleDbObject] ([DataObjectId], [ConnectionId], [ObjectName], [WhereClause], [OledbProvider]) VALUES (1, 1, N'ComplexAssets', NULL, 1)
 


 
INSERT [dbo].[AspNetUsers] ([Id], [FirstName], [LastName], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) 
   VALUES (N'afa4c0c5-537d-44a7-a0dd-6e1c1ea7c47d', N'John', N'Smith', NULL, 0, N'APS+ZIEswXOlvtGKzbSyN87hn6K1u6F7u6bRu2rYjHFwm8HR0YyHxTxMFWGXmwwkrg==', N'9a43db66-4f8b-4f56-b1c3-c096143f96f2', NULL, 0, 0, NULL, 0, 0, N'admin@assetic.com')
 

 
INSERT [dbo].[AspNetRoles] ([Id], [Name], [Discriminator]) VALUES (N'1028a283-3387-4c5e-b510-8a5cee5994f4', N'admin', N'Role')
 
INSERT [dbo].[AspNetRoles] ([Id], [Name], [Discriminator]) VALUES (N'40b0c156-76d5-4fae-98ef-c24beed2d215', N'L2 Data Collector', N'Role')
 
INSERT [dbo].[AspNetRoles] ([Id], [Name], [Discriminator]) VALUES (N'a747348b-ef39-4f69-8dc4-6d3037bcbdfc', N'user', N'Role')
 
INSERT [dbo].[AspNetRoles] ([Id], [Name], [Discriminator]) VALUES (N'bb6fefc8-1c4a-4591-bf45-3a55003bb857', N'Asset Manager', N'Role')
 

 
INSERT [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'afa4c0c5-537d-44a7-a0dd-6e1c1ea7c47d', N'1028a283-3387-4c5e-b510-8a5cee5994f4')
 

 


END
 

