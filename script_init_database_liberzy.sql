USE [Xbrain]
GO
/****** Object:  Table [dbo].[DailyActivity]    Script Date: 10/16/2019 4:40:13 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DailyActivity](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[UserId] [int] NOT NULL,
	[ActivityTitle] [nvarchar](100) NOT NULL,
	[ActivityContent] [nvarchar](250) NULL,
	[DateAchieve] [date] NOT NULL,
	[NumberOfHour] [float] NOT NULL,
	[TargetHour] [float] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[DailyRoutine]    Script Date: 10/16/2019 4:40:13 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DailyRoutine](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[UserId] [int] NOT NULL,
	[RoutineTitle] [nvarchar](100) NOT NULL,
	[RoutineContent] [nvarchar](max) NULL,
	[DayOperation] [nvarchar](100) NULL,
	[DateAchieve] [date] NOT NULL,
	[PlanStartTime] [time](7) NOT NULL,
	[PlanEndTime] [time](7) NOT NULL,
	[ActualStartTime] [time](7) NULL,
	[ActualEndTime] [time](7) NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[SleepingTime]    Script Date: 10/16/2019 4:40:13 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SleepingTime](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[UserId] [int] NOT NULL,
	[DateAchieve] [date] NULL,
	[SleepTime] [time](7) NULL,
	[WakingupTime] [time](7) NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[XBrainUser]    Script Date: 10/16/2019 4:40:13 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[XBrainUser](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[FirstName] [nvarchar](100) NULL,
	[LastName] [nvarchar](100) NULL,
	[UserName] [nvarchar](100) NULL,
	[Email] [nvarchar](100) NULL,
	[HashPassword] [nvarchar](250) NULL,
	[DeviceId] [nvarchar](250) NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[DailyActivity] ADD  DEFAULT ((0)) FOR [NumberOfHour]
GO
ALTER TABLE [dbo].[DailyActivity] ADD  DEFAULT ((0)) FOR [TargetHour]
GO
ALTER TABLE [dbo].[DailyActivity]  WITH CHECK ADD FOREIGN KEY([UserId])
REFERENCES [dbo].[XBrainUser] ([Id])
GO
ALTER TABLE [dbo].[DailyRoutine]  WITH CHECK ADD FOREIGN KEY([UserId])
REFERENCES [dbo].[XBrainUser] ([Id])
GO
ALTER TABLE [dbo].[SleepingTime]  WITH CHECK ADD FOREIGN KEY([UserId])
REFERENCES [dbo].[XBrainUser] ([Id])
GO
