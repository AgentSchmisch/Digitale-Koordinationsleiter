drop Table Florian_Schmid_25102002;
drop table Patientenliste;

CREATE TABLE Patientenliste(
Patientennummer int identity(1,1) Primary Key,
Vorname		nvarchar(50) not null,
Nachname	nvarchar(50) not null,
Geburtsdatum date null,
Adresse		nvarchar(50) null,
PLZ			nchar(4) null,
Ort			nvarchar(50),
Telefonnummer nvarchar(14)
);

INSERT INTO Patientenliste(Vorname,Nachname,Geburtsdatum,Adresse,PLZ,Ort,Telefonnummer)
values('Florian','Schmid','2002-10-25','Hirsbodenstraße 5','2191','Schrick','06644015337');
INSERT INTO Patientenliste(Vorname,Nachname,Geburtsdatum,Adresse,PLZ,Ort,Telefonnummer)
values('Hannes','Hiller','2002-10-25','Hirsbodenstraße 5','2191','Schrick','06644015337');
INSERT INTO Patientenliste(Vorname,Nachname,Geburtsdatum,Adresse,PLZ,Ort,Telefonnummer)
values('Christoph','Polke','2002-10-25','Hirsbodenstraße 5','2191','Schrick','06644015337');


Create Table Florian_Schmid_25102002(
FK_Patientennummer int  not NULL,
Behandlungsnummer int Identity(1,1) PRIMARY KEY,
Vorname			nvarchar(50) not null,
Nachname		nvarchar(50) not null,
Schrittweite	int null,
Behandlungsdatum date null, 
CONSTRAINT [FK_Florian_Schmid_25102002] FOREIGN KEY ([FK_Patientennummer]) REFERENCES [dbo].[Patientenliste]([Patientennummer]),
);

insert into Florian_Schmid_25102002(Vorname,Nachname,Schrittweite,Behandlungsdatum)
values('Florian','Schmid','10','2021-09-11');
insert into Florian_Schmid_25102002(Vorname,Nachname,Schrittweite,Behandlungsdatum)
values('Florian','Schmid','10','2021-09-11');
insert into Florian_Schmid_25102002(Vorname,Nachname,Schrittweite,Behandlungsdatum)
values('Florian','Schmid','10','2021-09-11');


