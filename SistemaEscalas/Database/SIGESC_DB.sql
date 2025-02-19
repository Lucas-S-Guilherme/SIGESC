CREATE DATABASE SIGESC;

#DROP DATABASE SIGESC;

use SIGESC;

CREATE TABLE usuario (
id_usuario INT PRIMARY KEY NOT NULL AUTO_INCREMENT,
tipo_usuario VARCHAR(50) NOT NULL,
nome_usuario VARCHAR(255) NOT NULL,
cpf_usuario VARCHAR (11) NOT NULL UNIQUE,
data_nascimento_usuario DATE NOT NULL,
telefone_usuario VARCHAR (11),
email_usuario VARCHAR (255),
matricula VARCHAR(9) NOT NULL
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
grupo_restricao VARCHAR(2),
descricao_restricao VARCHAR (1000)
);

CREATE TABLE combatente (
id_combatente INT PRIMARY KEY AUTO_INCREMENT NOT NULL,
nome_combatente VARCHAR (255) NOT NULL,
cpf_combatente VARCHAR (11) NOT NULL UNIQUE,
data_nascimento_combatente DATE NOT NULL,
telefone_combatente VARCHAR (11),
email_combatente VARCHAR (255),
matricula_combatente VARCHAR (9) NOT NULL UNIQUE,
ultimo_turno_trabalhado DATETIME
);

CREATE TABLE regra_trabalho (
id_regra_trabalho INT PRIMARY KEY AUTO_INCREMENT NOT NULL,
descricao_regra_trabalho VARCHAR(255),
horas_descanso_minimas 	INT NOT NULL
);

#tabela associativa (tabela de junção) (n,n)
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
id_combatente INT NOT NULL,
id_restricao INT NOT NULL,
PRIMARY KEY (id_combatente, id_restricao),
FOREIGN KEY (id_combatente) REFERENCES combatente (id_combatente),
FOREIGN KEY (id_restricao) REFERENCES restricao (id_restricao)
);

CREATE TABLE escala (
id_escala INT NOT NULL PRIMARY KEY AUTO_INCREMENT,
nome_escala VARCHAR (255),
local_trabalho VARCHAR (255),
data_inicio DATETIME NOT NULL,
data_fim DATETIME NOT NULL,
data_confeccao TIMESTAMP DEFAULT CURRENT_TIMESTAMP,
id_usuario INT NOT NULL,
FOREIGN KEY (id_usuario) REFERENCES usuario (id_usuario)
);

# usado para o período geral de trabalho
CREATE TABLE turno_trabalho (
id_turno_trabalho INT NOT NULL AUTO_INCREMENT PRIMARY KEY,
data_inicio DATETIME NOT NULL,
data_fim DATETIME NOT NULL,
id_escala INT NOT NULL,
FOREIGN KEY (id_escala) REFERENCES escala (id_escala)
);

#usado para o turno específico de trabalho dentro do geral (de cada combatente)
CREATE TABLE turno_combatente ( 
id_turno_combatente INT NOT NULL AUTO_INCREMENT PRIMARY KEY,
id_combatente INT NOT NULL,
id_turno INT NOT NULL,
hora_inicio DATETIME NOT NULL,
hora_fim DATETIME NOT NULL,
status_descanso ENUM('OK', 'VIOLADO') NOT NULL DEFAULT 'OK',
FOREIGN KEY (id_combatente) REFERENCES combatente (id_combatente),
FOREIGN KEY (id_turno) REFERENCES turno_trabalho (id_turno_trabalho)
);

CREATE VIEW combatente_ultimos_turnos AS
SELECT 
    c.id_combatente,
    c.nome_combatente,
    tt.id_turno_trabalho,
    tt.data_inicio,
    tt.data_fim,
    ttc.hora_inicio,
    ttc.hora_fim,
    TIMESTAMPDIFF(HOUR, IFNULL(LAG(ttc.hora_fim) OVER (PARTITION BY c.id_combatente ORDER BY ttc.hora_inicio), NOW()), ttc.hora_inicio) AS horas_descanso
FROM turno_combatente ttc
JOIN combatente c ON ttc.id_combatente = c.id_combatente
JOIN turno_trabalho tt ON ttc.id_turno = tt.id_turno_trabalho;

DELIMITER $$

CREATE TRIGGER verificar_descanso_antes_insert
BEFORE INSERT ON turno_combatente
FOR EACH ROW
BEGIN
    DECLARE ultimo_fim DATETIME;
    DECLARE horas_descanso INT;

    -- Verifica se os horários de início e fim são válidos
    IF NEW.hora_inicio IS NULL OR NEW.hora_fim IS NULL THEN
        SIGNAL SQLSTATE '45000'
        SET MESSAGE_TEXT = 'Os horários de início e fim do turno são obrigatórios.';
    END IF;

    -- Obtém o fim do último turno trabalhado pelo combatente
    SELECT MAX(hora_fim) INTO ultimo_fim
    FROM turno_combatente
    WHERE id_combatente = NEW.id_combatente;

    -- Se houver um turno anterior, calcula o descanso
    IF ultimo_fim IS NOT NULL THEN
        SET horas_descanso = TIMESTAMPDIFF(HOUR, ultimo_fim, NEW.hora_inicio);

        -- Se o descanso for menor que 24h, marca como VIOLADO
        IF horas_descanso < 24 THEN
            SET NEW.status_descanso = 'VIOLADO';
        ELSE
            SET NEW.status_descanso = 'OK';
        END IF;
    END IF;
END$$

DELIMITER ;