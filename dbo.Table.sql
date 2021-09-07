CREATE TABLE [dbo].[ImagesStore] (
	[ImageId] [int] IDENTITY (1, 1) NOT NULL ,
	[OriginalPath] [varchar] (200) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL ,
	[ImageData] [image] NOT NULL 
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO