using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FirebirdSql.Data.FirebirdClient;
using Carros.Infra.Banco;
using System.Data;
using Carros.Dominio.Entidades;

namespace Carros.Infra.Repositorio
{
    public class CidadeRepositorioADO
    {
        private BancoFB _banco;

        //public DataTable Listar()
        //{
        //    try
        //    {
        //        conexaoFireBird.Open();
        //        string mSQL = "Select * from Cidade";
        //        FbCommand cmd = new FbCommand(mSQL, conexaoFireBird);
        //        FbDataAdapter da = new FbDataAdapter(cmd);

        //        DataTable dtCidade = new DataTable();
        //        da.Fill(dtCidade);
        //        return dtCidade;
        //    }
        //    catch (Exception ex)
        //    {
        //        throw new Exception(ex.Message);
        //    }

        //using (FbConnection conexaoFireBird = daoFireBird.getInstancia().getConexao())
        //{
        //    try
        //    {
        //        conexaoFireBird.Open();
        //        string mSQL = "Select * from Cidade";
        //        FbCommand cmd = new FbCommand(mSQL, conexaoFireBird);
        //        FbDataAdapter da = new FbDataAdapter(cmd);

        //        DataTable dtCidade = new DataTable();
        //        da.Fill(dtCidade);
        //        return dtCidade;
        //    }
        //    catch(Exception ex)
        //    {
        //        throw new Exception(ex.Message);
        //    }
        //    finally
        //    {
        //        conexaoFireBird.Close();
        //    }
        //}
        //}

        public List<Cidade> ListarPorNome(string nome, int id = 0)
        {
            using (_banco = new BancoFB())
            {
                var sb = new StringBuilder();
                sb.AppendLine("SELECT ID, CEP, DESCRICAO, UF FROM Cidade ");
                if (id > 0)
                    sb.AppendLine(" WHERE Id = " + id);
                else
                    sb.AppendLine("where DESCRICAO containing('" + nome + "') ORDER BY DESCRICAO");

                _banco.RetornoReader(sb.ToString());
                List<Cidade> lista = new List<Cidade>();
                while (_banco.Read())
                {
                    var model = new Cidade()
                    {
                        CEP = _banco.CampoStr("CEP"),
                        Id = _banco.CampoInt32("Id"),
                        Nome = _banco.CampoStr("Descricao"),
                        UF = _banco.CampoStr("UF")
                    };
                    lista.Add(model);
                };
                _banco.CloseReader();

                return lista;
            }
        }

        public Cidade ObterPorid(int id)
        {
            using (_banco = new BancoFB())
            {
                var model = new Cidade();
                _banco.RetornoReader("SELECT ID, CEP, DESCRICAO, UF FROM Cidade where ID = " + id);
                if (_banco.Read())
                {
                    model.CEP = _banco.CampoStr("CEP");
                    model.Id = _banco.CampoInt32("Id");
                    model.Nome = _banco.CampoStr("Descricao");
                    model.UF = _banco.CampoStr("UF");
                }
                _banco.CloseReader();
                return model;
            }
        }

        public void Excluir(int id)
        {
            using (_banco = new BancoFB())
            {
                _banco.ExecutaComando("DELETE FROM CIDADE where ID = " + id);
            }
        }

        public void Salvar(Cidade model)
        {
            using (_banco = new BancoFB())
            {
                string Instrucao;
                if (model.Id == 0)
                {
                    model.Id = _banco.RetornarId("SEQ_CIDADE");
                    Instrucao = string.Format("INSERT INTO CIDADE(DESCRICAO, CEP, UF, ID) VALUES ('{0}', '{1}', '{2}', {3}) returning id",
                        model.Nome, model.CEP, model.UF, model.Id);
                    model.Id = _banco.ExecutaScalar(Instrucao);
                }
                else
                {
                    Instrucao = string.Format("UPDATE CIDADE SET DESCRICAO='{0}', CEP='{1}', UF='{2}' WHERE ID = {3}",
                        model.Nome, model.CEP, model.UF, model.Id);
                    _banco.ExecutaComando(Instrucao);
                }
            }
        }
    }

}
