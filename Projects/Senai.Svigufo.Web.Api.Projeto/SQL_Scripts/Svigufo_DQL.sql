﻿USE SENAI_SVIGUFO_TARDE;
--===========================================================================SELECT EVENTO + TIPO EVENTO
SELECT 
	E.ID AS ID_EVENTO,
	E.TITULO AS TITULO_EVENTO, 
	E.DESCRICAO,
	E.DATA_EVENTO,
	E.ACESSO_LIVRE,
	TE.ID AS ID_TIPO_EVENTO,
	TE.TITULO AS TITULO_TIPO_EVENTO
FROM
	EVENTOS E INNER JOIN TIPOS_EVENTOS TE
ON
	E.ID_TIPO_EVENTO = TE.ID

--===========================================================================SELECT EVENTO + TIPO EVENTO + INSTITUICAO
SELECT 
	E.ID AS ID_EVENTO,
	E.TITULO AS TITULO_EVENTO, 
	E.DESCRICAO,
	E.DATA_EVENTO,
	E.ACESSO_LIVRE,
	TE.ID AS ID_TIPO_EVENTO,
	TE.TITULO AS TITULO_TIPO_EVENTO,
	I.ID AS ID_INSTITUICAO, 
	I.NOME_FANTASIA,
	I.RAZAO_SOCIAL,
	I.CNPJ,
	I.LOGRADOURO,
	I.CEP,
	I.UF,
	I.CIDADE
FROM
	EVENTOS E 
		INNER JOIN TIPOS_EVENTOS TE ON E.ID_TIPO_EVENTO = TE.ID
		INNER JOIN INSTITUICOES I ON E.ID_INSTITUICAO = I.ID

--===========================================================================CONVITES
SELECT * FROM USUARIOS
SELECT * FROM CONVITES
INSERT INTO CONVITES(ID_EVENTO, ID_USUARIO, SITUACAO) VALUES (2, 1, 1)
INSERT INTO CONVITES(ID_EVENTO, ID_USUARIO, SITUACAO) VALUES (2, 5, 1)

SELECT
	C.ID AS ID_CONVITE,
	C.SITUACAO,
	E.ID AS ID_EVENTO,
	E.TITULO AS TITULO_EVENTO,
	E.DATA_EVENTO,
	U.ID AS ID_USUARIO,
	U.NOME AS NOME_USUARIO,
	U.EMAIL AS EMAIL_USUARIO,
	TE.ID AS ID_TIPO_EVENTO,
	TE.TITULO AS TITULO_TIPO_EVENTO
FROM
	CONVITES C
		INNER JOIN EVENTOS E ON C.ID_EVENTO = E.ID
		INNER JOIN USUARIOS U ON C.ID_USUARIO = U.ID
		INNER JOIN TIPOS_EVENTOS TE ON E.ID_TIPO_EVENTO = TE.ID
--===========================================================================EVENTOS
SELECT * FROM TIPOS_EVENTOS

SELECT * FROM EVENTOS
INSERT INTO EVENTOS(TITULO,DESCRICAO, DATA_EVENTO, ACESSO_LIVRE, ID_TIPO_EVENTO, ID_INSTITUICAO)
	VALUES ('Tecnilogias C#', 'Aprenda técnicas para WebAPI', '2019-04-05', 1, 2, 10)

--===========================================================================INSTITUICOES
select * from INSTITUICOES
insert into INSTITUICOES(RAZAO_SOCIAL, NOME_FANTASIA, CNPJ, LOGRADOURO, CEP, UF, CIDADE)
	values ('SENAI', 'SENAI de Informática', 11111111111111, 'Alameda Barão de Limeira, 222', '01215-010', 'SP', 'São Paulo')
--===========================================================================USUARIOS
SELECT * FROM USUARIOS