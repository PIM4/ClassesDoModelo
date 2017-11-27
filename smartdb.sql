﻿CREATE DATABASE SMARTDB;

USE SMARTDB;

CREATE TABLE PESSOA
(
ID_PESSOA INT PRIMARY KEY IDENTITY,
NOME VARCHAR(60) NOT NULL,
CPF CHAR(11) UNIQUE NOT NULL,
RG VARCHAR(10) NOT NULL,
DT_NASC DATE,
STS_ATIVO BIT NOT NULL
);

CREATE TABLE CONDOMINIO (
ID_COND INT PRIMARY KEY IDENTITY,
NOME VARCHAR(50) NOT NULL,
DT_INAUGURACAO DATE NOT NULL,
PROPRIETARIO VARCHAR(50) NOT NULL,
CNPJ CHAR(14) NOT NULL,
STS_ATIVO BIT NOT NULL
);

CREATE TABLE BLOCO (
ID_BLOCO INT PRIMARY KEY IDENTITY,
IDENTIFICACAO VARCHAR(30) NOT NULL,
ID_COND INT NOT NULL,
STS_ATIVO BIT NOT NULL
);

ALTER TABLE BLOCO ADD FOREIGN KEY (ID_COND) REFERENCES CONDOMINIO(ID_COND);

CREATE TABLE UNIDADE (
ID_UNIDADE INT PRIMARY KEY IDENTITY,
IDENTIFICACAO VARCHAR(10) NOT NULL,
QT_VAGAS INT,
ID_BLOCO INT NOT NULL,
ID_PESSOA INT NOT NULL,
STS_ATIVO BIT NOT NULL
);

ALTER TABLE UNIDADE ADD FOREIGN KEY (ID_BLOCO) REFERENCES BLOCO(ID_BLOCO);
ALTER TABLE UNIDADE ADD FOREIGN KEY (ID_PESSOA) REFERENCES PESSOA(ID_PESSOA);

CREATE TABLE VEICULO (
ID_VEICULO INT PRIMARY KEY IDENTITY,
PLACA CHAR(7) UNIQUE NOT NULL,
MODELO VARCHAR(30) NOT NULL,
ID_UNIDADE INT NOT NULL,
STS_ATIVO BIT NOT NULL
);

ALTER TABLE VEICULO ADD FOREIGN KEY (ID_UNIDADE) REFERENCES UNIDADE(ID_UNIDADE);

CREATE TABLE VISITANTE (
ID_VISITANTE INT PRIMARY KEY IDENTITY,
NOME VARCHAR(60) NOT NULL,
DOCUMENTO VARCHAR(14) UNIQUE NOT NULL,
IMG VARCHAR(100),
STS_ATIVO BIT NOT NULL
);

CREATE TABLE VISITA (
ID_VISITA INT PRIMARY KEY IDENTITY,
DT_INICIO DATETIME NOT NULL,
DT_FINAL DATETIME NOT NULL,
ID_VISITANTE INT NOT NULL,
ID_UNIDADE INT NOT NULL,
STS_ATIVO BIT NOT NULL
);

ALTER TABLE VISITA ADD FOREIGN KEY (ID_VISITANTE) REFERENCES VISITANTE(ID_VISITANTE);
ALTER TABLE VISITA ADD FOREIGN KEY (ID_UNIDADE) REFERENCES UNIDADE(ID_UNIDADE);

CREATE TABLE EVENTO (
ID_EVENTO INT PRIMARY KEY IDENTITY,
TITULO VARCHAR(30) NOT NULL,
ID_UNIDADE INT NOT NULL,
STS_ATIVO BIT NOT NULL
);

ALTER TABLE EVENTO ADD FOREIGN KEY (ID_UNIDADE) REFERENCES UNIDADE(ID_UNIDADE);

CREATE TABLE AREA (
ID_AREA INT PRIMARY KEY IDENTITY,
NOME VARCHAR(30),
DESCRICAO VARCHAR(50) NOT NULL,
RESERVA BIT NOT NULL,
CAPACIDADE_MAX INT NOT NULL,
STS_ATIVO BIT NOT NULL
);

CREATE TABLE AREA_EVENTO (
ID_AREA_EVENTO INT PRIMARY KEY IDENTITY,
ID_EVENTO INT NOT NULL,
ID_AREA INT NOT NULL,
STS_ATIVO BIT NOT NULL
);

