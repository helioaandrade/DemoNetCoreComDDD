
-- Script de criação de tabela do banco Demonetcore no Sqlite

CREATE TABLE Pessoa (
    Id        INTEGER         PRIMARY KEY AUTOINCREMENT,
    Nome      VARCHAR (50)    NOT NULL,
    Latitude  DATETIME (2, 9) NOT NULL,
    Longitude DECIMAL (2, 9)  NOT NULL
);


CREATE TABLE CalculoHistoricoLog (
    Id                INTEGER  PRIMARY KEY AUTOINCREMENT,
    PessoaOrigemId    INT      NOT NULL,
    PessoaDestinoId   INT      NOT NULL,
    Distancia         DOUBLE   NOT NULL,
    UltimaAtualizacao DATETIME DEFAULT (CURRENT_TIMESTAMP) 
);


