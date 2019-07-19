


--Address table

SET IDENTITY_INSERT [dbo].[Addresses] ON
INSERT INTO [dbo].[Addresses] ([AddressId], [City], [Street], [Number]) VALUES (1, N'פתח תקווה', N'רוטשילד', 3)
INSERT INTO [dbo].[Addresses] ([AddressId], [City], [Street], [Number]) VALUES (2, N'בני ברק', N'הבנים', 1)
INSERT INTO [dbo].[Addresses] ([AddressId], [City], [Street], [Number]) VALUES (3, N'רמת גן', N'הרואה', 20)
INSERT INTO [dbo].[Addresses] ([AddressId], [City], [Street], [Number]) VALUES (5, N'תל אביב', N'דיזינגוף', 39)
INSERT INTO [dbo].[Addresses] ([AddressId], [City], [Street], [Number]) VALUES (6, N'בני ברק', N'אבן גבירול', 17)
SET IDENTITY_INSERT [dbo].[Addresses] OFF

--Branches table

SET IDENTITY_INSERT [dbo].[Branch] ON
INSERT INTO [dbo].[Branch] ([BranchId], [Name], [Phone], [StartTime], [EndTime], [IsBabySitter], [BranchAddressAddressId]) VALUES (2, N'תל אביב -רמת אביב', N'03-6166667', N'2019-01-02 00:00:00', N'2019-03-04 00:00:00', 1, NULL)
INSERT INTO [dbo].[Branch] ([BranchId], [Name], [Phone], [StartTime], [EndTime], [IsBabySitter], [BranchAddressAddressId]) VALUES (3, N'חולון', N'03-6123456', N'2018-03-04 00:00:00', N'2018-04-05 00:00:00', 0, NULL)
INSERT INTO [dbo].[Branch] ([BranchId], [Name], [Phone], [StartTime], [EndTime], [IsBabySitter], [BranchAddressAddressId]) VALUES (4, N'ירושלים- מרכז העיר', N'02-3125674', N'2019-12-10 00:00:00', N'2019-08-04 00:00:00', 1, NULL)
SET IDENTITY_INSERT [dbo].[Branch] OFF

--Traning table

SET IDENTITY_INSERT [dbo].[Training] ON
INSERT INTO [dbo].[Training] ([TrainingId], [Name], [Description], [VideoUrl]) VALUES (1, N'אירובי', NULL, NULL)
INSERT INTO [dbo].[Training] ([TrainingId], [Name], [Description], [VideoUrl]) VALUES (2, N'זומבה', NULL, NULL)
INSERT INTO [dbo].[Training] ([TrainingId], [Name], [Description], [VideoUrl]) VALUES (3, N'אימון hit', NULL, NULL)
INSERT INTO [dbo].[Training] ([TrainingId], [Name], [Description], [VideoUrl]) VALUES (4, N'TRX', NULL, NULL)
INSERT INTO [dbo].[Training] ([TrainingId], [Name], [Description], [VideoUrl]) VALUES (5, N'פילאטיס', NULL, NULL)
INSERT INTO [dbo].[Training] ([TrainingId], [Name], [Description], [VideoUrl]) VALUES (6, N'פילאטיס מכשירים', NULL, NULL)
SET IDENTITY_INSERT [dbo].[Training] OFF


--Lessons table

SET IDENTITY_INSERT [dbo].[Lesson] ON
INSERT INTO [dbo].[Lesson] ([LessonId], [BranchId1], [TrainingId1], [StartTime], [EndTime], [TeacherName], [RegistrantMax], [RegistrantNum]) VALUES (2, 2, 2, N'2018-02-01 00:00:00', N'2018-04-03 00:00:00', N'חגית מזרחי', 20, 2)
INSERT INTO [dbo].[Lesson] ([LessonId], [BranchId1], [TrainingId1], [StartTime], [EndTime], [TeacherName], [RegistrantMax], [RegistrantNum]) VALUES (5, 3, 2, N'2018-02-01 00:00:00', N'2018-02-01 00:00:00', N'גילה ארנון', 10, 5)
INSERT INTO [dbo].[Lesson] ([LessonId], [BranchId1], [TrainingId1], [StartTime], [EndTime], [TeacherName], [RegistrantMax], [RegistrantNum]) VALUES (10, 2, 3, N'2019-01-02 00:00:00', N'2018-02-01 00:00:00', N'מיכל רביד', 15, 10)
SET IDENTITY_INSERT [dbo].[Lesson] OFF

--Users table

SET IDENTITY_INSERT [dbo].[Users] ON
INSERT INTO [dbo].[Users] ([UserId], [FirstName], [LastName], [Email], [Phone], [Age], [UserAdressAddressId], [UserName], [Password], [ProfieImgSrc]) VALUES (2, N'תמר', N'וקסמן', N'@gmail.com', NULL, 30, 1, N'tamar', N'123', NULL)
INSERT INTO [dbo].[Users] ([UserId], [FirstName], [LastName], [Email], [Phone], [Age], [UserAdressAddressId], [UserName], [Password], [ProfieImgSrc]) VALUES (4, N'שרה', N'אבידר', NULL, NULL, 25, 2, NULL, NULL, NULL)
INSERT INTO [dbo].[Users] ([UserId], [FirstName], [LastName], [Email], [Phone], [Age], [UserAdressAddressId], [UserName], [Password], [ProfieImgSrc]) VALUES (5, N'יעל', N'בן משה', NULL, NULL, 23, 3, NULL, NULL, NULL)
INSERT INTO [dbo].[Users] ([UserId], [FirstName], [LastName], [Email], [Phone], [Age], [UserAdressAddressId], [UserName], [Password], [ProfieImgSrc]) VALUES (6, N'מיכל', N'רובין', NULL, NULL, 45, 5, NULL, NULL, NULL)
INSERT INTO [dbo].[Users] ([UserId], [FirstName], [LastName], [Email], [Phone], [Age], [UserAdressAddressId], [UserName], [Password], [ProfieImgSrc]) VALUES (7, N'שושנה', N'כהן', NULL, NULL, 56, 1, NULL, NULL, NULL)
SET IDENTITY_INSERT [dbo].[Users] OFF
initTables.sql
מציג את initTables.sql.
