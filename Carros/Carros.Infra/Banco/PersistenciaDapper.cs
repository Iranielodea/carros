namespace Carros.Infra.Banco
{
    public class PersistenciaDapper : Persistencia
    {
        public override string Inserir(object obj, string tabela, string campoId)
        {
            string InstrucaoSQL = "INSERT INTO " + tabela + "(";
            string campos = "";
            string valores = "";

            foreach (var prop in obj.GetType().GetProperties())
            {
                if (prop.GetMethod.IsVirtual)
                    continue;

                campos += prop.Name + ",";
                valores += "@" + prop.Name + ",";
            }
            campos = campos.Remove(campos.Length - 1, 1);
            valores = valores.Remove(valores.Length - 1, 1);
            InstrucaoSQL += campos + ") VALUES (";
            InstrucaoSQL += valores + ")";

            return InstrucaoSQL;
        }

        public override string Update(object obj, string tabela, string campoId, int valorId)
        {
            string InstrucaoSQL = "";
            string campos = "";
            string valor = "";

            foreach (var prop in obj.GetType().GetProperties())
            {
                if (prop.GetMethod.IsVirtual)
                    continue;

                campos += prop.Name + ",";
                campos += "@" + prop.Name + ",";

                if (prop.Name.ToUpper() == campoId.ToUpper())
                    continue;

                InstrucaoSQL += prop.Name + "=" + valor + ", ";
            }
            InstrucaoSQL = "UPDATE " + tabela + " SET " + InstrucaoSQL;
            InstrucaoSQL = InstrucaoSQL.Remove(InstrucaoSQL.Length - 2, 2);
            InstrucaoSQL += " WHERE " + campoId + " = '@" + valorId + "'";

            return InstrucaoSQL;
        }
    }
}
