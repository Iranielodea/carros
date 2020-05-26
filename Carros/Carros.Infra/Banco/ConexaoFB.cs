using FirebirdSql.Data.FirebirdClient;
using System;
using System.Configuration;
using System.Data;

namespace Carros.Infra.Banco
{
    public class ConexaoFB
    {
        private readonly FbConnection _conexao;
        FbDataReader dr;
        FbTransaction _trans;

        public ConexaoFB()
        {
            //string nomeBanco = "Gestao";
            //string usuario = "Irani";
            //string password = "123";
            //string servidor = "DESKTOP-I018I3M";

            //string conexaoSql = "Data Source=" + servidor + ";Initial Catalog=" + nomeBanco
            //    + ";User ID=" + usuario
            //    + ";Password=" + password;

            //string conexaoSql = ConfigurationManager.ConnectionStrings["FBERP"].ConnectionString;
            string conexaoSql = ConfigurationManager.ConnectionStrings["FireBirdConnectionString"].ToString();

            //_conexao = conexao;
            _conexao = new FbConnection(conexaoSql);
            //_conexao.Open();
        }

        public void StartTransaction()
        {
            AbrirConexao();
            _trans = _conexao.BeginTransaction();
        }

        public void Commit()
        {
            _trans.Commit();
            FecharConexao();
        }

        public void RollBack()
        {
            _trans.Rollback();
            FecharConexao();
        }

        public void AbrirConexao()
        {
            if (_conexao.State != ConnectionState.Open)
            {
                _conexao.Open();
            }
        }

        public bool CampoBool(string valor)
        {
            try
            {
                //return (bool)dr[valor];
                return (dr[valor].ToString() == "1");
            }
            catch (Exception)
            {
                return false;
            }
        }

        public DateTime CampoData(string valor)
        {
            return Convert.ToDateTime(dr[valor]);
        }

        public decimal CampoDecimal(string valor)
        {
            try
            {
                return Convert.ToDecimal(dr[valor]);
            }
            catch
            {
                return 0;
            }
        }

        public string CampoHora(string valor)
        {
            string hora;
            hora = dr[valor].ToString();
            return hora.Substring(0, 5);
        }

        public int CampoInt(string valor)
        {
            try
            {
                return (Int32)dr[valor];
            }
            catch (Exception)
            {
                return 0;
            }
        }

        public int CampoInt32(string valor)
        {
            try
            {
                return Convert.ToInt32(dr[valor]);
            }
            catch
            {
                return 0;
            }
        }

        public string CampoStr(string valor)
        {
            try
            {
                return dr[valor].ToString();
            }
            catch (Exception)
            {
                return "";
            }
        }

        public void CloseReader()
        {
            dr.Close();
        }

        public void FecharConexao()
        {
            if (_conexao.State == ConnectionState.Open)
            {
                _conexao.Close();
            }
        }

        public void ExecutaComando(string strQuery)
        {
            //AbrirConexao();
            var cmd = new FbCommand
            {
                CommandText = strQuery,
                CommandType = CommandType.Text,
                Connection = _conexao
            };
            cmd.Transaction = _trans;

            try
            {
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public int ExecutaRetorno(string strQuery)
        {
            //AbrirConexao();
            var cmd = new FbCommand
            {
                CommandText = strQuery,
                CommandType = CommandType.Text,
                Connection = _conexao
            };

            try
            {
                cmd.Transaction = _trans;
                return (int)cmd.ExecuteScalar();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public bool Read()
        {
            return dr.Read();
        }

        public void RetornoReader(string strQry)
        {
            //AbrirConexao(); 
            var cmd = new FbCommand(strQry, _conexao);
            try
            {
                cmd.Transaction = _trans;
                dr = cmd.ExecuteReader();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public bool RetornoReaderBool(string strQry)
        {
            //AbrirConexao();
            var cmd = new FbCommand(strQry, _conexao);
            try
            {
                cmd.Transaction = _trans;
                dr = cmd.ExecuteReader();
                return dr.Read();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
