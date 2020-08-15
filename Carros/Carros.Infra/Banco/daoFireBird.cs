using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FirebirdSql.Data.FirebirdClient;
using System.Configuration;

namespace Carros.Infra.Banco
{
    public class daoFireBird
    {
        private static readonly daoFireBird instanciaFireBird = new daoFireBird();

        private daoFireBird() { }

        public static daoFireBird getInstancia()
        {
            return instanciaFireBird;
        }

        public FbConnection getConexao()
        {
            string conn = ConfigurationManager.ConnectionStrings["FireBirdConnectionString"].ToString();
            return new FbConnection(conn);
        }

        public static string ConexaoBanco()
        {
            return ConfigurationManager.ConnectionStrings["FireBirdConnectionString"].ToString();
        }
    }
}
