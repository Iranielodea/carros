unit uEncontro;

interface

uses System.Classes, System.SysUtils;

type
  TEncontro = class
  private
    FNomePessoa: string;
    FModelo: string;
    FNumeroFicha: Integer;
    FAno: Integer;
    FLetra: string;
  public
    property Letra: string read FLetra write FLetra;
    property NomePessoa: string read FNomePessoa write FNomePessoa;
    property Modelo: string read FModelo write FModelo;
    property Ano: Integer read FAno write FAno;
    property NumeroFicha: Integer read FNumeroFicha write FNumeroFicha;
  end;

implementation

end.
