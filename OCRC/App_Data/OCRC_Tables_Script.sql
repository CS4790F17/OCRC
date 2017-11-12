CREATE TABLE [dbo].[Kid] (
    [kidID]    INT          IDENTITY (1, 1) NOT NULL,
    [fname]    VARCHAR (50) NOT NULL,
    [lname]    VARCHAR (50) NOT NULL,
    [schoolID] INT          NOT NULL,
    [grade]    VARCHAR (5)  NOT NULL,
    [age]      INT          NOT NULL,
    PRIMARY KEY CLUSTERED ([kidID] ASC),
    FOREIGN KEY ([schoolID]) REFERENCES [dbo].[School] ([schoolID])
);

CREATE TABLE [dbo].[Notes] (
    [notesID]      INT           IDENTITY (1, 1) NOT NULL,
    [dateCreated]  DATETIME      NOT NULL,
    [dateModified] DATETIME      NOT NULL,
    [statusID]     INT           NOT NULL,
    [notes]        VARCHAR (100) NULL,
    PRIMARY KEY CLUSTERED ([notesID] ASC),
    FOREIGN KEY ([statusID]) REFERENCES [dbo].[Status] ([statusID])
);

CREATE TABLE [dbo].[Ranking] (
    [rankingID]    INT      IDENTITY (1, 1) NOT NULL,
    [statusID]     INT      NOT NULL,
    [dateCreated]  DATETIME NOT NULL,
    [dateModified] DATETIME NOT NULL,
    [rank]         INT      NOT NULL,
    [teamID]       INT      NOT NULL,
    PRIMARY KEY CLUSTERED ([rankingID] ASC),
    FOREIGN KEY ([statusID]) REFERENCES [dbo].[Status] ([statusID]),
    FOREIGN KEY ([teamID]) REFERENCES [dbo].[Team] ([teamID])
);

CREATE TABLE [dbo].[Registration] (
    [registerID]       INT      NOT NULL,
    [registrationYear] INT      NOT NULL,
    [kidID]            INT      NOT NULL,
    [dateRegistered]   DATETIME NOT NULL,
    [teamID]           INT      NOT NULL,
    PRIMARY KEY CLUSTERED ([registerID] ASC),
    FOREIGN KEY ([kidID]) REFERENCES [dbo].[Kid] ([kidID]),
    FOREIGN KEY ([teamID]) REFERENCES [dbo].[Team] ([teamID])
);

CREATE TABLE [dbo].[Role] (
    [roleID]    INT          IDENTITY (1, 1) NOT NULL,
    [role]      VARCHAR (50) NOT NULL,
    [accesslvl] VARCHAR (50) NOT NULL,
    PRIMARY KEY CLUSTERED ([roleID] ASC)
);

CREATE TABLE [dbo].[School] (
    [schoolID]    INT           IDENTITY (1, 1) NOT NULL,
    [schoolName]  VARCHAR (100) NULL,
    [schoolCoach] VARCHAR (100) NULL,
    PRIMARY KEY CLUSTERED ([schoolID] ASC)
);

CREATE TABLE [dbo].[Sport] (
    [sportID]   INT          NOT NULL,
    [sportName] VARCHAR (50) NOT NULL,
    PRIMARY KEY CLUSTERED ([sportID] ASC)
);

CREATE TABLE [dbo].[Status] (
    [statusID]         INT      IDENTITY (1, 1) NOT NULL,
    [kidID]            INT      NOT NULL,
    [sportID]          INT      NOT NULL,
    [active]           BIT      NOT NULL,
    [activityModified] DATETIME NOT NULL,
    PRIMARY KEY CLUSTERED ([statusID] ASC),
    FOREIGN KEY ([kidID]) REFERENCES [dbo].[Kid] ([kidID]),
    FOREIGN KEY ([sportID]) REFERENCES [dbo].[Sport] ([sportID])
);

CREATE TABLE [dbo].[Team] (
    [teamID]   INT          IDENTITY (1, 1) NOT NULL,
    [userID]   INT          NOT NULL,
    [teamName] VARCHAR (50) NOT NULL,
    [sportID]  INT          NOT NULL,
    PRIMARY KEY CLUSTERED ([teamID] ASC),
    FOREIGN KEY ([userID]) REFERENCES [dbo].[User] ([userID]),
    FOREIGN KEY ([sportID]) REFERENCES [dbo].[Sport] ([sportID])
);

CREATE TABLE [dbo].[User] (
    [userID]   INT           IDENTITY (1, 1) NOT NULL,
    [fname]    VARCHAR (50)  NOT NULL,
    [lname]    VARCHAR (50)  NOT NULL,
    [email]    VARCHAR (100) NOT NULL,
    [password] VARCHAR (100) NOT NULL,
    [roleID]   INT           NOT NULL,
    PRIMARY KEY CLUSTERED ([userID] ASC),
    FOREIGN KEY ([roleID]) REFERENCES [dbo].[Role] ([roleID])
);