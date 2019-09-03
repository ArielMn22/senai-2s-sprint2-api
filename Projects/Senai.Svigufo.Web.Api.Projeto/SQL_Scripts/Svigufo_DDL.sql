/* Isso é um comentário 
	'Um bloco comentado'
*/

-- Esta é apenas uma linha comentada

-- Cria uma novo banco de dados com o nome SENAI_SVIGUFO_TARDE
create database SENAI_SVIGUFO_TARDE;

-- Seleciona o banco de dados a ser utilizado
use SENAI_SVIGUFO_TARDE;

/*
	Create table <nome da tabela> cria uma nova tabela
	IDENTITY - AUTO-INCREMENTO
	PRIMARY KEY - Define que o campo será uma chave primária
*/
create table TIPOS_EVENTOS (
	ID int identity primary key
	,TITULO varchar(255) not null unique
);

create table INSTITUICOES(
	ID int identity primary key
	,RAZAO_SOCIAL varchar(255) not null
	,NOME_FANTASIA varchar(255) null
	,CNCPJ char(14) not null unique
	,LOGRADOURO varchar(255) not null
	,CEP char(8) not null
	,UF char(2) not null
	,CIDADE varchar(255) not null
);

create table EVENTOS(
	ID int identity primary key
	,TITULO varchar(255) not null
	,DESCRICAO text -- para campos com grande quantidade de dados
	,DATA_EVENTO datetime not null
	,ACESSO_LIVRE bit default (1) -- para valores 0 e 1, 0 false 1 true, com
	,ID_TIPO_EVENTO int 
	,ID_INSTITUICAO int
	--cria uma chave estrangeira e define que o campo esta relacionado a propriedade ID da tabela TIPO_EVENTOS
	,foreign key (ID_TiPO_EVENTO) references TIPOS_EVENTOS(ID)
	,foreign key (ID_INSTITUICAO) references INSTITUICOES(ID)
);

create table USUARIOS(
	ID int identity primary key
	,NOME varchar(255) not null
	,EMAIL varchar(255) not null unique
	,SENHA varchar(100) not null
	,TIPO_USUARIO varchar(100) not null
);

create table CONVITES(
	ID int identity primary key
	,ID_USUARIO int foreign key references USUARIOS(ID)
	,ID_EVENTO int foreign key references EVENTOS(ID)
	,SITUACAO char(1)
);