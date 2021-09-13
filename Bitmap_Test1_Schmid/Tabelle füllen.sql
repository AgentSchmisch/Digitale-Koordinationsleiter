drop table Patientenliste;
drop table Florian_Schmid_25102002;

CREATE TABLE [dbo].[Florian_Schmid_25102002] (
    [Name]                    NvarCHAR(50)           NOT NULL,
    [Behandlungsdatum]        DATE      NULL,
    [Schrittweite] NVARCHAR (50) NULL,
    [Geburtsdatum]            DATE      NULL,
    Behandlungsnummer int,
    PRIMARY KEY CLUSTERED (Behandlungsnummer));

    Insert into Florian_Schmid_25102002 (Name,Behandlungsdatum,Schrittweite,Geburtsdatum,Behandlungsnummer) Values('Florian Schmid','2021.07.21','10','2002.10.25','1');
    Insert into Florian_Schmid_25102002 (Name,Behandlungsdatum,Schrittweite,Geburtsdatum,Behandlungsnummer) Values('Florian Schmid','2021-07-21','10','2002-10-25','2');
    Insert into Florian_Schmid_25102002 (Name,Behandlungsdatum,Schrittweite,Geburtsdatum,Behandlungsnummer) Values('Florian Schmid','2021-07-21','10','2002-10-25','3');

    CREATE TABLE [dbo].[Patientenliste] (
    [Patientennummer]    INT NOT NULL,
    [Vorname]            NVARCHAR (50) NOT NULL,
    [Nachname]          NVARCHAR (50) NOT NULL,
    [Geburtsdatum]    DATE NULL,
    [Adresse]         NVARCHAR (50) NULL,
    [Ort]             NVARCHAR (50) NULL,
    [Postleitzahl]    NCHAR (4)     NULL,
    [Telefonnummer]   NVARCHAR (15) NULL,
    CONSTRAINT [PK_Patientenliste] PRIMARY KEY CLUSTERED ([Patientennummer] ASC)
);

insert into Patientenliste (Name,Geburtsdatum,Adresse,Ort,Postleitzahl,Telefonnummer) values ('Florian Schmid','2002-10-25','Hirsbodenstraße 5','Schrick','2191','06644015337');
insert into Patientenliste (Name,Geburtsdatum,Adresse,Ort,Postleitzahl,Telefonnummer) values ('Hannes Hiller','2002-10-25','Hirsbodenstraße 5','Schrick','2191','06644015337');
