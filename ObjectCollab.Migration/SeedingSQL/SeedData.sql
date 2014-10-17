IF((select count(*) from DataObjectHierarchy) = 0)
Begin
 
SET IDENTITY_INSERT [dbo].[DataObjectHierarchy] ON 

 
INSERT [dbo].[DataObjectHierarchy] ([Id], [Name], [ParentId]) VALUES (1, N'Assetic3 Views', NULL)
 
INSERT [dbo].[DataObjectHierarchy] ([Id], [Name], [ParentId]) VALUES (2, N'Asset View', 1)
 
SET IDENTITY_INSERT [dbo].[DataObjectHierarchy] OFF
 
SET IDENTITY_INSERT [dbo].[DataObject] ON 

 
INSERT [dbo].[DataObject] ([DataObjectId], [DataObjectLabel], [GroupId]) VALUES (1, N'Building Assets', 2)
 
SET IDENTITY_INSERT [dbo].[DataObject] OFF
 
SET IDENTITY_INSERT [dbo].[OleDbConnection] ON 

 
INSERT [dbo].[OleDbConnection] ([ConnectionId], [ConnectionName], [ConnectionString], [Provider]) VALUES (1, N'Assetic3', N'Password=assetic3password;Persist Security Info=True;User ID=assetic3user;Initial Catalog=OC4;Data Source=BEAK\CHINTSSQL2012', 1)
 
SET IDENTITY_INSERT [dbo].[OleDbConnection] OFF
 
SET IDENTITY_INSERT [dbo].[User] ON 

 
INSERT [dbo].[User] ([UserId], [UserName], [Password], [Role]) VALUES (1, N'chints', N'systemadmin', 1)
 
INSERT [dbo].[User] ([UserId], [UserName], [Password], [Role]) VALUES (2, N'admin', N'admin', 2)
 
INSERT [dbo].[User] ([UserId], [UserName], [Password], [Role]) VALUES (4, N'analyst', N'analyst', 3)
 
SET IDENTITY_INSERT [dbo].[User] OFF

END
 

