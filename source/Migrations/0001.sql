CREATE TABLE [User] (
	[ID] 				int 				NOT NULL 	IDENTITY(1,1)	PRIMARY KEY 	CLUSTERED,
	[Logon] 			varchar (64) 		NOT NULL,
	[Password] 			varchar (256) 		NOT NULL,
	[Salt] 				varchar (256) 		NOT NULL,
	[PasswordHistory]	varchar (4096)		NULL,
	[ChangePassword]	bit					NOT NULL	DEFAULT (1),
	[Locked]			bit					NOT NULL	DEFAULT (1),
	[JoinedOn]			datetime			NULL,	
	[LeftOn]			datetime			NULL,		
	[SuperUser]			bit					NOT NULL	DEFAULT (0),
	[Accepted]			bit					NOT NULL	DEFAULT (0),
	[Data]				text				NULL,	
	[Preferences]		text				NULL,	
	[IP]				varchar (128)		NULL,
	[Session] 			uniqueidentifier	NOT NULL,

	CONSTRAINT UNIQUE_LOGON UNIQUE NONCLUSTERED (Logon),
) ON [PRIMARY]