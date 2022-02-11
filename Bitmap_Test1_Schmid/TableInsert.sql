DROP TABLE Florian_Schmid_1;
CREATE TABLE Patientenliste(Patientennummer int NOT NULL Identity(1,1),
							Vorname nvarchar(50) NOT NULL,
							Nachname nvarchar(50) NOT NULL,
							Geburtsdatum nvarchar(10) NULL,
							Adresse varchar(50) NULL,
							PLZ varchar(4) NULL,
							Ort nvarchar(50) NULL,
							Telefonnummer nvarchar(14) NULL,
							Primary Key (Patientennummer) 
							);
CREATE TABLE Florian_Schmid_1(Behandlungsnummer int NOT NULL Identity(1,1),
							Vorname nvarchar(50) NOT NULL,
							Nachname nvarchar(50) NOT NULL,
							Schrittweite int NOT NULL,
							Behandlungsdatum varchar(10) NOT NULL,
							Primary Key (Behandlungsnummer) 
							);
CREATE TABLE Hannes_Hiller_2(Behandlungsnummer int NOT NULL Identity(1,1),
							Vorname nvarchar(50) NOT NULL,
							Nachname nvarchar(50) NOT NULL,
							Schrittweite int NOT NULL,
							Behandlungsdatum varchar(10) NOT NULL,
							Primary Key (Behandlungsnummer) 
							);
CREATE TABLE Sebastian_Rabl_3(Behandlungsnummer int NOT NULL Identity(1,1),
							Vorname nvarchar(50) NOT NULL,
							Nachname nvarchar(50) NOT NULL,
							Schrittweite int NOT NULL,
							Behandlungsdatum varchar(10) NOT NULL,
							Primary Key (Behandlungsnummer) 
							);
CREATE TABLE Christoph_Polke_4(Behandlungsnummer int NOT NULL Identity(1,1),
							Vorname nvarchar(50) NOT NULL,
							Nachname nvarchar(50) NOT NULL,
							Schrittweite int NOT NULL,
							Behandlungsdatum varchar(10) NOT NULL,
							Primary Key (Behandlungsnummer) 
							);
CREATE TABLE Max_Pemsel_5(Behandlungsnummer int NOT NULL Identity(1,1),
							Vorname nvarchar(50) NOT NULL,
							Nachname nvarchar(50) NOT NULL,
							Schrittweite int NOT NULL,
							Behandlungsdatum varchar(10) NOT NULL,
							Primary Key (Behandlungsnummer) 
							);
INSERT INTO Florian_Schmid_1 (Vorname,Nachname,Schrittweite,Behandlungsdatum) VALUES
	 ('Florian','Schmid',10,'11.09.2021'),
	 ('Florian','Schmid',10,'11.09.2021'),
	 ('Florian','Schmid',10,'11.09.2021'),
	 ('Florian','Schmid',10,'2021-11-11'),
	 ('Florian','Schmid',10,'15.01.2022');
INSERT INTO Hannes_Hiller_2 (Vorname,Nachname,Schrittweite,Behandlungsdatum) VALUES
	 ('Hannes','Hiller',10,'14.9.2021'),
	 ('Hannes','Hiller',10,'14.9.2021'),
	 ('Hannes','Hiller',10,'14.9.2021'),
	 ('Hannes','Hiller',8,'29.11.2021');
INSERT INTO Sebastian_Rabl_3 (Vorname,Nachname,Schrittweite,Behandlungsdatum) VALUES
	 ('Sebastian','Rabl',10,'14.9.2021'),
	 ('Sebastian','Rabl',10,'14.9.2021'),
	 ('Sebastian','Rabl',10,'14.9.2021'),
	 ('Sebastian','Rabl',10,'23.11.2021'),
	 ('Sebastian','Rabl',10,'23.11.2021'),
	 ('Sebastian','Rabl',10,'23.11.2021'),
	 ('Sebastian','Rabl',10,'23.11.2021');
INSERT INTO Christoph_Polke_4 (Vorname,Nachname,Schrittweite,Behandlungsdatum) VALUES
	 ('Christoph','Polke',10,'14.9.2021'),
	 ('Christoph','Polke',10,'14.9.2021'),
	 ('Christoph','Polke',10,'14.9.2021'),
	 ('Christoph','Polke',9,'2021-11-12'),
	 ('Christoph','Polke',10,'12.11.2021'),
	 ('Christoph','Polke',5,'19.11.2021'),
	 ('Christoph','Polke',5,'19.11.2021'),
	 ('Christoph','Polke',5,'19.11.2021'),
	 ('Christoph','Polke',7,'19.11.2021'),
	 ('Christoph','Polke',7,'19.11.2021');
INSERT INTO Christoph_Polke_4 (Vorname,Nachname,Schrittweite,Behandlungsdatum) VALUES
	 ('Christoph','Polke',7,'19.11.2021'),
	 ('Christoph','Polke',7,'19.11.2021'),
	 ('Christoph','Polke',7,'22.11.2021'),
	 ('Christoph','Polke',7,'23.11.2021'),
	 ('Christoph','Polke',7,'23.11.2021'),
	 ('Christoph','Polke',4,'28.11.2021'),
	 ('Christoph','Polke',8,'29.11.2021'),
	 ('Christoph','Polke',8,'06.12.2021'),
	 ('Christoph','Polke',8,'06.12.2021'),
	 ('Christoph','Polke',8,'06.12.2021');
INSERT INTO Christoph_Polke_4 (Vorname,Nachname,Schrittweite,Behandlungsdatum) VALUES
	 ('Christoph','Polke',8,'06.12.2021'),
	 ('Christoph','Polke',8,'06.12.2021'),
	 ('Christoph','Polke',8,'06.12.2021'),
	 ('Christoph','Polke',8,'06.12.2021'),
	 ('Christoph','Polke',6,'07.12.2021'),
	 ('Christoph','Polke',6,'03.01.2022'),
	 ('Christoph','Polke',6,'21.01.2022');
INSERT INTO Max_Pemsel_5 (Vorname,Nachname,Schrittweite,Behandlungsdatum) VALUES
	 ('Max','Pemsel',7,'19.11.2021');
INSERT INTO Patientenliste (Vorname,Nachname,Geburtsdatum,Adresse,PLZ,Ort,Telefonnummer) VALUES
	 ('Florian','Schmid','2002-10-25','Hirsbodenstrasse 5','2191','Schrick','06644015337'),
	 ('Hannes','Hiller','2002-10-04','Unterstinkenbrunn 16','2154','Unterstinkenbrunn','068018768420'),
	 ('Sebastian','Rabl','2002-12-28','Bachgasse 4','2171','Herrnbaumgarten','06504106551'),
	 ('Christoph','Polke','2002-12-02','Steinhübelgasse 8','2130','Mistelbach','06644350534'),
	 ('Max','Pemsel','07.04.2003','Adresse','Ort','Miba','06644015337');
