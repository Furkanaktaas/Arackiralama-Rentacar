CREATE DATABASE arac_kiralama
GO
USE arac_kiralama
CREATE TABLE tblArac
(
arac_no INT IDENTITY(1,1) NOT NULL PRIMARY KEY,
marka VARCHAR(15) NOT NULL
	CONSTRAINT ck_marka
		CHECK(len(marka)>=3),
model VARCHAR(15) NOT NULL
	CONSTRAINT ck_model
		CHECK(len(model)>=2),
plaka VARCHAR(9) NOT NULL
	CONSTRAINT ck_plaka
		CHECK(
		plaka like '0[1-9][A-Z][0-9][0-9][0-9][0-9]'
		OR plaka like '[1-7][0-9][A-Z][0-9][0-9][0-9][0-9]' 
		OR plaka like '8[0-1][A-Z][0-9][0-9][0-9][0-9]'
		OR plaka like '0[1-9][A-Z][A-Z][0-9][0-9][0-9]'
		OR plaka like '[1-7][0-9][A-Z][A-Z][0-9][0-9][0-9]'
		OR plaka like '8[0-1][A-Z][A-Z][0-9][0-9][0-9]'
		OR plaka like '0[1-9][A-Z][A-Z][A-Z][0-9][0-9]'
		OR plaka like '[1-7][0-9][A-Z][A-Z][A-Z][0-9][0-9]'
		OR plaka like '8[0-1][A-Z][A-Z][A-Z][0-9][0-9]'
		OR plaka like '34[A-Z][A-Z][A-Z][0-9][0-9][0-9]'
		OR plaka like '34[A-Z][A-Z][A-Z][0-9][0-9]'
		OR plaka like '34[A-Z][A-Z][0-9][0-9][0-9][0-9]'
		OR plaka like '34[A-Z][A-Z][0-9][0-9][0-9]'
		OR plaka like '34[A-Z][0-9][0-9][0-9][0-9]'
		),
yakit_turu VARCHAR(6) NOT NULL
	CONSTRAINT ck_yakit_turu
		CHECK(yakit_turu in('BENZIN','LPG','MAZOT')),
motor_gucu INT, 
tork INT,
motor_hacmi SMALLINT NOT NULL
	CONSTRAINT ck_motor_hacmi
		CHECK(motor_hacmi>=1000 AND motor_hacmi<=5000),
renk VARCHAR(20),
vites VARCHAR(8) NOT NULL
	CONSTRAINT ck_vites
		CHECK(vites in('OTOMATIK','MANUEL')),
klima BIT 
	CONSTRAINT ck_klima
		CHECK(klima in(0,1))
	CONSTRAINT df_klima
		DEFAULT 0,
ruhsat_no INT NOT NULL UNIQUE,
sigorta BIT NOT NULL
	CONSTRAINT ck_sigorta
		CHECK(sigorta in(0,1)),
muayne_bit_tar DATE NOT NULL
	CONSTRAINT ck_muayne_bit_tar
		CHECK(muayne_bit_tar>getdate()),
ucret MONEY,
kiraDurumu BIT
	CONSTRAINT ck_kiraDurumu
		CHECK(kiraDurumu in(0,1))
	CONSTRAINT df_kiraDurumu
		DEFAULT 0
)
CREATE TABLE tblCalisan
(
calisan_no INT IDENTITY(1,1) NOT NULL PRIMARY KEY,
tc BIGINT NOT NULL 
	CONSTRAINT ck_tc
		CHECK(len(tc)=11),
isim VARCHAR(20)
	CONSTRAINT ck_isim
		CHECK(len(isim)>=3),
soyisim VARCHAR(20)
	CONSTRAINT ck_soyisim
		CHECK(len(soyisim)>=2),
adres TEXT,
tel BIGINT NOT NULL
	CONSTRAINT ck_tel
		CHECK(len(tel)=10),
email VARCHAR(50)
	CONSTRAINT ck_email
		CHECK(email like '[A-Z]%@%.%' AND email NOT LIKE '% %')
)
CREATE TABLE tblKullanici
(
calisan_no INT
	CONSTRAINT fk_calisan UNIQUE
		FOREIGN KEY(calisan_no) REFERENCES tblCalisan(calisan_no),
kullaniciadi VARCHAR(20) NOT NULL PRIMARY KEY
	CONSTRAINT ck_kullaniciadi
		CHECK(LEN(kullaniciadi)>=8 and kullaniciadi like '%[A-Z]%[0-9]%'),
sifre VARCHAR(20) NOT NULL
	CONSTRAINT ck_sifre
		CHECK(LEN(sifre)>=8 and sifre like '%[A-Z]%[0-9]%'),
yetki VARCHAR(7)
	CONSTRAINT ck_yetki
		CHECK(yetki in('ADMIN','OKUYUCU','YAZICI'))
)
CREATE TABLE tblMusteri
(
mus_no INT IDENTITY(1,1) PRIMARY KEY,
ad VARCHAR(20)
	CONSTRAINT ck_ad
		CHECK(len(ad)>=3),
soyad VARCHAR(20)
	CONSTRAINT ck_soyad
		CHECK(len(soyad)>=2),
mus_tc BIGINT NOT NULL 
	CONSTRAINT ck_mus_tc
		CHECK(len(mus_tc)=11),
adres TEXT,
mus_tel BIGINT NOT NULL
	CONSTRAINT ck_mus_tel
		CHECK(len(mus_tel)=10),
mus_email VARCHAR(50)
	CONSTRAINT ck_mus_email
		CHECK(mus_email like '[A-Z]%@%.%' AND mus_email NOT LIKE '% %'),
cinsiyet VARCHAR(1) NOT NULL
	CONSTRAINT ck_cinsiyet
		CHECK(cinsiyet in('E','K')),
dogumtar DATE NOT NULL
	CONSTRAINT ck_dogumtar
		CHECK(DATEDIFF(year,dogumtar,getdate())>=18),
dogumyer VARCHAR(14) 
)
CREATE TABLE tblEhliyet
(
mus_id INT NOT NULL UNIQUE
	CONSTRAINT fk_mus_id
		FOREIGN KEY(mus_id) REFERENCES tblMusteri(mus_no),
ehliyet_no VARCHAR(11) NOT NULL PRIMARY KEY
	CONSTRAINT ck_ehliyet_no
		CHECK(len(ehliyet_no)=4),
ehliyet_sinif varchar(2),
kan_grubu varchar(2)
	CONSTRAINT ck_kan_grubu
		CHECK(kan_grubu in('A+','A-','B+','B-','AB+','AB-','0+','0-')),
ilk_alim_tar DATE NOT NULL
	CONSTRAINT ck_ilk_alim_tar
		CHECK(DATEDIFF(year,ilk_alim_tar,getdate())>=1),
bitis_tar DATE NOT NULL
	CONSTRAINT ck_bitis_tar
		CHECK(bitis_tar > getdate())
)
CREATE TABLE tblMakbuz
(
makbuz_no INT IDENTITY(1,1) PRIMARY KEY,
gecikme INT,
urcet MONEY,
teslim_tar DATE
)
CREATE TABLE tblHasar
(
hasar_no INT IDENTITY(1,1) PRIMARY KEY,
durumu BIT DEFAULT 0,
Maliyet MONEY DEFAULT 0
)
CREATE TABLE tblArac_Kiralama
(
kira_no INT IDENTITY(1,1) NOT NULL PRIMARY KEY,
m_no INT NOT NULL
	CONSTRAINT fk_m_no
		FOREIGN KEY(m_no) REFERENCES tblMusteri(mus_no),
a_no INT NOT NULL
	CONSTRAINT fk_a_no
		FOREIGN KEY(a_no) REFERENCES tblArac(arac_no),
c_no INT NOT NULL
	CONSTRAINT fk_c_no
		FOREIGN KEY(c_no) REFERENCES tblCalisan(calisan_no),
mak_no INT
	CONSTRAINT fk_mak_no
		FOREIGN KEY(mak_no) REFERENCES tblMakbuz(makbuz_no),
h_no INT 
	CONSTRAINT fk_h_no
		FOREIGN KEY(h_no) REFERENCES tblHasar(hasar_no),
bas_tar DATE,
bit_tar DATE
)
CREATE TABLE tblSilinenKiralanmis
(
sil_no INT NOT NULL,
sil_m_no INT NOT NULL
	CONSTRAINT fk_sil_m_no
		FOREIGN KEY(sil_m_no) REFERENCES tblMusteri(mus_no),
sil_a_no INT NOT NULL
	CONSTRAINT fk_sil_a_no
		FOREIGN KEY(sil_a_no) REFERENCES tblArac(arac_no),
sil_c_no INT NOT NULL
	CONSTRAINT fk_sil_c_no
		FOREIGN KEY(sil_c_no) REFERENCES tblCalisan(calisan_no),
sil_mak_no INT NOT NULL
	CONSTRAINT fk_sil_mak_no
		FOREIGN KEY(sil_mak_no) REFERENCES tblMakbuz(makbuz_no),
sil_h_no INT NOT NULL 
	CONSTRAINT fk_sil_h_no
		FOREIGN KEY(sil_h_no) REFERENCES tblHasar(hasar_no),
sil_bas_tar DATE,
sil_bit_tar DATE
)
GO
CREATE TRIGGER silinenlerTablosunaGonderme
ON tblArac_Kiralama
AFTER DELETE
AS
BEGIN
DECLARE @Sil INT
DECLARE @Müs INT
DECLARE @Arac INT
DECLARE @Calisan INT
DECLARE @Makbuz INT
DECLARE @Hasar INT
DECLARE @Bas DATE
DECLARE @Bit DATE
DECLARE @Gecikme INT
DECLARE @teslimTar DATE
DECLARE @para MONEY
DECLARE @tar INT
DECLARE @Anapara Money
SELECT @Sil=kira_no FROM deleted
SELECT @Müs=m_no FROM deleted
SELECT @Arac=a_no FROM deleted
SELECT @Calisan=c_no FROM deleted
SELECT @Makbuz=mak_no FROM deleted
SELECT @Hasar=h_no FROM deleted
SELECT @Bas=bas_tar FROM deleted
SELECT @Bit=bit_tar FROM deleted
SELECT @tar=DATEDIFF(DAY,@Bas,@Bit) FROM deleted

