CREATE DATABASE SIGESC;
use SIGESC;

CREATE TABLE usuario (
id_usuario INT PRIMARY KEY NOT NULL AUTO_INCREMENT,
tipo_usuario VARCHAR(100) NOT NULL,
nome_usuario VARCHAR(255) NOT NULL,
codigo_registro INT NOT NULL
);

CREATE TABLE especializacao (
id_especializacao INT PRIMARY KEY AUTO_INCREMENT NOT NULL,
nome_especializacao VARCHAR(255) NOT NULL
);

CREATE TABLE funcao (
id_funcao INT PRIMARY KEY AUTO_INCREMENT NOT NULL,
nome_funcao VARCHAR(255) NOT NULL
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









