CREATE DATABASE IF NOT EXISTS avaliacao;

USE avaliacao;

CREATE TABLE Cliente(
    Id INT AUTO_INCREMENT PRIMARY key,
    Nome VARCHAR(55) not null,
    DataNascimento Date not null,
    Sexo INT not null,
    Cep INT(8),
    Endereco VARCHAR(255),
    Numero VARCHAR(8),
    Complemento VARCHAR(55),
    Bairro VARCHAR(55),
    Cidade VARCHAR(100),
    Estado VARCHAR(2)
)