SELECT @Gecikme=datediff(HOUR,@Bit,GETDATE())-8
IF EXISTS(SELECT @Gecikme WHERE @Gecikme<0)
BEGIN
	SELECT @Gecikme=0
END
SELECT @teslimTar=GETDATE()
SELECT @para=ucret*@tar FROM tblArac WHERE arac_no=@Arac
SELECT @Anapara=@gecikme*(@para*0.01)+@para
INSERT INTO tblSilinenKiralanmis VALUES(@Sil,@Müs,@Arac,@Calisan,@Makbuz,@Hasar,@Bas,@Bit)
UPDATE tblMakbuz set gecikme=@Gecikme, urcet=@Anapara, teslim_tar=@teslimTar WHERE makbuz_no=@sil
UPDATE tblArac set kiraDurumu=0
END
GO
CREATE TRIGGER kiraTablosuOlusurkene1
ON tblArac_Kiralama
INSTEAD OF INSERT
AS
BEGIN
	INSERT INTO tblMakbuz VALUES(NULL,NULL,NULL)
	INSERT INTO tblHasar VALUES(0,0)
	DECLARE @Müs INT
	DECLARE @Arac INT
	DECLARE @Calisan INT
	DECLARE @Makbuz INT
	DECLARE @Hasar INT
	DECLARE @Bas DATE
	DECLARE @Bit DATE
	SELECT @Müs=m_no FROM inserted
	SELECT @Arac=a_no FROM inserted
	SELECT @Calisan=c_no FROM inserted
	SELECT @Makbuz=makbuz_no FROM tblMakbuz ORDER BY makbuz_no ASC
	SELECT @Hasar=hasar_no FROM tblHasar ORDER BY hasar_no ASC
	SELECT @Bas=bas_tar FROM inserted
	SELECT @Bit=bit_tar FROM inserted
	INSERT INTO tblArac_Kiralama VALUES(@Müs,@Arac,@Calisan,@Makbuz,@Hasar,@Bas,@Bit)
	
