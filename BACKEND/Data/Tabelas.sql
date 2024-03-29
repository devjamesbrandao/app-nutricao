/* Lógico_1: */

CREATE TABLE PRODUTO (
    ID INTEGER PRIMARY KEY,
    Nome VARCHAR(250),
    CodBarra VARCHAR(20)
);

CREATE TABLE PRODUTO_INGREDIENTE (
    FK_PRODUTO_ID INTEGER,
    FK_INGREDIENTE_ID INTEGER
);

CREATE TABLE INGREDIENTE (
    ID INTEGER PRIMARY KEY,
    Descricao VARCHAR(250)
);

CREATE TABLE RESTRICAO_INGREDIENTE (
    FK_INGREDIENTE_ID INTEGER,
    FK_RESTRICAO_ALIMENTAR_ID INTEGER
);

CREATE TABLE RESTRICAO_ALIMENTAR (
    ID INTEGER PRIMARY KEY,
    Descricao VARCHAR(250)
);

CREATE TABLE USUARIO_RESTRICAO (
    FK_RESTRICAO_ALIMENTAR_ID INTEGER,
    FK_USUARIO_ID INTEGER
);

CREATE TABLE USUARIO (
    ID INTEGER PRIMARY KEY,
    Nome VARCHAR(250)
);
 
ALTER TABLE PRODUTO_INGREDIENTE ADD CONSTRAINT FK_PRODUTO_INGREDIENTE_1
    FOREIGN KEY (FK_PRODUTO_ID)
    REFERENCES PRODUTO (ID)
    ON DELETE SET NULL;
 
ALTER TABLE PRODUTO_INGREDIENTE ADD CONSTRAINT FK_PRODUTO_INGREDIENTE_2
    FOREIGN KEY (FK_INGREDIENTE_ID)
    REFERENCES INGREDIENTE (ID)
    ON DELETE SET NULL;
 
ALTER TABLE RESTRICAO_INGREDIENTE ADD CONSTRAINT FK_RESTRICAO_INGREDIENTE_1
    FOREIGN KEY (FK_INGREDIENTE_ID)
    REFERENCES INGREDIENTE (ID)
    ON DELETE SET NULL;
 
ALTER TABLE RESTRICAO_INGREDIENTE ADD CONSTRAINT FK_RESTRICAO_INGREDIENTE_2
    FOREIGN KEY (FK_RESTRICAO_ALIMENTAR_ID)
    REFERENCES RESTRICAO_ALIMENTAR (ID)
    ON DELETE SET NULL;
 
ALTER TABLE USUARIO_RESTRICAO ADD CONSTRAINT FK_USUARIO_RESTRICAO_1
    FOREIGN KEY (FK_RESTRICAO_ALIMENTAR_ID)
    REFERENCES RESTRICAO_ALIMENTAR (ID)
    ON DELETE SET NULL;
 
ALTER TABLE USUARIO_RESTRICAO ADD CONSTRAINT FK_USUARIO_RESTRICAO_2
    FOREIGN KEY (FK_USUARIO_ID)
    REFERENCES USUARIO (ID)
    ON DELETE SET NULL;