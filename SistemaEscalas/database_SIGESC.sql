CREATE DATABASE SIGESC;
use SIGESC;

CREATE TABLE usuario (
id INT PRIMARY KEY NOT NULL AUTO_INCREMENT,
tipo VARCHAR(100) NOT NULL,
nome VARCHAR (255) NOT NULL,
cpf VARCHAR (11) NOT NULL UNIQUE,
data_nascimento DATE NOT NULL,
telefone VARCHAR (11) NOT NULL,
email VARCHAR (255) NOT NULL UNIQUE,
re VARCHAR (255) NOT NULL UNIQUE
);

INSERT INTO usuario (tipo, nome, cpf, data_nascimento, telefone, email, re) 
VALUES
('Administrador', 'Lucas Guilherme', '01301239467', '1994-04-10', '69993579590', 
'lucassguilherme159@gmail.com', '08480'),
('Comum', 'Guilherme', '61353239467', '1993-04-10', '69993479590', 
'lucassguilherme@gmail.com', '08880');

CREATE TABLE especializacao (
id INT PRIMARY KEY AUTO_INCREMENT NOT NULL,
nome VARCHAR(255) NOT NULL
);

INSERT INTO especializacao (nome)
VALUES
('Mergulhador'),
('Operador Magirus'),
('Cat. D');

CREATE TABLE funcao (
id INT PRIMARY KEY AUTO_INCREMENT NOT NULL,
nome VARCHAR(255) NOT NULL
);

INSERT INTO funcao (nome)
VALUES
('Comandante de Guarnição'),
('Socorrista'),
('Radio-Operador');

CREATE TABLE combatente (
id INT PRIMARY KEY AUTO_INCREMENT NOT NULL,
nome VARCHAR (255) NOT NULL,
cpf VARCHAR (11) NOT NULL UNIQUE,
data_nascimento DATE NOT NULL,
telefone VARCHAR (11) NOT NULL,
email VARCHAR (255) NOT NULL UNIQUE,
re VARCHAR (255) NOT NULL UNIQUE
);

INSERT INTO combatente (nome, cpf, data_nascimento, telefone, email, re)
VALUES
('Lucas Guilherme', '01301239461', '1994-04-10', '69993579590', 'lucassguilherme159@gmail.com', '08480');

#tabela intermediária (n,n)
CREATE TABLE combatente_especializacao (
id_combatente INT NOT NULL,
id_especializacao INT NOT NULL,
PRIMARY KEY (id_combatente, id_especializacao),
FOREIGN KEY (id_combatente) REFERENCES combatente(id),
FOREIGN KEY (id_especializacao) REFERENCES especializacao(id)
);

INSERT INTO combatente_especializacao (id_combatente, id_especializacao)
VALUES
(1, 1);

CREATE TABLE combatente_funcao (
id_combatente INT NOT NULL,
id_funcao INT NOT NULL,
PRIMARY KEY (id_combatente, id_funcao),
FOREIGN KEY (id_combatente) REFERENCES combatente(id),
FOREIGN KEY (id_funcao) REFERENCES funcao(id)
);

INSERT INTO combatente_funcao (id_combatente, id_funcao)
VALUES
(1, 1);

CREATE TABLE escala (
id INT PRIMARY KEY NOT NULL AUTO_INCREMENT,
tipo VARCHAR(100),
data_inicio DATETIME NOT NULL,
data_final DATETIME NOT NULL,
descricao VARCHAR(255),
local_trabalho VARCHAR(255) NOT NULL,
regime_trabalho VARCHAR(100) NOT NULL,
id_usuario_fk INT NOT NULL,
FOREIGN KEY (id_usuario_fk) REFERENCES usuario(id)
);

INSERT INTO escala (tipo, data_inicio, data_final, descricao, local_trabalho, regime_trabalho,
id_usuario_fk)
VALUES
('Ordinária', '2024-12-17 07:30:00', '2024-12-18 07:30:00', 'Serviço diário de Socorro no 1ºSGBM',
'1SGBM/2GBM', '24 x 72', 1);

CREATE TABLE combatente_escala (
id_combatente INT NOT NULL,
id_escala INT NOT NULL,
PRIMARY KEY (id_combatente, id_escala),
FOREIGN KEY (id_combatente) REFERENCES combatente(id),
FOREIGN KEY (id_escala) REFERENCES escala(id) 
);

INSERT INTO combatente_escala (id_combatente, id_escala)
VALUES
(1, 1);