ALTER TABLE AREA_EVENTO ADD FOREIGN KEY (ID_EVENTO) REFERENCES EVENTO(ID_EVENTO);
ALTER TABLE AREA_EVENTO ADD FOREIGN KEY (ID_AREA) REFERENCES AREA(ID_AREA);

CREATE TABLE CORRESPONDENCIA (
ID_CORRESPONDENCIA INT PRIMARY KEY IDENTITY,
DESCRICAO VARCHAR(50) NOT NULL,
DT_ENTRADA DATETIME NOT NULL,
DT_SAIDA DATETIME NOT NULL,
ID_UNIDADE INT NOT NULL,
ID_PESSOA INT NOT NULL,
STS_ATIVO BIT NOT NULL,
OBS_CANC TEXT 
);

ALTER TABLE CORRESPONDENCIA ADD FOREIGN KEY (ID_UNIDADE) REFERENCES UNIDADE(ID_UNIDADE);
ALTER TABLE CORRESPONDENCIA ADD FOREIGN KEY (ID_PESSOA) REFERENCES PESSOA(ID_PESSOA);

CREATE TABLE MORADOR (
ID_MORADOR INT PRIMARY KEY IDENTITY,
ID_PESSOA INT NOT NULL,
ID_UNIDADE INT NOT NULL,
STS_ATIVO BIT NOT NULL
);

ALTER TABLE MORADOR ADD FOREIGN KEY (ID_UNIDADE) REFERENCES UNIDADE(ID_UNIDADE);
ALTER TABLE MORADOR ADD FOREIGN KEY (ID_PESSOA) REFERENCES PESSOA(ID_PESSOA);

CREATE TABLE LOGIN (
ID_LOGIN INT PRIMARY KEY IDENTITY,
EMAIL VARCHAR(50) NOT NULL,
SENHA VARCHAR(15) NOT NULL,
NIVEL_ACESSO CHAR(1) NOT NULL,
ID_PESSOA INT NOT NULL,
STS_ATIVO BIT NOT NULL
);

ALTER TABLE LOGIN ADD FOREIGN KEY (ID_PESSOA) REFERENCES PESSOA(ID_PESSOA);

CREATE TABLE LOG (
ID_LOG INT PRIMARY KEY IDENTITY,
ID_LOGIN INT NOT NULL,
ID_REGISTRO INT NOT NULL,
TABELA VARCHAR(20) NOT NULL,
DT_OPERACAO DATETIME NOT NULL,
TIPO_OPERACAO VARCHAR(30) NOT NULL
);

ALTER TABLE LOG ADD FOREIGN KEY (ID_LOGIN) REFERENCES LOGIN(ID_LOGIN);

CREATE TABLE ENQUETE (
ID_ENQUETE INT PRIMARY KEY IDENTITY,
PERGUNTA VARCHAR(50) NOT NULL,
DT_INICIO DATETIME NOT NULL,
DT_FINAL DATETIME NOT NULL,
ID_COND INT NOT NULL,
STS_ATIVO BIT NOT NULL
);

ALTER TABLE ENQUETE ADD FOREIGN KEY (ID_COND) REFERENCES CONDOMINIO(ID_COND);

CREATE TABLE VOTO (
ID_VOTO INT PRIMARY KEY IDENTITY,
ID_ENQUETE INT NOT NULL,
ID_ENQUETE_ALTERNATIVAS INT NOT NULL,
ID_PESSOA INT NOT NULL,
STS_ATIVO BIT NOT NULL
);

ALTER TABLE VOTO ADD FOREIGN KEY (ID_ENQUETE) REFERENCES ENQUETE(ID_ENQUETE);
ALTER TABLE VOTO ADD FOREIGN KEY (ID_PESSOA) REFERENCES PESSOA(ID_PESSOA);

CREATE TABLE ENQUETE_ALTERNATIVAS (
ID_ENQUETE_ALTERNATIVAS INT PRIMARY KEY IDENTITY,
TEXTO VARCHAR(100) NOT NULL,
ID_ENQUETE INT NOT NULL,
STS_ATIVO BIT NOT NULL
);

ALTER TABLE ENQUETE_ALTERNATIVAS ADD FOREIGN KEY (ID_ENQUETE) REFERENCES ENQUETE(ID_ENQUETE);

CREATE TABLE REC_SUGEST (
ID_RS INT PRIMARY KEY IDENTITY,
TITULO VARCHAR(40) NOT NULL,
DESCRICAO TEXT,
DT_RS DATETIME NOT NULL,
TIPO CHAR(1) NOT NULL,
ID_PESSOA INT NOT NULL,
STS_ATIVO BIT NOT NULL
);

