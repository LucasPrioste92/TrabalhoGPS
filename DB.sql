CREATE TABLE [dbo].[User]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [nome] NVARCHAR(45) NOT NULL, 
    [email] NVARCHAR(60) NOT NULL, 
    [password] NVARCHAR(MAX) NOT NULL, 
    [tipoConta] INT NOT NULL, 
    [escola] NVARCHAR(50) NOT NULL, 
    [estado] INT NOT NULL, 
    [codigoRec] NVARCHAR(MAX) NULL
)

CREATE TABLE [dbo].[Horario]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [idUser] INT NOT NULL, 
    [publico] BIT NOT NULL, 
    CONSTRAINT [FK_Horario_ToUser] FOREIGN KEY ([idUser]) REFERENCES [User]([Id])
)

CREATE TABLE [dbo].[AtividadeExtra]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [idUser] INT NOT NULL, 
    [idHorario] INT NOT NULL, 
    [nome] NVARCHAR(45) NOT NULL, 
    [horaCom] TIME NOT NULL, 
    [horaFim] TIME NOT NULL, 
    [diaSemana] INT NOT NULL, 
    CONSTRAINT [FK_AtividadeExtra_ToUser] FOREIGN KEY ([idUser]) REFERENCES [User]([Id]), 
    CONSTRAINT [FK_AtividadeExtra_ToHorario] FOREIGN KEY ([idHorario]) REFERENCES [Horario]([Id])
)
CREATE TABLE [dbo].[Gabinete]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [idHorario] INT NOT NULL, 
    [idUser] INT NOT NULL, 
    [horaTermino] TIME NOT NULL, 
    [horaComeco] TIME NOT NULL, 
    [local] NVARCHAR(45) NOT NULL, 
    [diaSemana] INT NOT NULL, 
    [descricao] NVARCHAR(85) NOT NULL, 
    CONSTRAINT [FK_Gabinete_Horario] FOREIGN KEY ([idHorario]) REFERENCES [Horario]([Id]), 
    CONSTRAINT [FK_Gabinete_User] FOREIGN KEY ([idUser]) REFERENCES [User]([Id])
)
CREATE TABLE [dbo].[Curso] (
    [Id]   INT           NOT NULL IDENTITY,
    [nome] NVARCHAR (50) NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);

CREATE TABLE [dbo].[Disciplina]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [idCurso] INT NOT NULL, 
    [nome] NVARCHAR(95) NOT NULL, 
    [horaTermino] TIME NOT NULL, 
    [horaComeco] TIME NOT NULL, 
    [turma] NVARCHAR(20) NOT NULL, 
    [local] NVARCHAR(45) NOT NULL, 
    [diaSemana] INT NOT NULL, 
    CONSTRAINT [FK_Disciplina_ToCurso] FOREIGN KEY ([idCurso]) REFERENCES [Curso]([Id])
)
CREATE TABLE [dbo].[HorarioDisciplina] (
    [idDisciplina] INT NOT NULL,
    [idHorario]    INT NOT NULL,
    [Id] INT NOT NULL  IDENTITY, 
    CONSTRAINT [FK_HorarioDisciplina_Disciplina] FOREIGN KEY ([idDisciplina]) REFERENCES [dbo].[Disciplina] ([Id]),
    CONSTRAINT [FK_HorarioDisciplina_Horario] FOREIGN KEY ([idHorario]) REFERENCES [dbo].[Horario] ([Id]), 
    CONSTRAINT [PK_HorarioDisciplina] PRIMARY KEY ([Id])
);
