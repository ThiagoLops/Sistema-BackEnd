-- 1 - Criar o banco
CREATE DATABASE programacao_do_zero;

-- Usar o banco / selecionar o que irá recebe os comandos
USE programacao_do_zero;

-- Criar tabela; 
CREATE TABLE usuario(

	id INT NOT NULL AUTO_INCREMENT, -- CRIAÇÃO DA ID CRIAR AUTOMÁTICAMENTE (AUTO INCREMENT)
	nome VARCHAR(50) NOT NULL, 
	sobrenome VARCHAR(150) NOT NULL,
	telefone VARCHAR(15) NOT NULL,
	email VARCHAR(150) NOT NULL, 
	genero VARCHAR(20) NOT NULL,
	senha VARCHAR(30) NOT NULL
	PRIMARY KEY(id)

);

-- Criar tabela endereço 

CREATE TABLE endereco (
	id INT NOT NULL AUTO_INCREMENT,
    rua VARCHAR(250) NOT NULL,
    numero VARCHAR(30) NOT NULL,
    bairro VARCHAR(150) NOT NULL, 
    cidade VARCHAR(250) NOT NULL,
    complemento VARCHAR(150) NOT NULL,
    cep VARCHAR(9) NOT NULL,
    estado VARCHAR(2) NOT NULL, 
    
    PRIMARY KEY(id)
);

-- Alterar tabela endereço, adicionando nova coluna; 
ALTER TABLE endereco ADD  usuario_id INT NOT NULL; 

-- Relacionando tabelas, ADICIONANDO CHAVES ESTRANGERIAS
ALTER TABLE endereco 
ADD CONSTRAINT FK_usuario FOREIGN KEY (usuario_id) REFERENCES usuario(id);

-- Inserir dados na tabela usuario
INSERT INTO usuario(nome, sobrenome, telefone, email, genero, senha) 
VALUES ('Thiago', 'Lopes', '31 992319775', 'thiagolopes.particular@gmail.com', 'masculino', '123');

-- Selecionar todos os usuarios;
SELECT * FROM usuario;

-- Selecionar usuarios com WHERE (paramentros)
SELECT * FROM usuario WHERE email = 'shirley@gmail.com';

-- Alterar dados de uma tabela
SELECT * FROM usuario; 

UPDATE  usuario SET email = 'shirleylopes315@gmail.com' WHERE id = 2;

-- Apagar linhas de uma tabela // Opções de delete, selecionar várias
DELETE FROM usuario WHERE id=2;
DELETE FROM usuario WHERE id > 2;
DELETE FROM usuario WHERE id IN (2,3,6);