END
GO
CREATE TRIGGER kayitSilmeEngeli
ON tblSilinenKiralanmis
FOR DELETE
AS
BEGIN
	PRINT 'Bu tablodan veri silmenize izin verilmemektedir.'
	ROLLBACK
END
GO
CREATE TRIGGER TabloSilmeEngeli
ON DATABASE
FOR DROP_TABLE
AS
BEGIN
	PRINT 'Bu veritabanýndan tablo silmenize izin verilmemektedir.'
	ROLLBACK
END
GO
create proc sp_aracKayit
@marka varchar(15),
@model varchar(15), @plaka varchar(9),
@yakitTuru varchar(6), @motorGucu int,
@tork int, @motorHacmi smallint,
@renk varchar(20), @vites varchar(8),
@klima bit, @ruhsatNo int,
@sigorta bit, @muayneBitTar date,
@ucret money, @kiraDurumu bit
as
insert into tblArac values(@marka,@model,@plaka,@yakitTuru,@motorGucu,
@tork,@motorHacmi,@renk,@vites,@klima,@ruhsatNo,@sigorta,@muayneBitTar,@ucret,@kiraDurumu)
GO
create proc sp_calisanEkle
@tc bigint,
@isim varchar(20),
@soyisim varchar(20),
@adres text,
@tel bigint,
@email varchar(50)
as 
insert into tblCalisan values(@tc,@isim,@soyisim,@adres,@tel,@email)
GO
create proc sp_aracGuncelle
@aracno int,
@marka varchar(15),
@model varchar(15), @plaka varchar(9),
@yakitTuru varchar(6), @motorGucu int,
@tork int, @motorHacmi smallint,
@renk varchar(20), @vites varchar(8),
@klima bit, @ruhsatNo int,
@sigorta bit, @muayneBitTar date,
@ucret money, @kiraDurumu bit
as
update tblArac set marka=@marka , model=@model, plaka=@plaka,
yakit_turu=@yakitTuru,motor_gucu=@motorGucu,tork=@tork,motor_hacmi=@motorHacmi,
renk=@renk,vites=@vites,klima=@klima,ruhsat_no=@ruhsatNo,
sigorta=@sigorta,muayne_bit_tar=@muayneBitTar,
ucret=@ucret,kiraDurumu=@kiraDurumu where arac_no=@aracno

