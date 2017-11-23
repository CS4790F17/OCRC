(userID,fname,lname,email,password,accesslvl,teamIdentifier)
INSERT INTO User VALUES (1,"Susan","Lowdy","admin@gmail.com","yourstupid",1,null);
INSERT INTO User VALUES (2,"Bob","Nolls","clerk@yahoo.com","clerk",2,null);
INSERT INTO User VALUES (3,"Eric","Lubaguske","clerk2@msn.com","clerk",2,null);
INSERT INTO User VALUES (4,"Kimmy","Schimdt","coach@hotmail.com","coach",3,null);
INSERT INTO User VALUES (5,"Sam","Starfire","schoolcoach@aol.com","schoolcoach",4,null);

(statusID,kidIdentifier,active,activityModified)
INSERT INTO Status VALUES (1,"1","active",08-12-2017 12:45);
INSERT INTO Status VALUES (2,"4","active",10-10-2017 15:34);
INSERT INTO Status VALUES (3,"10","inactive",11-05-2017 14:56);

(notesID,dateCreated,dateModified,statusID,userID,notes)
INSERT INTO Notes VALUES (1,11-17-2017 07:00,11-18-2017 16:00,1,1,"Stuff");
INSERT INTO Notes VALUES (2,12-18-2014 10:40,1-20-2017 11:00,2,2,"Stuffin");
INSERT INTO Notes VALUES (3,10-19-2017 12:15,11-17-2017 14:00,2,3,"Stuffin Stuff");
INSERT INTO Notes VALUES (4,09-20-2017 15:30,12-05-2017 12:00,1,1,"Stuff in the Stuff");
INSERT INTO Notes VALUES (5,08-21-2017 13:55,10-15-2017 13:00,1,2,"See Saw Stuff");
INSERT INTO Notes VALUES (6,07-22-2017 07:00,09-05-2017 16:00,1,1,"Be Saw Stuff");

(rankingID,statusID,userID,dateCreated,rank,sportType)
INSERT INTO Ranking VALUES (1,1,1,11-17-2017 12:00,1,"Baseball");
INSERT INTO Ranking VALUES (2,2,2,10-12-2017 12:35,2,"Soccer");
INSERT INTO Ranking VALUES (3,2,3,09-20-2017 23:59,3,"Basketball");
INSERT INTO Ranking VALUES (4,2,4,08-17-2017 16:00,4,"Boxing");
INSERT INTO Ranking VALUES (5,2,4,07-18-2017 14:00,5,"Fishing");
INSERT INTO Ranking VALUES (6,2,4,06-05-2017 23:59,3,"Swimming");
INSERT INTO Ranking VALUES (7,2,4,05-02-2017 15:00,4,"Wrestling");