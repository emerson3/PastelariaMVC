CREATE TABLE dbo.tarefaStatus ( 
	id                   int      NOT NULL,
	descricao            varchar(45)      NOT NULL,
	CONSTRAINT pk_tarefaStatus PRIMARY KEY  ( id ) 
 );
GO

CREATE TABLE dbo.tipoUsuario ( 
	id                   int      NOT NULL,
	descricao            varchar(45)      NOT NULL,
	CONSTRAINT pk_tipo_usuario PRIMARY KEY  ( id ) 
 );
GO

CREATE TABLE dbo.usuario ( 
	id                   int    IDENTITY  NOT NULL,
	idTipoUsuario        int      NOT NULL,
	nome                 varchar(45)      NOT NULL,
	email                varchar(100)      NOT NULL,
	[senha ]             varchar(30)      NOT NULL,
	dataExpiracaoSenha   datetime      NOT NULL,
	idUsuarioCadastro    int      NOT NULL,
	CONSTRAINT pk_usuario PRIMARY KEY  ( id ) 
 );
GO

CREATE TABLE dbo.tarefa ( 
	id                   int    IDENTITY  NOT NULL,
	idTarefaStatus       int      NOT NULL,
	descricao            varchar(2000)      NOT NULL,
	tarefa				 varchar(50)	      NOT NULL,
	dataCriacao          datetime      NOT NULL,
	dataConclusao        datetime      NULL,
	idUsuarioCadastro    int      NOT NULL,
	CONSTRAINT pk_tarefa PRIMARY KEY  ( id ) 
 );
GO

CREATE TABLE dbo.usuarioTarefa ( 
	idUsuario            int      NOT NULL,
	idTarefa             int      NOT NULL,
	CONSTRAINT pk_usuarioTarefa PRIMARY KEY  ( idUsuario, idTarefa ) 
 );
GO

CREATE TABLE dbo.comentario ( 
	id                   int    IDENTITY  NOT NULL,
	idMae                int      NULL,
	idTarefa             int      NOT NULL,
	descricao            varchar(200)      NOT NULL,
	dataCadastro         datetime      NOT NULL,
	idUsuarioCadastro    int      NOT NULL,
	CONSTRAINT pk_comentario PRIMARY KEY  ( id ) 
 );
GO

ALTER TABLE dbo.comentario ADD CONSTRAINT fk_comentario_tarefa FOREIGN KEY ( idTarefa ) REFERENCES dbo.tarefa( id );
GO

ALTER TABLE dbo.comentario ADD CONSTRAINT fk_comentario_comentario FOREIGN KEY ( idMae ) REFERENCES dbo.comentario( id );
GO

ALTER TABLE dbo.tarefa ADD CONSTRAINT fk_tarefa_tarefastatus FOREIGN KEY ( idTarefaStatus ) REFERENCES dbo.tarefaStatus( id );
GO

ALTER TABLE dbo.usuario ADD CONSTRAINT fk_usuario_tipo_usuario FOREIGN KEY ( idTipoUsuario ) REFERENCES dbo.tipoUsuario( id );
GO

ALTER TABLE dbo.usuarioTarefa ADD CONSTRAINT fk_usuariotarefa_usuariotarefa FOREIGN KEY ( idUsuario ) REFERENCES dbo.usuario( id );
GO

ALTER TABLE dbo.usuarioTarefa ADD CONSTRAINT fk_usuariotarefa_tarefa FOREIGN KEY ( idTarefa ) REFERENCES dbo.tarefa( id );
GO

INSERT INTO tipoUsuario(id, descricao) VALUES(1, 'Gestor')
INSERT INTO tipoUsuario(id, descricao) VALUES(2, 'Funcionário')

INSERT INTO usuario(idTipoUsuario, nome, email, senha, dataExpiracaoSenha, idUsuarioCadastro) VALUES (1, 'Cayo', 'cayo@gmail.com', 'cayo', '20230202', 0)