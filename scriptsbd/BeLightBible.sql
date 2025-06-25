USE BeLightBibleDB;
GO

CREATE TABLE Users (
	UserId INT PRIMARY KEY IDENTITY(1,1),
	Username NVARCHAR(100) NOT NULL UNIQUE,
	Email NVARCHAR(255) NOT NULL UNIQUE,
	PasswordHash NVARCHAR(255) NOT NULL,
	CreatedAt DATETIME DEFAULT GETDATE()
);

CREATE TABLE VersiculoSublinhado (

	Id INT PRIMARY KEY IDENTITY(1,1),
    UserId INT NOT NULL,
    Livro NVARCHAR(100) NOT NULL,
    Capitulo INT NOT NULL,
    Versiculo INT NOT NULL,
	Texto NVARCHAR(1000) NOT NULL,
    Cor NVARCHAR(20) NOT NULL, -- Ex: "#FF0000"
    DataCriado DATETIME DEFAULT GETDATE(),

    FOREIGN KEY (UserId) REFERENCES Users(UserId) ON DELETE CASCADE
);

CREATE TABLE RespostasCache (
    Id INT PRIMARY KEY IDENTITY(1,1),
    Pergunta NVARCHAR(MAX),
    Resposta NVARCHAR(MAX),
    Embedding NVARCHAR(MAX) -- Vetor será salvo como JSON aqui
);

select * from RespostasCache

CREATE TABLE VersiculoAnotado (
	Id INT PRIMARY KEY IDENTITY(1,1),
	UserId INT NOT NULL,
	Livro NVARCHAR(50) NOT NULL,
	Capitulo INT NOT NULL,
	Versiculo INT NOT NULL,
	Texto NVARCHAR(1000) NOT NULL,

	FOREIGN KEY (UserId) REFERENCES Users(UserId) ON DELETE CASCADE
);

CREATE TABLE VersiculoSalvo (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    UserId INT NOT NULL,
    Livro NVARCHAR(100) NOT NULL,
    Capitulo INT NOT NULL,
    Versiculo INT NOT NULL,
    Texto NVARCHAR(1000) NOT NULL,
    DataSalvo DATETIME NOT NULL DEFAULT GETDATE(),
	FOREIGN KEY (UserId) REFERENCES Users(UserId) ON DELETE CASCADE
);

ALTER TABLE VersiculoAnotado
ADD DataSalvo DATETIME NOT NULL DEFAULT GETDATE();


CREATE TABLE UltimoPontoLeitura (
    UserId INT PRIMARY KEY,
    Livro NVARCHAR(100) NOT NULL,
    Capitulo INT NOT NULL,
    DataAtualizacao DATETIME DEFAULT GETDATE(),

    FOREIGN KEY (UserId) REFERENCES Users(UserId) ON DELETE CASCADE
);

CREATE TABLE PlanoLeitura (
    Id INT PRIMARY KEY IDENTITY,
    Nome NVARCHAR(100) NOT NULL,
    Descricao NVARCHAR(300),
    DiasDuracao INT NOT NULL
);

CREATE TABLE PlanoLeituraUtilizador (
    Id INT PRIMARY KEY IDENTITY(1,1),
    UserId INT NOT NULL,
    PlanoLeituraId INT NOT NULL,
    DataInicio DATE NOT NULL DEFAULT GETDATE(),
    ProgressoDiaAtual INT DEFAULT 1, -- começa no dia 1
    CONSTRAINT FK_PlanoLeituraUtilizador_User FOREIGN KEY (UserId) REFERENCES Users(UserId),
    CONSTRAINT FK_PlanoLeituraUtilizador_Plano FOREIGN KEY (PlanoLeituraId) REFERENCES PlanoLeitura(Id)
);

CREATE TABLE PlanoLeituraDia (
    Id INT PRIMARY KEY IDENTITY(1,1),
    PlanoUtilizadorId INT NOT NULL,
    Dia INT NOT NULL,
    Capitulos NVARCHAR(MAX), -- Lista de capítulos separados por vírgula: "Gênesis 1,Gênesis 2"
    Lido BIT DEFAULT 0,
    DataLeitura DATETIME NULL,

    FOREIGN KEY (PlanoUtilizadorId) REFERENCES PlanoLeituraUtilizador(Id) ON DELETE CASCADE
);

CREATE TABLE PlanoLeituraModeloDia (
    Id INT PRIMARY KEY IDENTITY(1,1),
    PlanoLeituraId INT NOT NULL,
    Dia INT NOT NULL,
    Capitulos NVARCHAR(MAX) NOT NULL, -- Ex: "Gênesis 1, Gênesis 2"
    
    FOREIGN KEY (PlanoLeituraId) REFERENCES PlanoLeitura(Id) ON DELETE CASCADE
);

select * from PlanoLeituraModeloDia



select * from PlanoLeituraModeloDia
select * from PlanoLeituraUtilizador
ALTER TABLE PlanoLeitura
ADD ImagemBase64 NVARCHAR(MAX) NULL;


INSERT INTO PlanoLeitura (Nome, Descricao, DiasDuracao)
VALUES
('Bíblia em 1 Ano', 'Leia toda a Bíblia em 365 dias.', 365),
('Evangelhos em 30 Dias', 'Plano para ler os 4 evangelhos em 1 mês.', 30);


SELECT * FROM PlanoLeituraDia;
DELETE FROM PlanoLeitura;
select * from PlanoLeituraModeloDia
select * from PlanoLeituraUtilizador
select * from VersiculoAnotado;
select * from VersiculoSalvo;
select * from VersiculoSublinhado;
select * from Users;

select * from RespostasCache

DELETE FROM RespostasCache WHERE id = 9;