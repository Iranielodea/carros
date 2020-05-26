unit uEncontro;

interface

type
  TImpressaoEncontro = class
  private
    FNomePessoa: string;
    FModelo: string;
    FNumeroFicha: Integer;
    FAno: Integer;
    FLetra: string;
    procedure SetAno(const Value: Integer);
    procedure SetLetra(const Value: string);
    procedure SetModelo(const Value: string);
    procedure SetNomePessoa(const Value: string);
    procedure SetNumeroFicha(const Value: Integer);
  public
    property Letra: string read FLetra write SetLetra;
    property NomePessoa: string read FNomePessoa write SetNomePessoa;
    property Modelo: string read FModelo write SetModelo;
    property Ano: Integer read FAno write SetAno;
    property NumeroFicha: Integer read FNumeroFicha write SetNumeroFicha;
  end;

implementation

{ TImpressaoEncontro }

procedure TImpressaoEncontro.SetAno(const Value: Integer);
begin
  FAno := Value;
end;

procedure TImpressaoEncontro.SetLetra(const Value: string);
begin
  FLetra := Value;
end;

procedure TImpressaoEncontro.SetModelo(const Value: string);
begin
  FModelo := Value;
end;

procedure TImpressaoEncontro.SetNomePessoa(const Value: string);
begin
  FNomePessoa := Value;
end;

procedure TImpressaoEncontro.SetNumeroFicha(const Value: Integer);
begin
  FNumeroFicha := Value;
end;

end.