ALTER TABLE REC_SUGEST ADD FOREIGN KEY (ID_PESSOA) REFERENCES PESSOA(ID_PESSOA);

CREATE TABLE CARGO (
ID_CARGO INT PRIMARY KEY IDENTITY,
DESCRICAO VARCHAR(30) NOT NULL,
STS_ATIVO BIT NOT NULL
);

CREATE TABLE FUNCIONARIO (
ID_FUNCIONARIO INT PRIMARY KEY IDENTITY,
ID_CARGO INT NOT NULL,
ID_PESSOA INT NOT NULL,
STS_ATIVO BIT NOT NULL
);

ALTER TABLE FUNCIONARIO ADD FOREIGN KEY (ID_PESSOA) REFERENCES PESSOA(ID_PESSOA);
ALTER TABLE FUNCIONARIO ADD FOREIGN KEY (ID_CARGO) REFERENCES CARGO(ID_CARGO);

CREATE TABLE TELEFONE (
ID_TELEFONE INT PRIMARY KEY IDENTITY,
FIXO VARCHAR(13),
CELULAR VARCHAR(14),
ID_PESSOA INT,
STS_ATIVO BIT NOT NULL,
ID_FORNECEDOR INT
);

ALTER TABLE TELEFONE ADD FOREIGN KEY (ID_PESSOA) REFERENCES PESSOA(ID_PESSOA);
ALTER TABLE TELEFONE ADD DESCRICAO VARCHAR(30) NOT NULL;

CREATE TABLE ENDERECO (
ID_ENDERECO INT PRIMARY KEY IDENTITY,
LOGRADOURO VARCHAR(60) NOT NULL,
NUMERO VARCHAR(10) NOT NULL,
COMPLEMENTO VARCHAR(30),
BAIRRO VARCHAR(30) NOT NULL,
CIDADE VARCHAR(30) NOT NULL,
ESTADO CHAR(2) NOT NULL,
CEP CHAR(8) NOT NULL,
DESCRICAO VARCHAR(30),
ID_PESSOA INT,
STS_ATIVO INT NOT NULL,
ID_FORNECEDOR INT
);

ALTER TABLE ENDERECO ADD FOREIGN KEY (ID_PESSOA) REFERENCES PESSOA(ID_PESSOA);

CREATE TABLE TIPO_OBRA (
ID_TIPO_OBRA INT PRIMARY KEY IDENTITY,
DESCRICAO VARCHAR(30) NOT NULL,
STS_ATIVO BIT NOT NULL
);

CREATE TABLE OBRA (
ID_OBRA INT PRIMARY KEY IDENTITY,
DESCRICAO VARCHAR(40) NOT NULL,
DT_INICIO DATETIME NOT NULL,
DT_PREVISAO_TERMINO DATE NOT NULL,
DT_TERMINO DATETIME NOT NULL,
FINALIZADA BIT NOT NULL,
ID_AREA INT NOT NULL,
ID_TIPO_OBRA INT NOT NULL,
ID_COND INT NOT NULL,
STS_ATIVO BIT NOT NULL
);

ALTER TABLE OBRA ADD FOREIGN KEY (ID_TIPO_OBRA) REFERENCES TIPO_OBRA(ID_TIPO_OBRA);
ALTER TABLE OBRA ADD FOREIGN KEY (ID_AREA) REFERENCES AREA(ID_AREA);
ALTER TABLE OBRA ADD FOREIGN KEY (ID_COND) REFERENCES CONDOMINIO(ID_COND);

CREATE TABLE AVISO (
ID_AVISO INT PRIMARY KEY IDENTITY,
TITULO VARCHAR(30) NOT NULL,
DESCRICAO TEXT NOT NULL,
DT_AVISO DATETIME NOT NULL,
ID_COND INT NOT NULL,
STS_ATIVO BIT NOT NULL
);

ALTER TABLE AVISO ADD FOREIGN KEY (ID_COND) REFERENCES CONDOMINIO(ID_COND);
ALTER TABLE AVISO ADD COLUMN VISUALIZADO BIT;

CREATE TABLE TIPO_SERVICO (
ID_TIPO_SERVICO INT PRIMARY KEY IDENTITY,
DESCRICAO VARCHAR(30) NOT NULL,
STS_ATIVO BIT NOT NULL
);

