USE [LogoDb]
GO
/****** Object:  Table [dbo].[Companies]    Script Date: 28.03.2022 02:10:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Companies](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Companies] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Users]    Script Date: 28.03.2022 02:10:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Users](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[LastName] [nvarchar](50) NOT NULL,
	[Mail] [nvarchar](100) NOT NULL,
	[Password] [nvarchar](50) NOT NULL,
	[CompanyId] [int] NOT NULL,
 CONSTRAINT [PK_Users] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Users]  WITH CHECK ADD  CONSTRAINT [FK_Users_Companies] FOREIGN KEY([CompanyId])
REFERENCES [dbo].[Companies] ([Id])
GO
ALTER TABLE [dbo].[Users] CHECK CONSTRAINT [FK_Users_Companies]
GO



SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


/****** Company Add Procedure******/
CREATE PROCEDURE [dbo].[AddCompany]

@companyName nvarchar(50)

AS
BEGIN 
	INSERT INTO dbo.Companies
	(Name)
	VALUES
	(@companyName)
END
GO
 

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


/****** Company Add User******/
CREATE PROCEDURE [dbo].[AddUser]
@userName nvarchar(50),
@userLastName nvarchar(50),
@userMail nvarchar(100),
@userPassword nvarchar(50),
@userCompanyId int
	AS
		BEGIN 
			INSERT INTO dbo.Users
			(Name,
			LastName,
			Mail,
			Password,
			CompanyId)
			VALUES
			(
			@userName,  
			@userLastName,
			@userMail, 
			@userPassword,
			@userCompanyId  
			)
		END
GO



/****** Company Add Procedure Using Example ******/
EXEC AddCompany
@companyName='Logo'

EXEC AddCompany
@companyName='Patika'


/****** User Add Procedure Using Example ******/
EXEC AddUser
	@userName='Mert',
	@userLastName='Yýlmaz',
	@userMail='mert@logo.com',
	@userPassword='logo123',
	@userCompanyId=1


EXEC AddUser
	@userName='Derya',
	@userLastName='Sönmez',
	@userMail='derya@patika.com',
	@userPassword='patika123',
	@userCompanyId=2


/****** Check Tables ******/

SELECT * FROM Users
SELECT * FROM Companies