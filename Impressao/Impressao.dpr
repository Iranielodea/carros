program Impressao;

uses
  Vcl.Forms,
  uTela in 'uTela.pas' {Form1},
  uConverter in 'uConverter.pas',
  uEncontro in 'uEncontro.pas';

{$R *.res}

begin
  Application.Initialize;
  Application.MainFormOnTaskbar := True;
  Application.CreateForm(TForm1, Form1);
  Application.Run;
end.
