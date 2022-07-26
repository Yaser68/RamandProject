USE [LoginProject]
GO
/****** Object:  Table [dbo].[User]    Script Date: 7/21/2022 6:02:08 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[User](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[UserName] [nvarchar](50) NOT NULL,
	[Password] [nvarchar](150) NOT NULL,
 CONSTRAINT [PK_User] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[User] ON 

INSERT [dbo].[User] ([Id], [UserName], [Password]) VALUES (1003, N'yaser', N'E10ADC3949BA59ABBE56E057F20F883E')
INSERT [dbo].[User] ([Id], [UserName], [Password]) VALUES (1004, N'Sahar', N'81DC9BDB52D04DC20036DBD8313ED055')
SET IDENTITY_INSERT [dbo].[User] OFF
GO
/****** Object:  StoredProcedure [dbo].[SP_User_Exist]    Script Date: 7/21/2022 6:02:08 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[SP_User_Exist] 
	@UserName nvarchar(50)
AS
BEGIN
	
	SET NOCOUNT ON;

   select count(1) from [User] where UserName=@UserName
END
GO
/****** Object:  StoredProcedure [dbo].[SP_User_GetUser]    Script Date: 7/21/2022 6:02:08 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[SP_User_GetUser] 

AS
BEGIN
	
	SET NOCOUNT ON;
select [UserName],[Id] from [User]
   
END
GO
/****** Object:  StoredProcedure [dbo].[SP_User_Insert]    Script Date: 7/21/2022 6:02:08 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[SP_User_Insert] 
	
	@UserName nvarchar(50),
	@Password nvarchar(150)
AS
BEGIN
	
	SET NOCOUNT ON;

Insert into [User](UserName,Password)
values (@UserName,@Password)
END
GO
/****** Object:  StoredProcedure [dbo].[SP_User_Login]    Script Date: 7/21/2022 6:02:08 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[SP_User_Login] 
	@UserName nvarchar(50),
	@Password nvarchar(150)
AS
BEGIN
	
	SET NOCOUNT ON;

select count(1) from [User] where UserName=@UserName and Password=@Password
END
GO
