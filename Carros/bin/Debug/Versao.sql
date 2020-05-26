--VERSAO: 00001

CREATE OR ALTER TRIGGER TRG_MARCA_BI0 FOR MARCA
ACTIVE BEFORE INSERT POSITION 0
AS
begin
  if ((new.id is null) or (new.id <= 0) ) then
    new.id = gen_id(seq_marca,1);
end;
GO

CREATE OR ALTER TRIGGER TRG_SEQUENCIA_BI0 FOR SEQUENCIA
ACTIVE BEFORE INSERT POSITION 0
AS
begin
  if ((new.id is null) or (new.id <= 0) ) then
    new.id = gen_id(seq_sequencia,1);
end;
GO

CREATE OR ALTER TRIGGER TRG_CIDADE_BI0 FOR CIDADE
ACTIVE BEFORE INSERT POSITION 0
AS
begin
  if ((new.id is null) or (new.id <= 0) ) then
    new.id = gen_id(seq_cidade,1);
end;
GO

CREATE OR ALTER TRIGGER TRG_cad_encontro_BI0 FOR cad_encontro
ACTIVE BEFORE INSERT POSITION 0
AS
begin
  if ((new.id is null) or (new.id <= 0) ) then
    new.id = gen_id(seq_cad_encontro,1);
end;
GO

CREATE OR ALTER TRIGGER TRG_profissao_BI0 FOR profissao
ACTIVE BEFORE INSERT POSITION 0
AS
begin
  if ((new.id is null) or (new.id <= 0) ) then
    new.id = gen_id(seq_profissao,1);
end;
GO

CREATE OR ALTER TRIGGER TRG_tabcontrole_BI0 FOR tabcontrole
ACTIVE BEFORE INSERT POSITION 0
AS
begin
  if ((new.id is null) or (new.id <= 0) ) then
    new.id = gen_id(seq_tabcontrole,1);
end;
GO

CREATE OR ALTER TRIGGER TRG_usuario_BI0 FOR usuario
ACTIVE BEFORE INSERT POSITION 0
AS
begin
  if ((new.id is null) or (new.id <= 0) ) then
    new.id = gen_id(seq_usuario,1);
end;
GO

CREATE OR ALTER TRIGGER TRG_veiculo_BI0 FOR veiculo
ACTIVE BEFORE INSERT POSITION 0
AS
begin
  if ((new.id is null) or (new.id <= 0) ) then
    new.id = gen_id(seq_veiculo,1);
end;
GO

CREATE OR ALTER TRIGGER TRG_Pessoa_BI0 FOR Pessoa
ACTIVE BEFORE INSERT POSITION 0
AS
begin
  if ((new.id is null) or (new.id <= 0) ) then
    new.id = gen_id(seq_pessoa,1);
end;
GO

CREATE OR ALTER TRIGGER TRG_contato_BI0 FOR contato
ACTIVE BEFORE INSERT POSITION 0
AS
begin
  if ((new.id is null) or (new.id <= 0) ) then
    new.id = gen_id(seq_contato,1);
end;
GO

CREATE OR ALTER TRIGGER TRG_veiculo_pessoa_BI0 FOR veiculo_pessoa
ACTIVE BEFORE INSERT POSITION 0
AS
begin
  if ((new.id is null) or (new.id <= 0) ) then
    new.id = gen_id(seq_veiculo_pessoa,1);
end;
GO

CREATE OR ALTER TRIGGER TRG_ENCONTRO_BI0 FOR ENCONTRO
ACTIVE BEFORE INSERT POSITION 0
AS
begin
  if ((new.id is null) or (new.id <= 0) ) then
    new.id = gen_id(seq_encontro,1);
end;
GO

INSERT INTO TABCONTROLE(DESCRICAO, SIGLA, VALORINT) VALUES ('VERSAO','VERSAO', 1);
GO

--VERSAO: 00002

CREATE OR ALTER TRIGGER TRG_FILIACAO_BI0 FOR FILIACAO
ACTIVE BEFORE INSERT POSITION 0
AS
begin
  if ((new.id is null) or (new.id <= 0) ) then
    new.id = gen_id(seq_filiacao,1);
end;
GO