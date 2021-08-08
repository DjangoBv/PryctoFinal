--CREACION BASE DE DATOS 
create database BD_VETERINARIA 
go
use DB_VETERINARIA
go
--CREACION DE TABLAS
CREATE table tb_cliente
(
id_cli varchar(8) primary key not null, 
nom_cli varchar(40) not null,
ape_cli varchar(40) null,
telFijo_cli varchar(9) null, 
telMovil_cli varchar(9) null,
cor_cli varchar(40) not null, 
dir_cli varchar(40) null
)
go
create table tb_mascota 
(
id_mas varchar(8) primary key not null, 
nom_mas varchar(40)not null,
fecNacimiento_mas datetime not null, 
raza_mas varchar(40)not null,
id_cli varchar(8) not null,
id_tipMas varchar(8) not null,
CONSTRAINT fk_id_cli FOREIGN KEY (id_cli)
REFERENCES tb_cliente(id_cli),
CONSTRAINT fk_id_tipMas FOREIGN KEY (id_tipMas)
REFERENCES tb_tipoMascota(id_tipMas)
) 
GO
create table tb_tipoMascota
(
id_tipMas varchar(8) primary key not null, 
descripcion_tipMas varchar(40)not null
) 
GO
create table tb_consulta
(
id_cons varchar(8) primary key not null,
fec_cons datetime not null,
sint_cons varchar(40) not null,
diag_cons varchar(40) not null,
id_mas varchar(8) not null,
CONSTRAINT fk_id_mas FOREIGN KEY (id_mas)
REFERENCES tb_mascota(id_mas)
)
GO
create table tb_usuarioVet
(
id_usu int primary key not null,
usuario varchar(6) not null,
contraseña varchar(6) not null,
)
GO
create table tb_reserva
(
id_res varchar(8) primary key not null,
fec_res datetime not null,
id_cli varchar(8) not null,
id_mas varchar(8) not null,
CONSTRAINT fk_id_cli2 FOREIGN KEY (id_cli)
REFERENCES tb_cliente(id_cli),
CONSTRAINT fk_id_mas2 FOREIGN KEY (id_mas)
REFERENCES tb_mascota(id_mas)
)
GO
alter table tb_reserva add id_usu int,
CONSTRAINT fk_id_usu FOREIGN KEY (id_usu)
REFERENCES tb_usuarioVet(id_usu)
GO
INSERT INTO tb_cliente (id_cli, nom_cli, ape_cli, telFijo_cli, telMovil_cli, cor_cli, dir_cli)
	VALUES ('73146298', 'Luis', 'Caccha', '991772628', '056211057', 'renato.caccha.7@hotmail.com', 'San Joaquin')
GO
INSERT INTO tb_tipoMascota (id_tipMas, descripcion_tipMas)
	VALUES ('1','pequeño'), ('2', 'mediano'), ('3','grande')
GO
INSERT INTO tb_mascota (id_mas, nom_mas, fecNacimiento_mas, raza_mas, id_cli, id_tipMas)
	VALUES ('masc0001','Toby','04/08/2021','chitzu','73146298','1')
GO
INSERT INTO tb_reserva (id_res, fec_res, id_cli, id_mas)
	VALUES ('rese0001','09/08/2021','73146298','masc0001')
GO
INSERT INTO tb_consulta (id_cons, fec_cons, sint_cons, diag_cons, id_mas)
	VALUES ('cons0001','09/08/2021','Diarrea excesiva','Parasitos','masc0001')
GO
INSERT INTO tb_usuarioVet(id_usu, usuario, contraseña)
	VALUES (123456789,'admin1','admin1')
GO

select*from tb_consulta
go