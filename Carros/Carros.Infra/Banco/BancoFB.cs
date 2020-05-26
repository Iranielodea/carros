using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FirebirdSql.Data.FirebirdClient;
using System.Configuration;
using System.Data;

namespace Carros.Infra.Banco
{
    public class BancoFB : IDisposable
    {
        private readonly FbConnection conexao;

        FbDataReader dr;

        public BancoFB()
        {
            string conexaoSql = ConfigurationManager.ConnectionStrings["FireBirdConnectionString"].ConnectionString;
            conexao = new FbConnection(conexaoSql);
            conexao.Open();
        }

        public void ExecutaComando(string strQuery)
        {
            var cmd = new FbCommand
            {
                CommandText = strQuery,
                CommandType = CommandType.Text,
                Connection = conexao
            };

            try
            {
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                FecharConexao();
            }
        }

        public int ExecutaScalar(string strQuery)
        {
            var cmd = new FbCommand
            {
                CommandText = strQuery,
                CommandType = CommandType.Text,
                Connection = conexao
            };

            try
            {
                return (Int32) cmd.ExecuteScalar();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                FecharConexao();
            }
        }


        public void Dispose()
        {
            FecharConexao();
        }

        public void RetornoReader(string strQry)
        {
            //FbConnection conexaoFireBird = daoFireBird.getInstancia().getConexao();
            try
            {
                //conexaoFireBird.Open();
                FbCommand cmd = new FbCommand(strQry, conexao);
                dr = cmd.ExecuteReader();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public int RetornarId(string generator)
        {
            int id = 1;
            string retorno = string.Format("SELECT gen_id( {0},1) as ID FROM RDB$DATABASE", generator);
            RetornoReader(retorno);
            if (Read())
            {
                id = CampoInt32("Id");
            }
            CloseReader();
            return id;
        }

        private void FecharConexao()
        {
            if (conexao.State == ConnectionState.Open)
            {
                conexao.Close();
            }
        }

        public bool Read()
        {
            return dr.Read();
        }

        public void CloseReader()
        {
            dr.Close();
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

        public bool CampoBool(string valor)
        {
            try
            {
                return (bool)dr[valor];
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

        public DateTime? CampoDataNull(string valor)
        {
            try
            {
                return CampoData(valor);
            }
            catch
            {
                return null;
            }
        }

        public int? CampoIntNull(string valor)
        {
            try
            {
                return Convert.ToInt32(dr[valor]);
            }
            catch
            {
                return null;
            }
        }

        public string CampoHora(string valor)
        {
            string hora;
            hora = dr[valor].ToString();
            return hora.Substring(0, 5);
        }

        public Decimal CampoDecimal(string valor)
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
    }
}