CREATE TABLE FORNECEDOR (
ID_FORNECEDOR INT PRIMARY KEY IDENTITY,
RAMO_ATV VARCHAR(40) NOT NULL,
CNPJ CHAR(14) UNIQUE NOT NULL,
STS_ATIVO BIT NOT NULL
);

ALTER TABLE FORNECEDOR ADD RAZAO_SOCIAL VARCHAR(60) NOT NULL;

CREATE TABLE TERCEIRO (
ID_TERCEIRO INT PRIMARY KEY IDENTITY,
ID_TIPO_SERVICO INT NOT NULL,
ID_FORNECEDOR INT, 
ID_PESSOA INT NOT NULL,
STS_ATIVO BIT NOT NULL
);

ALTER TABLE TERCEIRO ADD FOREIGN KEY (ID_PESSOA) REFERENCES PESSOA(ID_PESSOA);
ALTER TABLE TERCEIRO ADD FOREIGN KEY (ID_TIPO_SERVICO) REFERENCES TIPO_SERVICO(ID_TIPO_SERVICO);
ALTER TABLE TERCEIRO ADD FOREIGN KEY (ID_FORNECEDOR) REFERENCES FORNECEDOR(ID_FORNECEDOR);

CREATE TABLE TERCEIRO_OBRA (
ID_TERCEIRO_OBRA INT PRIMARY KEY IDENTITY,
ID_TERCEIRO INT NOT NULL,
ID_OBRA INT NOT NULL,
STS_ATIVO BIT NOT NULL
);

ALTER TABLE TERCEIRO_OBRA ADD FOREIGN KEY (ID_TERCEIRO) REFERENCES TERCEIRO(ID_TERCEIRO);
ALTER TABLE TERCEIRO_OBRA ADD FOREIGN KEY (ID_OBRA) REFERENCES OBRA(ID_OBRA);

CREATE TABLE TIPO_CONTA(
ID_TIPO_CONTA INT PRIMARY KEY IDENTITY,
DESCRICAO VARCHAR(40) NOT NULL,
STS_ATIVO BIT NOT NULL
);

CREATE TABLE CONTA_PAGAR (
ID_CONTA_PAGAR INT PRIMARY KEY IDENTITY,
VALOR DECIMAL NOT NULL,
DT_PAGTO DATETIME NOT NULL,
ID_TIPO_CONTA INT NOT NULL,
ID_FORNECEDOR INT NOT NULL,
ID_COND INT NOT NULL,
STS_ATIVO BIT NOT NULL
);

ALTER TABLE CONTA_PAGAR ADD FOREIGN KEY (ID_TIPO_CONTA) REFERENCES TIPO_CONTA(ID_TIPO_CONTA);
ALTER TABLE CONTA_PAGAR ADD FOREIGN KEY (ID_FORNECEDOR) REFERENCES FORNECEDOR(ID_FORNECEDOR);
ALTER TABLE CONTA_PAGAR ADD FOREIGN KEY (ID_COND) REFERENCES CONDOMINIO(ID_COND);

CREATE TABLE PARAMETROS (
ID_PARAMETRO INT PRIMARY KEY IDENTITY,
VAGAS_UNIDADE BIT NOT NULL,
ID_COND INT NOT NULL,
STS_ATIVO INT NOT NULL
);

ALTER TABLE PARAMETROS ADD FOREIGN KEY (ID_COND) REFERENCES CONDOMINIO(ID_COND);

CREATE TABLE CONTA_RECEBER(
ID_CONTA_RECEBER INT PRIMARY KEY IDENTITY,
DT_CONTA_RECEBER DATETIME NOT NULL,
VALOR DECIMAL NOT NULL,
ID_COND INT NOT NULL,
ID_UNIDADE INT NOT NULL,
STS_ATIVO BIT NOT NULL
);

ALTER TABLE CONTA_RECEBER ADD FOREIGN KEY (ID_COND) REFERENCES CONDOMINIO(ID_COND);
ALTER TABLE CONTA_RECEBER ADD FOREIGN KEY (ID_UNIDADE) REFERENCES UNIDADE(ID_UNIDADE);
ALTER TABLE CONTA_RECEBER ADD COLUMN DIA_PAGTO INT;
ALTER TABLE CONTA_RECEBER DROP COLUMN ID_COND;
ALTER TABLE CONTA_RECEBER ADD COLUMN OBSERVACAO TEXT;