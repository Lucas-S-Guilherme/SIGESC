CREATE DATABASE SIGESC;

use SIGESC;

CREATE TABLE usuario (
id_usuario INT PRIMARY KEY NOT NULL AUTO_INCREMENT,
tipo_usuario VARCHAR(100) NOT NULL,
nome_usuario VARCHAR(255) NOT NULL,
registro_funcional VARCHAR(255) NOT NULL
);

CREATE TABLE especializacao (
id_especializacao INT PRIMARY KEY AUTO_INCREMENT NOT NULL,
nome_especializacao VARCHAR(255) NOT NULL,
descricao_especializacao VARCHAR(255) NOT NULL,
sigla_especializacao VARCHAR (4) NOT NULL
);

CREATE TABLE funcao (
id_funcao INT PRIMARY KEY AUTO_INCREMENT NOT NULL,
nome_funcao VARCHAR(255) NOT NULL,
sigla_funcao VARCHAR (4) NOT NULL
);

CREATE TABLE restricao (
id_restricao INT PRIMARY KEY AUTO_INCREMENT NOT NULL,
nome_restricao VARCHAR(100) NOT NULL,
grupo_restricao VARCHAR(100),
descricao_restricao VARCHAR (1000)
);

CREATE TABLE combatente (
id_combatente INT PRIMARY KEY AUTO_INCREMENT NOT NULL,
nome_combatente VARCHAR (255) NOT NULL,
cpf_combatente VARCHAR (255) NOT NULL UNIQUE,
data_nascimento_combatente DATE NOT NULL,
telefone_combatente VARCHAR (11),
email_combatente VARCHAR (255),
re_combatente VARCHAR (255)
);

#tabela intermediária (n,n)
CREATE TABLE combatente_especializacao (
id_combatente INT NOT NULL,
id_especializacao INT NOT NULL,
PRIMARY KEY (id_combatente, id_especializacao),
FOREIGN KEY (id_combatente) REFERENCES combatente(id_combatente),
FOREIGN KEY (id_especializacao) REFERENCES especializacao(id_especializacao)
);

CREATE TABLE combatente_funcao (
id_combatente INT NOT NULL,
id_funcao INT NOT NULL,
PRIMARY KEY (id_combatente, id_funcao),
FOREIGN KEY (id_combatente) REFERENCES combatente(id_combatente),
FOREIGN KEY (id_funcao) REFERENCES funcao(id_funcao)
);

#FAZER ESSA 3ª TABELA
CREATE TABLE combatente_restricao (
id_combatente INT NOT NULL
);

CREATE TABLE turno_trabalho (
id_turno_trabalho INT NOT NULL AUTO_INCREMENT PRIMARY KEY,
data_inicio DATETIME NOT NULL,
data_fim DATETIME NOT NULL
);

CREATE TABLE turno_trabalho_combatente ( 
id_turno_combatente INT NOT NULL AUTO_INCREMENT PRIMARY KEY,
id_combatente INT NOT NULL,
id_turno INT NOT NULL,
FOREIGN KEY (id_combatente) REFERENCES combatente (id_combatente),
FOREIGN KEY (id_turno) REFERENCES turno_trabalho (id_turno_trabalho)
);

CREATE TABLE escala (
id_escala INT NOT NULL PRIMARY KEY AUTO_INCREMENT,
nome_escala VARCHAR (255),
data_inicio DATETIME NOT NULL,
data_fim DATETIME NOT NULL,
data_confeccao DATETIME NOT NULL,
id_usuario INT NOT NULL,
FOREIGN KEY (id_usuario) REFERENCES usuario (id_usuario),
id_turno_trabalho INT NOT NULL,
FOREIGN KEY (id_turno_trabalho) REFERENCES turno_trabalho (id_turno_trabalho)
);