
-- Script de criação de tabela do banco Demonetcore no Sqlite

CREATE TABLE Pessoa (
    Id        INTEGER      PRIMARY KEY AUTOINCREMENT,
    Nome      VARCHAR (50) NOT NULL,
    Latitude  DOUBLE       NOT NULL,
    Longitude DOUBLE       NOT NULL
);

CREATE TABLE CalculoHistoricoLog (
    Id        INTEGER  PRIMARY KEY AUTOINCREMENT,
    PessoaId  INT      NOT NULL,
    Distancia DOUBLE  NOT NULL,
    DataHora  DATETIME
);

CREATE TABLE CalculoHistoricoLog (
    Id              INTEGER PRIMARY KEY AUTOINCREMENT,
    PessoaOrigemId  INT     NOT NULL,
    PessoaDestinoId INT     NOT NULL,
    Distancia       DOUBLE NOT NULL
);

