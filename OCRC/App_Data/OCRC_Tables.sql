USE OCRC;
GO
DROP TABLE [dbo].[User];
DROP TABLE [dbo].[Status];
DROP TABLE [dbo].[Notes];
DROP TABLE [dbo].[Ranking];

USE OCRC;
GO
CREATE TABLE [dbo].[User] (
    [userID]    INT           IDENTITY (1, 1) NOT NULL,
    [fname]    	VARCHAR (50)  NOT NULL,
    [lname]    	VARCHAR (50)  NOT NULL,
    [email]    	VARCHAR (100) NOT NULL UNIQUE,
    [password] 	VARCHAR (100) NOT NULL,
    [accesslvl] INT 		  NOT NULL,
	[teamIdentifier] VARCHAR(100) NULL,
	[schoolIdentifier]	VARCHAR(100) NULL,
    PRIMARY KEY CLUSTERED ([userID] ASC)
);

CREATE TABLE [dbo].[Status] (
    [statusID]			INT      IDENTITY (1, 1) NOT NULL,
    [kidIdentifier]		VARCHAR(100)			 NOT NULL UNIQUE,
    [active]           	VARCHAR(100)			 NOT NULL,
    [activityModified] 	DATETIME  				 NOT NULL,
    PRIMARY KEY CLUSTERED ([statusID] ASC)
);
CREATE TABLE [dbo].[Notes] (
    [notesID]      INT           IDENTITY (1, 1) NOT NULL,
    [dateCreated]  DATETIME      NOT NULL,
    [dateModified] DATETIME      NOT NULL,
    [statusID]     INT           NOT NULL,
	[userID] 	   INT 			 NOT NULL,
    [notes]        VARCHAR(100) NULL,
    PRIMARY KEY CLUSTERED ([notesID] ASC),
    FOREIGN KEY ([statusID]) REFERENCES [dbo].[Status] ([statusID]),
	CONSTRAINT notesSurKey UNIQUE (dateCreated,userID,statusID)
);

CREATE TABLE [dbo].[Ranking] (
    [rankingID]    INT      IDENTITY (1, 1) NOT NULL,
    [statusID]     INT      		 NOT NULL,
	[userID] 	   INT 				 NOT NULL,
    [dateCreated]  DATETIME 		 NOT NULL,
    [rank]         INT      		 NULL,
    [sportType]    VARCHAR(100)      NOT NULL,
    PRIMARY KEY CLUSTERED ([rankingID] ASC),
    FOREIGN KEY ([statusID]) REFERENCES [dbo].[Status] ([statusID]),
	FOREIGN KEY ([userID]) REFERENCES [dbo].[User] ([userID]),
	CONSTRAINT rankSurKey UNIQUE (statusID,userID,dateCreated,sportType)
);

USE OCRC;
GO
INSERT INTO [dbo].[User] VALUES ('Susan','Lowdy','admin@gmail.com','yourstupid',1,null,null);
INSERT INTO [dbo].[User] VALUES ('Bob','Nolls','clerk@yahoo.com','clerk',2,null,null);
INSERT INTO [dbo].[User] VALUES ('Eric','Lubaguske','clerk2@msn.com','clerk',2,null,null);
INSERT INTO [dbo].[User] VALUES ('Kimmy','Schimdt','coach@hotmail.com','coach',3,null,null);
INSERT INTO [dbo].[User] VALUES ('Sam','Starfire','schoolcoach@aol.com','schoolcoach',4,null,null);

INSERT INTO [dbo].[Status] VALUES ('1','active','08-12-2017 12:45');
INSERT INTO [dbo].[Status] VALUES ('4','active','10-10-2017 15:34');
INSERT INTO [dbo].[Status] VALUES ('10','inactive','11-05-2017 14:56');

INSERT INTO [dbo].[Notes] VALUES ('11-17-2017 07:00','11-18-2017 16:00',1,1,'Stuff');
INSERT INTO [dbo].[Notes] VALUES ('12-18-2014 10:40','1-20-2017 11:00',2,2,'Stuffin');
INSERT INTO [dbo].[Notes] VALUES ('10-19-2017 12:15','11-17-2017 14:00',2,3,'Stuffin Stuff');
INSERT INTO [dbo].[Notes] VALUES ('09-20-2017 15:30','12-05-2017 12:00',1,1,'Stuff in the Stuff');
INSERT INTO [dbo].[Notes] VALUES ('08-21-2017 13:55','10-15-2017 13:00',1,2,'See Saw Stuff');
INSERT INTO [dbo].[Notes] VALUES ('07-22-2017 07:00','09-05-2017 16:00',1,1,'Be Saw Stuff');

INSERT INTO [dbo].[Ranking] VALUES (1,1,'11-17-2017 12:00',1,'Baseball');
INSERT INTO [dbo].[Ranking] VALUES (2,2,'10-12-2017 12:35',2,'Soccer');
INSERT INTO [dbo].[Ranking] VALUES (2,3,'09-20-2017 23:59',3,'Basketball');
INSERT INTO [dbo].[Ranking] VALUES (2,4,'08-17-2017 16:00',4,'Boxing');
INSERT INTO [dbo].[Ranking] VALUES (2,4,'07-18-2017 14:00',5,'Fishing');
INSERT INTO [dbo].[Ranking] VALUES (2,4,'06-05-2017 23:59',3,'Swimming');
INSERT INTO [dbo].[Ranking] VALUES (2,4,'05-02-2017 15:00',4,'Wrestling');