GO
create proc sp_calisanGuncelle
@calisanno int, @tc bigint,@isim varchar(20),@soyisim varchar(20),@adres text,@tel bigint,@email varchar(50)
as
update tblCalisan set tc=@tc,isim=@isim, soyisim=@soyisim, adres=@adres , tel=@tel , email=@email  where calisan_no=@calisanno 
GO
create proc sp_musteriKayit
@ad varchar(20),
@soyad varchar(20),
@mus_tc bigint,
@adres text,
@mus_tel bigint,
@mus_email varchar(50),
@cinsiyet varchar(1),
@dogumtar date,
@dogumyer varchar(14)
as
insert into tblMusteri values(@ad,@soyad,@mus_tc,@adres,@mus_tel,@mus_email,@cinsiyet,@dogumtar,@dogumyer)
GO
create proc sp_markaArama
@marka varchar(15)
as 
select * from tblArac where marka=@marka
GO
create proc sp_modelArama
@model varchar(15)
as 
select * from tblArac where model=@model
GO
create proc sp_yakitVitesArama
@yakit_turu varchar(6),
@vites varchar(8)
as 
select * from tblArac where yakit_turu=@yakit_turu and vites=@vites

GO
--INSERT tblArac VALUES('LADA','SAMARA','81REC72','LPG',100,2500,1999,'KIRMIZ','MANUEL',0,23,1,'2019-11-02',100,0)
INSERT tblCalisan VALUES(33079394558,'Abdullah','CEVÝZ','EDÝRNE',5377063947,'ccceviz1@gmail.com')
INSERT tblKullanici VALUES(1,'Secati22','Secati22','ADMIN')
--INSERT tblMusteri VALUES('Abdullah Furkan','KOC',18234546887,'ÇANKIRI',5553879981,'furkankoc@gmail.com','E','1990-02-13','ÇANKIRI')
--INSERT tblEhliyet VALUES(1,11111111111,'A2','A+','2015-12-02','2045-12-02')
----INSERT tblMakbuz VALUES(0,150,getdate())
----INSERT tblHasar VALUES(0)
----INSERT tblArac_Kiralama VALUES(1,1,1,null,null,getdate(),'2017-12-12')
--execute sp_aracKayit 'mazda','mazda3','34f1715','mazot',2000,2250,1500,'kýrmýzý','OTOMATIK',0,101986,1,'10.19.2018',300,0
--execute sp_calisanEkle 22985611137,'Furkan','Aktaþ','Aliya Baba',5389621223,'furekansds@gmail.com'
--execute sp_aracGuncelle 1,'fgfgfg','sdsdds','34fk172','lpg',2000,2250,1500,'kýrmýzý','OTOMATIK',
--0,15523,1,'10.19.2018',300,0
--UPDATE tblArac SET kiraDurumu=0 where arac_no=2

--/*
--select * from tblArac
--UPDATE tblArac SET ucret=100
--select * from tblCalisan
--select * from tblKullanici
--select * from tblMusteri
--select * from tblEhliyet
--select * from tblArac_Kiralama
--select * from tblMakbuz
--SELECT * FROM tblHasar
--select * from tblSilinenKiralanmis 
--USE master
--DROP DATABASE arac_kiralama	
--DROP TABLE tblArac_Kiralama
--DELETE tblArac_Kiralama WHERE kira_no=1
--DELETE tblSilinenKiralanmis WHERE sil_no=1
--*/
