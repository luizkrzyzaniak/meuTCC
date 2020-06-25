
CREATE TABLE curso (
       cur_cod              int IDENTITY(1,1),
       cur_desc             varchar(30) NULL,
       PRIMARY KEY (cur_cod)
)
go


CREATE TABLE modulos (
       mod_cod              int IDENTITY(1,1),
       mod_desc             varchar(30) NULL,
       mod_valor            money NULL,
       PRIMARY KEY (mod_cod)
)
go


CREATE TABLE modulos_curso (
       mod_cod              int NOT NULL,
       cur_cod              int NOT NULL,
       PRIMARY KEY (mod_cod, cur_cod)
)
go


CREATE TABLE unidadeensino (
       ue_cod               int IDENTITY(1,1),
       ue_nome              varchar(40) NULL,
       ue_responsavel       varchar(40) NULL,
       ue_endereco          varchar(30) NULL,
       ue_numero            int NULL,
       ue_bairro            varchar(30) NULL,
       ue_dddfixo           int NULL,
       ue_numfixo           int NULL,
       ue_uf                varchar(2) NULL,
       ue_cidade            varchar(30) NULL,
       PRIMARY KEY (ue_cod)
)
go


CREATE TABLE ofertacurso (
       oc_cod               int IDENTITY(1,1),
       cur_cod              int NOT NULL,
       ue_cod               int NOT NULL,
       oc_dtinicio          datetime NULL,
       oc_dtfinal           datetime NULL,
       oc_desc              varchar(40) NULL,
       PRIMARY KEY (oc_cod)
)
go


CREATE TABLE ofertacursomodulo (
       ocm_cod              int IDENTITY(1,1),
       oc_cod               int NOT NULL,
       mod_cod              int NOT NULL,
       ocm_dtinicio         datetime NULL,
       ocm_dtfinal          datetime NULL,
       PRIMARY KEY (ocm_cod)
)
go


CREATE TABLE professor (
       prof_cod             int IDENTITY(1,1),
       prof_nome            varchar(40) NULL,
       prof_cpf             varchar(11) NULL,
       prof_rg              varchar(14) NULL,
       prof_dtnasc          datetime NULL,
       prof_endereco        varchar(30) NULL,
       prof_numero          int NULL,
       prof_bairro          varchar(30) NULL,
       prof_dddfixo         int NULL,
       prof_numfixo         int NULL,
       prof_dddcel          int NULL,
       prof_numcel          int NULL,
       prof_curriculo       varchar(max) NULL,
       prof_uf              varchar(2) NULL,
       prof_cidade          varchar(30) NULL,
       PRIMARY KEY (prof_cod)
)
go


CREATE TABLE professor_ofertacursomodulo (
       prof_cod             int NOT NULL,
       ocm_cod              int NOT NULL,
       PRIMARY KEY (prof_cod, ocm_cod)
)
go


CREATE TABLE matricula (
       mat_cod              int IDENTITY(1,1),
       oc_cod               int NOT NULL,
       mat_data             datetime NULL,
       PRIMARY KEY (mat_cod)
)
go


CREATE TABLE alunos (
       alu_ra               int IDENTITY(1110,1),
       alu_nome             varchar(40) NULL,
       alu_cpf              varchar(11) NULL,
       alu_rg               varchar(14) NULL,
       alu_dtnasc           datetime NULL,
       alu_endereco         varchar(30) NULL,
       alu_numero           int NULL,
       alu_bairro           varchar(30) NULL,
       alu_dddfixo          int NULL,
       alu_numfixo          int NULL,
       alu_dddcel           int NULL,
       alu_numcel           int NULL,
       alu_uf               varchar(2) NULL,
       alu_cidade           varchar(30) NULL,
       PRIMARY KEY (alu_ra)
)
go


CREATE TABLE alunos_ofertacursomodulo (
       alu_ra               int NOT NULL,
       ocm_cod              int NOT NULL,
       mat_cod              int NOT NULL,
       PRIMARY KEY (alu_ra, ocm_cod, mat_cod)
)
go


CREATE TABLE parcelas (
       par_cod              int IDENTITY(1,1),
       mat_cod              int NOT NULL,
       par_valor            numeric(10,2) NULL,
       par_dtvenc           datetime NULL,
       par_situacao         char(1) NULL,
       par_dtpag            datetime NULL,
       PRIMARY KEY (par_cod)
)
go


CREATE TABLE presenca (
       alu_ra               int NOT NULL,
       ocm_cod              int NOT NULL,
       pre_data             datetime NULL,
       pre_situacao         char(1) NULL
)
go


ALTER TABLE modulos_curso
       ADD FOREIGN KEY (cur_cod)
                             REFERENCES curso
go


ALTER TABLE modulos_curso
       ADD FOREIGN KEY (mod_cod)
                             REFERENCES modulos
go


ALTER TABLE ofertacurso
       ADD FOREIGN KEY (cur_cod)
                             REFERENCES curso
go


ALTER TABLE ofertacurso
       ADD FOREIGN KEY (ue_cod)
                             REFERENCES unidadeensino
go


ALTER TABLE ofertacursomodulo
       ADD FOREIGN KEY (oc_cod)
                             REFERENCES ofertacurso
go


ALTER TABLE ofertacursomodulo
       ADD FOREIGN KEY (mod_cod)
                             REFERENCES modulos
go


ALTER TABLE professor_ofertacursomodulo
       ADD FOREIGN KEY (ocm_cod)
                             REFERENCES ofertacursomodulo
go


ALTER TABLE professor_ofertacursomodulo
       ADD FOREIGN KEY (prof_cod)
                             REFERENCES professor
go


ALTER TABLE matricula
       ADD FOREIGN KEY (oc_cod)
                             REFERENCES ofertacurso
go


ALTER TABLE alunos_ofertacursomodulo
       ADD FOREIGN KEY (mat_cod)
                             REFERENCES matricula
go


ALTER TABLE alunos_ofertacursomodulo
       ADD FOREIGN KEY (ocm_cod)
                             REFERENCES ofertacursomodulo
go


ALTER TABLE alunos_ofertacursomodulo
       ADD FOREIGN KEY (alu_ra)
                             REFERENCES alunos
go


ALTER TABLE parcelas
       ADD FOREIGN KEY (mat_cod)
                             REFERENCES matricula
go


ALTER TABLE presenca
       ADD FOREIGN KEY (ocm_cod)
                             REFERENCES ofertacursomodulo
go


ALTER TABLE presenca
       ADD FOREIGN KEY (alu_ra)
                             REFERENCES alunos
go



