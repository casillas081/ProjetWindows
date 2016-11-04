-- *********************************************
-- * Standard SQL generation                   
-- *--------------------------------------------
-- * DB-MAIN version: 9.3.0              
-- * Generator date: Feb 16 2016              
-- * Generation date: Thu Nov 03 11:11:21 2016 
-- * LUN file: C:\Users\Christophe\Desktop\Documents\Cours_2016-2017\Env_dev_logiciels\Labo\ProjetWindows\Project-SmartCityRelatonal.lun 
-- * Schema: SCHEMA-GuideMe/SQL 
-- ********************************************* 


-- Database Section
-- ________________ 

create database SCHEMA-GuideMe;


-- DBSpace Section
-- _______________


-- Tables Section
-- _____________ 

create table Avatar (
     IdPicture varchar(6) not null,
     Name varchar(30) not null,
     UrlPicture varchar(200) not null,
     constraint ID_Avatar_ID primary key (IdPicture));

create table Language (
     CodeLanguage varchar(6) not null,
     Name char(1) not null,
     constraint ID_Language_ID primary key (CodeLanguage));

create table Match (
     Gui_Pseudo varchar(20) not null,
     Pseudo varchar(20) not null,
     Date date not null,
     NamePlace varchar(30) not null,
     constraint ID_Match_ID primary key (Gui_Pseudo, Pseudo));

create table Person (
     Pseudo varchar(20) not null,
     FirstName varchar(30) not null,
     LastName varchar(30) not null,
     Sex char(1) not null,
     Password varchar(128) not null,
     Nationality varchar(10) not null,
     TypeRole char not null,
     Rank numeric(3,1) not null,
     IdPicture varchar(6) not null,
     constraint ID_Person_ID primary key (Pseudo));

create table Place (
     IdPlace varchar(10) not null,
     NamePlace varchar(30) not null,
     Adr_Street varchar(30) not null,
     Adr_Number varchar(4) not null,
     Adr_City varchar(30) not null,
     Adr_ZipCode numeric(4) not null,
     CoordLat numeric(6,3) not null,
     CoordLong numeric(6,3) not null,
     constraint ID_Place_ID primary key (IdPlace));

create table Speak (
     CodeLanguage varchar(6) not null,
     Pseudo varchar(20) not null,
     constraint ID_Speak_ID primary key (CodeLanguage, Pseudo));

create table Translation (
     CodeLanguage varchar(6) not null,
     IdPlace varchar(10) not null,
     TranslationNamePlace varchar(30) not null,
     constraint ID_Translation_ID primary key (IdPlace, CodeLanguage));

create table Translation_1 (
     CodeLanguage varchar(6) not null,
     Pseudo varchar(20) not null,
     TranslationNationatity char(1) not null,
     constraint ID_Translation_1_ID primary key (CodeLanguage, Pseudo));

create table Want_To_Guid (
     Pseudo varchar(20) not null,
     IdPlace varchar(10) not null,
     constraint ID_Want_To_Guid_ID primary key (Pseudo, IdPlace));

create table Want_To_Visit (
     Pseudo varchar(20) not null,
     IdPlace varchar(10) not null,
     constraint ID_Want_To_Visit_ID primary key (IdPlace, Pseudo));


-- Constraints Section
-- ___________________ 

alter table Match add constraint REF_Match_Perso_1_FK
     foreign key (Pseudo)
     references Person;

alter table Match add constraint REF_Match_Perso
     foreign key (Gui_Pseudo)
     references Person;

alter table Person add constraint ID_Person_CHK
     check(exists(select * from Speak
                  where Speak.Pseudo = Pseudo)); 

alter table Person add constraint ID_Person_CHK
     check(exists(select * from Translation_1
                  where Translation_1.Pseudo = Pseudo)); 

alter table Person add constraint REF_Perso_Avata_FK
     foreign key (IdPicture)
     references Avatar;

alter table Place add constraint ID_Place_CHK
     check(exists(select * from Translation
                  where Translation.IdPlace = IdPlace)); 

alter table Speak add constraint EQU_Speak_Perso_FK
     foreign key (Pseudo)
     references Person;

alter table Speak add constraint REF_Speak_Langu
     foreign key (CodeLanguage)
     references Language;

alter table Translation add constraint EQU_Trans_Place
     foreign key (IdPlace)
     references Place;

alter table Translation add constraint REF_Trans_Langu_1_FK
     foreign key (CodeLanguage)
     references Language;

alter table Translation_1 add constraint EQU_Trans_Perso_FK
     foreign key (Pseudo)
     references Person;

alter table Translation_1 add constraint REF_Trans_Langu
     foreign key (CodeLanguage)
     references Language;

alter table Want_To_Guid add constraint REF_Want__Place_1_FK
     foreign key (IdPlace)
     references Place;

alter table Want_To_Guid add constraint REF_Want__Perso_1
     foreign key (Pseudo)
     references Person;

alter table Want_To_Visit add constraint REF_Want__Place
     foreign key (IdPlace)
     references Place;

alter table Want_To_Visit add constraint REF_Want__Perso_FK
     foreign key (Pseudo)
     references Person;


-- Index Section
-- _____________ 

create unique index ID_Avatar_IND
     on Avatar (IdPicture);

create unique index ID_Language_IND
     on Language (CodeLanguage);

create unique index ID_Match_IND
     on Match (Gui_Pseudo, Pseudo);

create index REF_Match_Perso_1_IND
     on Match (Pseudo);

create unique index ID_Person_IND
     on Person (Pseudo);

create index REF_Perso_Avata_IND
     on Person (IdPicture);

create unique index ID_Place_IND
     on Place (IdPlace);

create unique index ID_Speak_IND
     on Speak (CodeLanguage, Pseudo);

create index EQU_Speak_Perso_IND
     on Speak (Pseudo);

create unique index ID_Translation_IND
     on Translation (IdPlace, CodeLanguage);

create index REF_Trans_Langu_1_IND
     on Translation (CodeLanguage);

create unique index ID_Translation_1_IND
     on Translation_1 (CodeLanguage, Pseudo);

create index EQU_Trans_Perso_IND
     on Translation_1 (Pseudo);

create unique index ID_Want_To_Guid_IND
     on Want_To_Guid (Pseudo, IdPlace);

create index REF_Want__Place_1_IND
     on Want_To_Guid (IdPlace);

create unique index ID_Want_To_Visit_IND
     on Want_To_Visit (IdPlace, Pseudo);

create index REF_Want__Perso_IND
     on Want_To_Visit (Pseudo);

